using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

//[assembly: AssemblyCulture("")]
//[assembly: NeutralResourcesLanguage("pl-PL")]

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Color c;
        //Graphics gr;
        int r = 28;
        bool moving = false;
        int movingi = -1;
        Stopwatch s1 = new Stopwatch();
        int mousex, mousey;
        string graphLoaded ="";
        string graphLoadFailed = "";
        string graphSaved = "";
        int penWidth;
        Pen p;//= new Pen(Color.Black, penWidth);
        Pen selPen;
        Pen edgePen;


        string[] cultureNames = {  "pl-PL", "en-GB" };
        int cultureindex = 0;
        //CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        ResourceManager rm;//= new ResourceManager("GraphEditor", typeof(Form1).Assembly);
        Assembly assembly;
        //ResourceManager resman;
        


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

            setCulture("pl-PL");
        }

        public bool setCulture(string s)
        {
            CultureInfo ci = new CultureInfo(s);
            //ResourceManager rm = new ResourceManager("WindowsFormsApp2.lang." + s, typeof(Form1).Assembly);
            ResourceManager rm = new ResourceManager("WindowsFormsApp2.GraphEdit", Assembly.GetExecutingAssembly());
            //ResourceManager rm = new ResourceManager("WindowsFormsApp2.lang." + s, typeof(Form1).Assembly);

            this.Text = rm.GetString("Title",ci);
            clearB.Text = rm.GetString("BtnClearGraphText", ci);
            kolorB.Text = rm.GetString("BtnColorChoiceText", ci);
            removeB.Text = rm.GetString("BtnDeleteVertexText",ci);
            angielskiB.Text = rm.GetString("BtnLangEnglishText",ci);
            polskiB.Text = rm.GetString("BtnLangPolishText",ci);
            wczytajB.Text = rm.GetString("BtnLoadText", ci);
            zapiszB.Text = rm.GetString("BtnSaveText", ci);
            importBox.Text = rm.GetString("groupBox1Text", ci);
            edycjaBox.Text = rm.GetString("groupBox2Text", ci);
            jezykBox.Text = rm.GetString("groupBox3Text", ci);
            graphLoaded = rm.GetString("loadedText",ci);
            graphLoadFailed = rm.GetString("loadFailedText",ci);
            graphSaved = rm.GetString("savedText",ci);
            return true;

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
                double min = double.MaxValue;
                selectedVertex = -1;
                for (int i = 0; i < g.V.Count; ++i)
                {
                    double _dist = dist(e.X, e.Y, g.V[i].x, g.V[i].y);
                    if (_dist < r + 3 && _dist < min)
                    {
                        min = _dist;
                        selectedVertex = g.V[i].nr;
                    }

                }
                //if (movingi != -1)
                //{
                //    int p = movingi;
                //    movingi = g.getIndex(selectedVertex);
                //    if (movingi < 0 || movingi > g.V.Count - 1)
                //        movingi = p;
                //}
                //selectedVertex = g.getNr(e.X, e.Y, r); //r-12
                if (selectedVertex != -1)
                    removeB.Enabled = true;
                else
                    removeB.Enabled = false;
                if (t != selectedVertex)
                {
                    if (selectedVertex != -1)
                        movingi = g.getIndex(selectedVertex);
                    else
                    {
                        moving = false;
                        movingi = -1;
                    }
                    drawGraph(g);
                }
           }
            else if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle) // przesuwanie
            {
                if (selectedVertex != -1)
                {
                    if (!moving)
                    {
                        mousex = e.X;
                        mousey = e.Y;
                        s1.Start();
                        moving = true;
                        movingi = selectedVertex;
                    }
                }
            }
        }

        

        private void clearB_Click(object sender, EventArgs e)
        {
            g.Clear();
            selectedVertex = -1;
            drawGraph(g);
        }

        private void removeB_Click(object sender, EventArgs e)
        {
            if (selectedVertex != -1)
            {
                s1.Stop();
                moving = false;
                g.Remove(selectedVertex);
                selectedVertex = -1;
                drawGraph(g);
            }
        }

        private void mapa_Paint(object sender, PaintEventArgs e)
        { }

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
             }
            if (mapa.Image != null)
                mapa.Image.Dispose();
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
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete && selectedVertex != -1)
            {
                s1.Stop();
                moving = false;
                g.fix(selectedVertex);
                selectedVertex = -1;
                drawGraph(g);
            }
            
        }

        private void zapiszB_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            saveFileDialog1.Filter = "Graph files (*.graph)|*.graph";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        {

                            myStream.Close();
                            g.Export(saveFileDialog1.FileName);
                            MessageBox.Show(graphSaved);
                            //myStream.Close();
                            
                        }
                    }
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    ;
                    //MessageBox.Show(Error)
                    //MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }
            }
        }

        private void wczytajB_Click(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog1.Filter = "Graph files (*.graph)|*.graph";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        string ext = Path.GetExtension(openFileDialog1.FileName);
                        if (ext != ".graph")
                        {
                            MessageBox.Show(graphLoadFailed);
                            //MessageBox.Show("Error: Opened file doesn't have .graph extension.");
                            return;

                        }
                        using (myStream)
                        {

                            //this.Text = "lol";
                            //openFileDialog1.
                            g = Graph.Import(openFileDialog1.FileName);
                            selectedVertex = -1;
                            drawGraph(g);
                            //myStream.Close();
                            MessageBox.Show(graphLoaded);
                        }
                        myStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(graphLoadFailed);
                    //MessageBox.Show("ex");

                    //MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }

        private void polskiB_Click(object sender, EventArgs e)
        {
            setCulture("pl-PL");

        }

        private void angielskiB_Click(object sender, EventArgs e)
        {
            setCulture("en-GB");

        }

        private void mapa_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && s1.ElapsedMilliseconds > 10)
            {
                int x = e.X;
                int y = e.Y;
                int dx = e.X - mousex;
                int dy = e.Y - mousey;
                //g.V[movingi] = (x, y, g.V[movingi].nr, g.V[movingi].c);
                g.V[movingi] = (g.V[movingi].x+dx, g.V[movingi].y + dy, g.V[movingi].nr, g.V[movingi].c);
                drawGraph(g);
                mousex = e.X;
                mousey = e.Y;
                s1.Reset();
                s1.Start();
                //s1.Stop();
                //s1.Start();
            }
        }

        private void mapa_MouseUp(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Middle && moving)
            {
                moving = false;
                int x = g.V[movingi].x, y = g.V[movingi].y;
                if (g.V[movingi].x < 0) x = 0;
                else if (g.V[movingi].x > mapa.Width) x = mapa.Width;
                if (g.V[movingi].y < 0) y = 0;
                else if (g.V[movingi].y > mapa.Height) y = mapa.Height;
                g.V[movingi] = (x, y, g.V[movingi].nr, g.V[movingi].c);
                movingi = -1;
                s1.Stop();
                drawGraph(g);
                
            }
        }
    }
}
