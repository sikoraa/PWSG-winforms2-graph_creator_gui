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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapa);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 562);
            this.splitContainer1.SplitterDistance = 640;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // mapa
            // 
            this.mapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapa.Location = new System.Drawing.Point(12, 12);
            this.mapa.Name = "mapa";
            this.mapa.Size = new System.Drawing.Size(611, 538);
            this.mapa.TabIndex = 0;
            this.mapa.TabStop = false;
            this.mapa.Click += new System.EventHandler(this.mapa_Click);
            this.mapa.Paint += new System.Windows.Forms.PaintEventHandler(this.mapa_Paint);
            this.mapa.MouseEnter += new System.EventHandler(this.mapa_MouseEnter);
            this.mapa.MouseLeave += new System.EventHandler(this.mapa_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.importBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.jezykBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.edycjaBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(140, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            //this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // importBox
            // 
            this.importBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importBox.Controls.Add(this.tableLayoutPanel4);
            this.importBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importBox.Location = new System.Drawing.Point(5, 483);
            this.importBox.Name = "importBox";
            this.importBox.Size = new System.Drawing.Size(136, 74);
            this.importBox.TabIndex = 1;
            this.importBox.TabStop = false;
            this.importBox.Text = "Import/Eksport";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.wczytajB, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.zapiszB, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(130, 55);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // wczytajB
            // 
            this.wczytajB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wczytajB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wczytajB.Enabled = false;
            this.wczytajB.Location = new System.Drawing.Point(3, 30);
            this.wczytajB.Name = "wczytajB";
            this.wczytajB.Size = new System.Drawing.Size(128, 22);
            this.wczytajB.TabIndex = 1;
            this.wczytajB.Text = "Wczytaj";
            this.wczytajB.UseVisualStyleBackColor = true;
            // 
            // zapiszB
            // 
            this.zapiszB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zapiszB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zapiszB.Enabled = false;
            this.zapiszB.Location = new System.Drawing.Point(3, 3);
            this.zapiszB.Name = "zapiszB";
            this.zapiszB.Size = new System.Drawing.Size(128, 21);
            this.zapiszB.TabIndex = 0;
            this.zapiszB.Text = "Zapisz";
            this.zapiszB.UseVisualStyleBackColor = true;
            // 
            // jezykBox
            // 
            this.jezykBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.jezykBox.Controls.Add(this.tableLayoutPanel3);
            this.jezykBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jezykBox.Location = new System.Drawing.Point(5, 401);
            this.jezykBox.Name = "jezykBox";
            this.jezykBox.Size = new System.Drawing.Size(136, 74);
            this.jezykBox.TabIndex = 0;
            this.jezykBox.TabStop = false;
            this.jezykBox.Text = "Język";
            this.jezykBox.Enter += new System.EventHandler(this.jezykBox_Enter);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.Controls.Add(this.angielskiB, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.polskiB, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(130, 55);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // angielskiB
            // 
            this.angielskiB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.angielskiB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.angielskiB.Enabled = false;
            this.angielskiB.Location = new System.Drawing.Point(3, 30);
            this.angielskiB.Name = "angielskiB";
            this.angielskiB.Size = new System.Drawing.Size(124, 22);
            this.angielskiB.TabIndex = 1;
            this.angielskiB.Text = "Angielski";
            this.angielskiB.UseVisualStyleBackColor = true;
            // 
            // polskiB
            // 
            this.polskiB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.polskiB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polskiB.Enabled = false;
            this.polskiB.Location = new System.Drawing.Point(3, 3);
            this.polskiB.Name = "polskiB";
            this.polskiB.Size = new System.Drawing.Size(124, 21);
            this.polskiB.TabIndex = 0;
            this.polskiB.Text = "Polski";
            this.polskiB.UseVisualStyleBackColor = true;
            // 
            // edycjaBox
            // 
            this.edycjaBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edycjaBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.edycjaBox.Controls.Add(this.tableLayoutPanel2);
            this.edycjaBox.Location = new System.Drawing.Point(5, 5);
            this.edycjaBox.Name = "edycjaBox";
            this.edycjaBox.Size = new System.Drawing.Size(136, 388);
            this.edycjaBox.TabIndex = 0;
            this.edycjaBox.TabStop = false;
            this.edycjaBox.Text = "Edycja";
            //this.edycjaBox.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.kolorB, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(115, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(95, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 23);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kolorB
            // 
            this.kolorB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kolorB.AutoSize = true;
            this.kolorB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kolorB.Location = new System.Drawing.Point(3, 3);
            this.kolorB.Name = "kolorB";
            this.kolorB.Size = new System.Drawing.Size(86, 23);
            this.kolorB.TabIndex = 0;
            this.kolorB.Text = "Kolor";
            this.kolorB.UseVisualStyleBackColor = true;
            this.kolorB.Click += new System.EventHandler(this.kolorB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edytor Grafów1";
            this.splitContainer1.Panel1.ResumeLayout(false);
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
    }
}

