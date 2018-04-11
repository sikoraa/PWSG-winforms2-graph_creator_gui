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
            this.SetStyle(ControlStyles.DoubleBuffer, true);

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
            }
        }

        private void mapa_MouseEnter(object sender, EventArgs e)
        {
            //mapa.SizeMode = PictureBoxSizeMode.StretchImage;
            mapa.Cursor = Cursors.Cross;
        }

        private void mapa_MouseLeave(object sender, EventArgs e)
        {
            //mapa.SizeMode = PictureBoxSizeMode.Zoom;
            mapa.Cursor = Cursors.Default;
        }

        private void mapa_Click(object sender, EventArgs e)
        {
            //Point local = this.PointToClient(Cursor.Position);
            //Pen p = new Pen(Color.Red, penWidth);
            ////Brush brush = new SolidBrush(mapa.BackgroundColor);
            //Graphics gr = mapa.CreateGraphics();
            ////using (Graphics g = mapa.CreateGraphics())
            ////{
            //    gr.DrawEllipse(p, local.X - r + 1, local.Y - r + 1, r, r);
            //    //mapa.Refresh();
            //    //p.Dispose();
            ////}
        }

       public void drawGraph(Graphics gr, Graph g)
        {
            mapa.Refresh();
            Pen pTmp = new Pen(p.Color, penWidth);
            

            foreach (var v in g.V)
            {
                if (v.nr == selectedVertex)
                {
                    selPen.Color = v.c;
                    gr.DrawEllipse(selPen, v.x - r / 2, v.y - r / 2, r, r);
                }
                else
                {
                    pTmp.Color = v.c;
                    gr.DrawEllipse(pTmp, v.x - r / 2, v.y - r / 2, r, r);
                }
                
                //bTmp.Color = v.c;
                SolidBrush bTmp = new SolidBrush(v.c);
                
                //gr.DrawEllipse(pTmp, v.x - r/2, v.y - r/2, r, r);
                gr.DrawString((v.nr+1).ToString(), f, bTmp, new Point(v.x, v.y), sf);
            }
            
        }

        private void mapa_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics gr = mapa.CreateGraphics();
            gr.SmoothingMode =
            System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (g.Add(e.X, e.Y, g.V.Count, c, r))
                {
                    
                    gr.DrawEllipse(p, e.X - r / 2, e.Y - r / 2, r, r);
                    gr.DrawString(g.V.Count.ToString(), f, b, new Point(e.X, e.Y), sf);
                }
            }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right) // select wierzcholka
            {
                int t = selectedVertex;
                selectedVertex = g.getNr(e.X, e.Y, r + 2);
                if (t != selectedVertex)
                    drawGraph(gr, g);
            }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle) // przesuwanie
            {

            }
        }

        private void mapa_Resize(object sender, EventArgs e)
        {
            Graphics gr = mapa.CreateGraphics();
            drawGraph(gr, g);
        }
    }
}
