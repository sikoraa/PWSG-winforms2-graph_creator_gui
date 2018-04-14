namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mapa = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.importBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.wczytajB = new System.Windows.Forms.Button();
            this.zapiszB = new System.Windows.Forms.Button();
            this.jezykBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.angielskiB = new System.Windows.Forms.Button();
            this.polskiB = new System.Windows.Forms.Button();
            this.edycjaBox = new System.Windows.Forms.GroupBox();
            this.clearB = new System.Windows.Forms.Button();
            this.removeB = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kolorB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.importBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.jezykBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.edycjaBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapa);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.TabStop = false;
            // 
            // mapa
            // 
            resources.ApplyResources(this.mapa, "mapa");
            this.mapa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapa.Name = "mapa";
            this.mapa.TabStop = false;
            this.mapa.SizeChanged += new System.EventHandler(this.mapa_SizeChanged);
            this.mapa.Paint += new System.Windows.Forms.PaintEventHandler(this.mapa_Paint);
            this.mapa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapa_MouseDown);
            this.mapa.MouseEnter += new System.EventHandler(this.mapa_MouseEnter);
            this.mapa.MouseLeave += new System.EventHandler(this.mapa_MouseLeave);
            this.mapa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapa_MouseMove);
            this.mapa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapa_MouseUp);
            this.mapa.Resize += new System.EventHandler(this.mapa_Resize);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.Controls.Add(this.importBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.jezykBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.edycjaBox, 0, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // importBox
            // 
            resources.ApplyResources(this.importBox, "importBox");
            this.importBox.Controls.Add(this.tableLayoutPanel4);
            this.importBox.Name = "importBox";
            this.importBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.wczytajB, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.zapiszB, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // wczytajB
            // 
            resources.ApplyResources(this.wczytajB, "wczytajB");
            this.wczytajB.Name = "wczytajB";
            this.wczytajB.UseVisualStyleBackColor = true;
            this.wczytajB.Click += new System.EventHandler(this.wczytajB_Click);
            // 
            // zapiszB
            // 
            resources.ApplyResources(this.zapiszB, "zapiszB");
            this.zapiszB.Name = "zapiszB";
            this.zapiszB.UseVisualStyleBackColor = true;
            this.zapiszB.Click += new System.EventHandler(this.zapiszB_Click);
            // 
            // jezykBox
            // 
            resources.ApplyResources(this.jezykBox, "jezykBox");
            this.jezykBox.Controls.Add(this.tableLayoutPanel3);
            this.jezykBox.Name = "jezykBox";
            this.jezykBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.angielskiB, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.polskiB, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // angielskiB
            // 
            resources.ApplyResources(this.angielskiB, "angielskiB");
            this.angielskiB.Name = "angielskiB";
            this.angielskiB.UseVisualStyleBackColor = true;
            this.angielskiB.Click += new System.EventHandler(this.angielskiB_Click);
            // 
            // polskiB
            // 
            resources.ApplyResources(this.polskiB, "polskiB");
            this.polskiB.Name = "polskiB";
            this.polskiB.UseVisualStyleBackColor = true;
            this.polskiB.Click += new System.EventHandler(this.polskiB_Click);
            // 
            // edycjaBox
            // 
            resources.ApplyResources(this.edycjaBox, "edycjaBox");
            this.edycjaBox.Controls.Add(this.clearB);
            this.edycjaBox.Controls.Add(this.removeB);
            this.edycjaBox.Controls.Add(this.tableLayoutPanel2);
            this.edycjaBox.Name = "edycjaBox";
            this.edycjaBox.TabStop = false;
            // 
            // clearB
            // 
            resources.ApplyResources(this.clearB, "clearB");
            this.clearB.Name = "clearB";
            this.clearB.UseVisualStyleBackColor = true;
            this.clearB.Click += new System.EventHandler(this.clearB_Click);
            // 
            // removeB
            // 
            resources.ApplyResources(this.removeB, "removeB");
            this.removeB.Name = "removeB";
            this.removeB.UseVisualStyleBackColor = true;
            this.removeB.Click += new System.EventHandler(this.removeB_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.kolorB, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // kolorB
            // 
            resources.ApplyResources(this.kolorB, "kolorB");
            this.kolorB.Name = "kolorB";
            this.kolorB.UseVisualStyleBackColor = true;
            this.kolorB.Click += new System.EventHandler(this.kolorB_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.importBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.jezykBox.ResumeLayout(false);
            this.jezykBox.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.edycjaBox.ResumeLayout(false);
            this.edycjaBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button angielskiB;
        private System.Windows.Forms.Button polskiB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button wczytajB;
        private System.Windows.Forms.Button zapiszB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button kolorB;
        private System.Windows.Forms.GroupBox edycjaBox;
        private System.Windows.Forms.GroupBox jezykBox;
        private System.Windows.Forms.GroupBox importBox;
        private System.Windows.Forms.PictureBox mapa;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.Button removeB;
    }
}

