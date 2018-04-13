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
        Graphics grr;

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
    

        private void mapa_MouseDown(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (g.Add(e.X, e.Y, g.V.Count, c, r))
                {
                    drawGraph(g);    
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
            Graphics gr = mapa.CreateGraphics();
            //mapa.Refresh();
            //mapa.Invalidate();
            drawGraph(g);
            gr.Dispose();
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
            //rg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            rg.SmoothingMode = SmoothingMode.AntiAlias;
            rg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;//TextRenderingHint.TextRenderingHint.AntiAliasGridFit; //ClearTypeGridFit;
            //rg.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //rg.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //rg.PixelOffsetMode = PixelOffsetMode.HighQuality;
            foreach (var v in g.V)
            {
                if (v.nr == selectedVertex)
                {
                    selPen.Color = v.c;
                    rg.DrawEllipse(selPen, v.x - r / 2, v.y - r / 2, r, r);

                }
                else
                {
                    pTmp.Color = v.c;
                    rg.DrawEllipse(pTmp, v.x - r / 2, v.y - r / 2, r, r);

                }
                
                    SolidBrush bTmp = new SolidBrush(v.c);
                    //bTmp.Color = v.c;
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
            //bTmp.Dispose();
            //rg.Dispose();
            //bmp.Dispose();
            //gr.Dispose();
            
        }

        private void mapa_Resize(object sender, EventArgs e)
        {
            
        }

        private void mapa_SizeChanged(object sender, EventArgs e)
        {
            
            drawGraph(g);
            //mapa.Invalidate();
        }
    }
}
