using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Color c;
        //Graphics gr;
        int r = 28;
        int penWidth;
        Pen p;//= new Pen(Color.Black, penWidth);
        Pen selPen;
        Pen edgePen;

        SolidBrush b;
        Graph g = new Graph();
        int selectedVertex = -1;

        Font f;
        StringFormat sf;

        public Form1()
        {
            InitializeComponent();
            c = new Color();
            c = Color.Black;
            
            penWidth = 3;
            p = new Pen(Color.Black, penWidth);
            selPen = new Pen(Color.Black, penWidth);
            edgePen = new Pen(Color.Black, 2);
            selPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            selPen.DashPattern = new float[] { 2, 1.7F };
            b = new SolidBrush(Color.Black);
            f = new Font("Arial", 10);
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            
        }

        private void kolorB_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                c = MyDialog.Color;
                pictureBox1.BackColor = c;
                p.Color = c;
                b.Color = c;
                if (selectedVertex != -1)
                {
                    int ind = g.getIndex(selectedVertex);
                    g.V[ind] = (g.V[ind].x, g.V[ind].y, selectedVertex, c);
                    drawGraph(g);
                }
            }
        }

        private void mapa_MouseEnter(object sender, EventArgs e)
        {
            mapa.Cursor = Cursors.Cross;
        }

        private void mapa_MouseLeave(object sender, EventArgs e)
        {
            mapa.Cursor = Cursors.Default;
        }
    
        private double dist(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2-x1,2) + Math.Pow(y2-y1,2));
        }

        private (Point P1, Point P2) calc(int X1, int Y1, int X2, int Y2, int r)
        {
            // wyznaczenie wzoru funkcji, przez ktorej lezy S1, S2, s1, s2
            double a_lin = (Y2 - Y1) / (X2 - X1);
            double b_lin = Y1 - a_lin * X1;
            //
            double a_kw = (a_lin + 1);
            double b_kw = (-2 * X1 + 2 * a_lin * b_lin - 2 * a_lin * Y1);
            double c_kw = Math.Pow(X1, 2) - Math.Pow(r, 2) + Math.Pow(b_lin, 2) - 2 * b_lin * Y1 + Math.Pow(Y1, 2) ;
            double delta = Math.Pow(b_kw, 2) - 4 * a_kw * c_kw;
            double sq_delta = Math.Sqrt(delta);
            //
            double __x1 = (-b_kw - Math.Sign(b_kw) * sq_delta)/2/a_kw;//(-b_kw - sq_delta) / 2 / a_kw;
            double __x2 = c_kw / a_kw / __x1;//(-b_kw + sq_delta)/2/a_kw;
            double __y1 = a_lin * __x1 + b_lin;
            double __y2 = a_lin * __x2 + b_lin; // 2 punkty przeciecia dla okregu O1
            // bierzemy punkt lezacy blizej O2 i zapisujemy go jako __x1, __y1
            if (dist(__x2, __y2, X2, Y2) < dist(__x1, __y1, X2, Y2))
            {
                __x1 = __x2;
                __y1 = __y2;
            }
            Point P1 = new Point((int)__x1, (int)__y1);
            a_kw = (a_lin + 1);
             b_kw = (-2 * X2 + 2 * a_lin * b_lin - 2 * a_lin * Y2);
             c_kw = Math.Pow(X2, 2) - Math.Pow(r, 2) + Math.Pow(b_lin, 2) - 2 * b_lin * Y2 + Math.Pow(Y2, 2) ;
             delta = Math.Pow(b_kw, 2) - 4 * a_kw * c_kw;
             sq_delta = Math.Sqrt(delta);
            ////
            __x1 = (-b_kw - Math.Sign(b_kw) * sq_delta)/2/a_kw;
            __x2 = c_kw / a_kw / __x1;
//__x1 = -b_kw - Math.Sign(b_kw) * sq_delta / 2 / a_kw;//(-b_kw - sq_delta) / 2 / a_kw;
             //__x2 = c_kw / a_kw / __x1;//(-b_kw + sq_delta)/2/a_kw;

             __y1 = a_lin * __x1 + b_lin;
             __y2 = a_lin * __x2 + b_lin; // 2 punkty przeciecia dla okregu O1
            if (dist(__x2, __y2, X1, Y1) < dist(__x1, __y1, X1, Y1))
            {
                __x1 = __x2;
                __y1 = __y2;
            }
            Point P2 = new Point((int)__x1, (int)__x2);
            return (P1, P2);
        }

        private void mapa_MouseDown(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (g.Add(e.X, e.Y, g.V.Count, c, r))
                {
                    drawGraph(g);
                }
                else if (selectedVertex != -1)
                {
                    int p = g.getNr(e.X, e.Y, r - 12);
                    if (p != -1 && p != selectedVertex)
                    {

                        g.AddEdge(p, selectedVertex);
                        drawGraph(g);
                    }
                }
                
            }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right) // select wierzcholka
            {
                int t = selectedVertex;
                selectedVertex = g.getNr(e.X, e.Y, r-12);
                if (selectedVertex != -1)
                    removeB.Enabled = true;
                else
                    removeB.Enabled = false;
                if (t != selectedVertex)
                    drawGraph(g);
           }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle) // przesuwanie
            {

            }
        }

        

        private void clearB_Click(object sender, EventArgs e)
        {
            g.Clear();
            selectedVertex = -1;
            //Graphics gr = mapa.CreateGraphics();
            //mapa.Refresh();
            //mapa.Invalidate();
            drawGraph(g);
            //gr.Dispose();
        }

        private void removeB_Click(object sender, EventArgs e)
        {
            if (selectedVertex != -1)
            {
                //Graphics gr = mapa.CreateGraphics();
                g.Remove(selectedVertex);
                selectedVertex = -1;
                //mapa.Invalidate();
                drawGraph(g);
                //gr.Dispose();
            }
        }

        private void mapa_Paint(object sender, PaintEventArgs e)
        {

            //drawGraph(g);
            
        }

        public void drawGraph(Graph g)
        {
            Pen pTmp = new Pen(p.Color, penWidth);
            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            Graphics gr = mapa.CreateGraphics();
           
            Graphics rg = Graphics.FromImage(bmp);
            
            rg.SmoothingMode = SmoothingMode.AntiAlias;
            rg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            rg.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            SolidBrush tmp = new SolidBrush(Color.White);                                                                        
            if (selectedVertex != -1)
                removeB.Enabled = true;
            else
                removeB.Enabled = false;
            foreach (var e in g.E)
            {
                Point p1 = g.getPoint(e.v1);
                Point p2 = g.getPoint(e.v2);
                //(Point P1, Point P2) h = calc(p1.X, p1.Y, p2.X, p2.Y, r);
                rg.DrawLine(edgePen, p1, p2);
            }
            foreach (var v in g.V)
            {
                if (v.nr == selectedVertex)
                {
                    selPen.Color = v.c;
                    rg.DrawEllipse(selPen, v.x - r / 2, v.y - r / 2, r, r);
                    rg.FillEllipse(tmp, v.x - r/2, v.y - r/2, r, r);
                }
                else
                {
                    pTmp.Color = v.c;
                    rg.DrawEllipse(pTmp, v.x - r / 2, v.y - r / 2, r, r);
                    rg.FillEllipse(tmp, v.x - r/2, v.y - r/2, r, r);
                }

                SolidBrush bTmp = new SolidBrush(v.c);
                    rg.DrawString((v.nr + 1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
                    bTmp.Dispose();
                
                //bTmp.Color = v.c;
                //rg.DrawString((v.nr + 1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
                //gr.DrawString((v.nr + 1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
                // bTmp.Dispose();
            }

            
            //mapa.Image = null;
            //mapa.Refresh();
            //if (mapa.Image != null)
            //mapa.Image.Dispose();
            mapa.Image = (Image)bmp.Clone();
            

            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
            gr.Dispose();
            tmp.Dispose();

        }

        private void mapa_Resize(object sender, EventArgs e)
        {
            
        }

        private void mapa_SizeChanged(object sender, EventArgs e)
        {
            
            drawGraph(g);
            //mapa.Invalidate();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && selectedVertex != -1)
            {
                g.fix(selectedVertex);
                drawGraph(g);
            }
        }
    }
}
