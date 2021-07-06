namespace Forensic
{
    partial class histo
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.targetpic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orginalpic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.histogramaDesenat2 = new Forensic.HistogramaDesenat();
            this.histogramaDesenat1 = new Forensic.HistogramaDesenat();
            this.tb = new Forensic.Histogram();
            this.tg = new Forensic.Histogram();
            this.tr = new Forensic.Histogram();
            this.ob = new Forensic.Histogram();
            this.og = new Forensic.Histogram();
            this.or = new Forensic.Histogram();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.targetpic)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orginalpic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Location = new System.Drawing.Point(852, 630);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(331, 91);
            this.panel3.TabIndex = 72;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(331, 91);
            this.splitContainer1.SplitterDistance = 108;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button3);
            this.splitContainer2.Size = new System.Drawing.Size(218, 91);
            this.splitContainer2.SplitterDistance = 109;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Image = global::Forensic.Properties.Resources.play;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 91);
            this.button2.TabIndex = 0;
            this.button2.Text = "Next";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.DimGray;
            this.button3.Image = global::Forensic.Properties.Resources.delete;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 91);
            this.button3.TabIndex = 0;
            this.button3.Text = "Close";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.targetpic);
            this.panel2.Location = new System.Drawing.Point(908, 146);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 304);
            this.panel2.TabIndex = 65;
            // 
            // targetpic
            // 
            this.targetpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetpic.Location = new System.Drawing.Point(0, 0);
            this.targetpic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.targetpic.Name = "targetpic";
            this.targetpic.Size = new System.Drawing.Size(272, 302);
            this.targetpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.targetpic.TabIndex = 2;
            this.targetpic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(1061, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Suspected Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(32, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Orginal Image";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.orginalpic);
            this.panel1.Location = new System.Drawing.Point(35, 145);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 304);
            this.panel1.TabIndex = 60;
            // 
            // orginalpic
            // 
            this.orginalpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orginalpic.Location = new System.Drawing.Point(0, 0);
            this.orginalpic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orginalpic.Name = "orginalpic";
            this.orginalpic.Size = new System.Drawing.Size(272, 302);
            this.orginalpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.orginalpic.TabIndex = 2;
            this.orginalpic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 106);
            this.label1.TabIndex = 58;
            this.label1.Text = "Histogram...";
            // 
            // histogramaDesenat2
            // 
            this.histogramaDesenat2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.histogramaDesenat2.DisplayColor = System.Drawing.Color.White;
            this.histogramaDesenat2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramaDesenat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.histogramaDesenat2.Location = new System.Drawing.Point(908, 471);
            this.histogramaDesenat2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramaDesenat2.Name = "histogramaDesenat2";
            this.histogramaDesenat2.Offset = 20;
            this.histogramaDesenat2.Size = new System.Drawing.Size(277, 146);
            this.histogramaDesenat2.TabIndex = 83;
            // 
            // histogramaDesenat1
            // 
            this.histogramaDesenat1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.histogramaDesenat1.DisplayColor = System.Drawing.Color.White;
            this.histogramaDesenat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramaDesenat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.histogramaDesenat1.Location = new System.Drawing.Point(35, 471);
            this.histogramaDesenat1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.histogramaDesenat1.Name = "histogramaDesenat1";
            this.histogramaDesenat1.Offset = 20;
            this.histogramaDesenat1.Size = new System.Drawing.Size(277, 146);
            this.histogramaDesenat1.TabIndex = 82;
            // 
            // tb
            // 
            this.tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb.Location = new System.Drawing.Point(623, 460);
            this.tb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(277, 146);
            this.tb.TabIndex = 80;
            this.tb.Text = "histogram5";
            // 
            // tg
            // 
            this.tg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tg.Location = new System.Drawing.Point(624, 300);
            this.tg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tg.Name = "tg";
            this.tg.Size = new System.Drawing.Size(277, 146);
            this.tg.TabIndex = 79;
            this.tg.Text = "histogram6";
            // 
            // tr
            // 
            this.tr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tr.Location = new System.Drawing.Point(623, 146);
            this.tr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tr.Name = "tr";
            this.tr.Size = new System.Drawing.Size(277, 146);
            this.tr.TabIndex = 78;
            this.tr.Text = "histogram7";
            this.tr.Click += new System.EventHandler(this.tr_Click);
            // 
            // ob
            // 
            this.ob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ob.Location = new System.Drawing.Point(316, 459);
            this.ob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ob.Name = "ob";
            this.ob.Size = new System.Drawing.Size(277, 146);
            this.ob.TabIndex = 75;
            this.ob.Text = "histogram3";
            // 
            // og
            // 
            this.og.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.og.Location = new System.Drawing.Point(317, 299);
            this.og.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.og.Name = "og";
            this.og.Size = new System.Drawing.Size(277, 146);
            this.og.TabIndex = 74;
            this.og.Text = "histogram2";
            // 
            // or
            // 
            this.or.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.or.Location = new System.Drawing.Point(316, 145);
            this.or.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.or.Name = "or";
            this.or.Size = new System.Drawing.Size(277, 146);
            this.or.TabIndex = 73;
            this.or.Text = "histogram1";
            // 
            // histo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1216, 796);
            this.Controls.Add(this.histogramaDesenat2);
            this.Controls.Add(this.histogramaDesenat1);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.tg);
            this.Controls.Add(this.tr);
            this.Controls.Add(this.ob);
            this.Controls.Add(this.og);
            this.Controls.Add(this.or);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "histo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "histo";
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.targetpic)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orginalpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox orginalpic;
        private System.Windows.Forms.PictureBox targetpic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Histogram or;
        private Histogram og;
        private Histogram ob;
        private Histogram tb;
        private Histogram tg;
        private Histogram tr;
        private HistogramaDesenat histogramaDesenat1;
        private HistogramaDesenat histogramaDesenat2;
    }
}