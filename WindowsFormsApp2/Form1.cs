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
        Color c = new Color();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void jezykBox_Enter(object sender, EventArgs e)
        {

        }

        private void kolorB_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            //MyDialog.Color = textBox1.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                c = MyDialog.Color;
                pictureBox1.BackColor = c;
            }
        }

        private void mapa_MouseEnter(object sender, EventArgs e)
        {
            mapa.SizeMode = PictureBoxSizeMode.StretchImage;
            mapa.Cursor = Cursors.Cross;
        }

        private void mapa_MouseLeave(object sender, EventArgs e)
        {
            mapa.SizeMode = PictureBoxSizeMode.Zoom;
            mapa.Cursor = Cursors.Default;
        }

        private void mapa_Click(object sender, EventArgs e)
        {
            Point local = this.PointToClient(Cursor.Position);
            Pen p = new Pen(Color.Red, 10);
            //Brush brush = new SolidBrush(mapa.BackgroundColor);

            using (Graphics g = mapa.CreateGraphics())
            {
                g.DrawEllipse(p, local.X - 25, local.Y - 25, 20, 20);
                mapa.Refresh();
                p.Dispose();
            }
        }

        private void mapa_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
