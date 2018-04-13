using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            grr = mapa.CreateGraphics();
            this.SetStyle(
    ControlStyles.AllPaintingInWmPaint |
    ControlStyles.UserPaint |
    ControlStyles.DoubleBuffer,
    true);

   //         typeof(Panel).InvokeMember("DoubleBuffered",
   //BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
   //null, DrawingPanel, new object[] { true });

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
                    //drawGraph();
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
    
       public void drawGraph(Graphics gr, Graph g)
        {
            //mapa.Refresh();
            
            Pen pTmp = new Pen(p.Color, penWidth);
            //Bitmap bmp = new Bitmap(mapa.Image);
            //Graphics rg = Graphics.FromImage(bmp);
            //var rg = mapa.CreateGraphics();

            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            Graphics rg = Graphics.FromImage(bmp);
            foreach (var v in g.V)
            {
                if (v.nr == selectedVertex)
                {
                    selPen.Color = v.c;
                    //gr.DrawEllipse(selPen, v.x - r / 2, v.y - r / 2, r, r);
                    rg.DrawEllipse(selPen, v.x - r / 2, v.y - r / 2, r, r);

                }
                else
                {
                    pTmp.Color = v.c;
                    //gr.DrawEllipse(pTmp, v.x - r / 2, v.y - r / 2, r, r);
                    rg.DrawEllipse(pTmp, v.x - r / 2, v.y - r / 2, r, r);

                }
                SolidBrush bTmp = new SolidBrush(v.c);
                //gr.DrawString((v.nr+1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
                rg.DrawString((v.nr + 1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
                //bTmp.Dispose();
            }
            mapa.Image = null;
            mapa.Image = (Image)bmp.Clone();
            mapa.Refresh();
            bmp.Dispose();
            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
        }

        private void mapa_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics gr = mapa.CreateGraphics();
            //gr.SmoothingMode =
            //System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (g.Add(e.X, e.Y, g.V.Count, c, r))
                {
                    mapa.Invalidate();
                    //gr.DrawEllipse(p, e.X - r / 2, e.Y - r / 2, r, r);
                    //gr.DrawString(g.V.Count.ToString(), f, b, new Point(e.X, e.Y), sf);
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
                    //mapa.Invalidate();
                    mapa.Invalidate();

                //drawGraph(g);

            }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle) // przesuwanie
            {

            }
            gr.Dispose();
        }

        

        private void clearB_Click(object sender, EventArgs e)
        {
            g.Clear();
            selectedVertex = -1;
            Graphics gr = mapa.CreateGraphics();
            mapa.Invalidate();
            //drawGraph(gr, g);
            gr.Dispose();
        }

        private void removeB_Click(object sender, EventArgs e)
        {
            if (selectedVertex != -1)
            {
                Graphics gr = mapa.CreateGraphics();
                g.Remove(selectedVertex);
                selectedVertex = -1;
                mapa.Invalidate();
                //drawGraph(gr, g);
                gr.Dispose();
            }
        }

        private void mapa_Paint(object sender, PaintEventArgs e)
        {

            //Graphics gr = e.Graphics;
            //drawGraph(gr, g);
            //drawGraph(g);
            //Graphics gr = mapa.CreateGraphics();
            //drawGraph(grr, g);
            
            
            //Graphics gr = mapa.CreateGraphics();
            ////var img =
            //using (Bitmap bitmap = new Bitmap(mapa.Width, mapa.Height))
            //{
            //    using (Graphics gx = Graphics.FromImage(bitmap))
            //    {
            //        Graphics g = mapa.CreateGraphics();
            //        e.Graphics.DrawImage(bitmap, 0, 0);
            //    }
            //}
            //drawGraph(gr, g);
        }

        public void drawGraph(Graph g)
        {
            Pen pTmp = new Pen(p.Color, penWidth);
            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            
            Graphics rg = Graphics.FromImage(bmp);
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
                rg.DrawString((v.nr + 1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
            }
            mapa.Image = null;
            mapa.Image = (Image)bmp.Clone();
            mapa.Refresh();
            bmp.Dispose();
            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
        }

        private void mapa_Resize(object sender, EventArgs e)
        {
            //Graphics gr = mapa.CreateGraphics();
            //mapa.Invalidate();
            //drawGraph(gr, g);
            //gr.Dispose();

            //var image = new Bitmap(mapa.ClientRectangle.Width, mapa.ClientRectangle.Height);
            //mapa.Image = image;
        }

        private void mapa_SizeChanged(object sender, EventArgs e)
        {
            mapa.Invalidate();
        }
    }
}
