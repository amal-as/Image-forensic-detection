namespace ImageForensic
{
    partial class Embedd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_max_amt_data1 = new System.Windows.Forms.Label();
            this.lb_space1 = new System.Windows.Forms.Label();
            this.lb_img_size1 = new System.Windows.Forms.Label();
            this.lb_max_amt_data = new System.Windows.Forms.Label();
            this.lb_space = new System.Windows.Forms.Label();
            this.lb_img_size = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Bt_embbd = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.histogramaDesenat1 = new ImageForensic.HistogramaDesenat();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.DCTMapImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCTMapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_max_amt_data1);
            this.groupBox1.Controls.Add(this.lb_space1);
            this.groupBox1.Controls.Add(this.lb_img_size1);
            this.groupBox1.Controls.Add(this.lb_max_amt_data);
            this.groupBox1.Controls.Add(this.lb_space);
            this.groupBox1.Controls.Add(this.lb_img_size);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(358, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_max_amt_data1
            // 
            this.lb_max_amt_data1.AutoSize = true;
            this.lb_max_amt_data1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_max_amt_data1.ForeColor = System.Drawing.Color.White;
            this.lb_max_amt_data1.Location = new System.Drawing.Point(132, 94);
            this.lb_max_amt_data1.Name = "lb_max_amt_data1";
            this.lb_max_amt_data1.Size = new System.Drawing.Size(0, 13);
            this.lb_max_amt_data1.TabIndex = 5;
            this.lb_max_amt_data1.Visible = false;
            this.lb_max_amt_data1.Click += new System.EventHandler(this.lb_max_amt_data1_Click);
            // 
            // lb_space1
            // 
            this.lb_space1.AutoSize = true;
            this.lb_space1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_space1.ForeColor = System.Drawing.Color.White;
            this.lb_space1.Location = new System.Drawing.Point(101, 65);
            this.lb_space1.Name = "lb_space1";
            this.lb_space1.Size = new System.Drawing.Size(0, 13);
            this.lb_space1.TabIndex = 4;
            this.lb_space1.Visible = false;
            // 
            // lb_img_size1
            // 
            this.lb_img_size1.AutoSize = true;
            this.lb_img_size1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_img_size1.ForeColor = System.Drawing.Color.White;
            this.lb_img_size1.Location = new System.Drawing.Point(87, 34);
            this.lb_img_size1.Name = "lb_img_size1";
            this.lb_img_size1.Size = new System.Drawing.Size(0, 13);
            this.lb_img_size1.TabIndex = 3;
            this.lb_img_size1.Visible = false;
            // 
            // lb_max_amt_data
            // 
            this.lb_max_amt_data.AutoSize = true;
            this.lb_max_amt_data.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_max_amt_data.ForeColor = System.Drawing.Color.White;
            this.lb_max_amt_data.Location = new System.Drawing.Point(10, 95);
            this.lb_max_amt_data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_max_amt_data.Name = "lb_max_amt_data";
            this.lb_max_amt_data.Size = new System.Drawing.Size(106, 13);
            this.lb_max_amt_data.TabIndex = 2;
            this.lb_max_amt_data.Text = "Max. amount of Data :";
            // 
            // lb_space
            // 
            this.lb_space.AutoSize = true;
            this.lb_space.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_space.ForeColor = System.Drawing.Color.White;
            this.lb_space.Location = new System.Drawing.Point(10, 65);
            this.lb_space.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_space.Name = "lb_space";
            this.lb_space.Size = new System.Drawing.Size(78, 13);
            this.lb_space.TabIndex = 1;
            this.lb_space.Text = "Possible Space :";
            // 
            // lb_img_size
            // 
            this.lb_img_size.AutoSize = true;
            this.lb_img_size.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_img_size.ForeColor = System.Drawing.Color.White;
            this.lb_img_size.Location = new System.Drawing.Point(10, 34);
            this.lb_img_size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_img_size.Name = "lb_img_size";
            this.lb_img_size.Size = new System.Drawing.Size(61, 13);
            this.lb_img_size.TabIndex = 0;
            this.lb_img_size.Text = "Image Size :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Select File :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tb_file
            // 
            this.tb_file.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_file.Location = new System.Drawing.Point(9, 75);
            this.tb_file.Margin = new System.Windows.Forms.Padding(2);
            this.tb_file.Multiline = true;
            this.tb_file.Name = "tb_file";
            this.tb_file.Size = new System.Drawing.Size(277, 26);
            this.tb_file.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Embedd here....";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(177)))), ((int)(((byte)(53)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(122, 137);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 39);
            this.button3.TabIndex = 1;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Bt_embbd
            // 
            this.Bt_embbd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(177)))), ((int)(((byte)(53)))));
            this.Bt_embbd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bt_embbd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_embbd.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_embbd.ForeColor = System.Drawing.Color.White;
            this.Bt_embbd.Location = new System.Drawing.Point(11, 138);
            this.Bt_embbd.Margin = new System.Windows.Forms.Padding(2);
            this.Bt_embbd.Name = "Bt_embbd";
            this.Bt_embbd.Size = new System.Drawing.Size(100, 39);
            this.Bt_embbd.TabIndex = 1;
            this.Bt_embbd.Text = "Embedd";
            this.Bt_embbd.UseVisualStyleBackColor = false;
            this.Bt_embbd.Click += new System.EventHandler(this.Bt_embbd_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(177)))), ((int)(((byte)(53)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::ImageForensic.Properties.Resources.search;
            this.button4.Location = new System.Drawing.Point(294, 64);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 42);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(582, 341);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(177)))), ((int)(((byte)(53)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(232, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 38);
            this.button5.TabIndex = 14;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(944, 663);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.TabIndex = 16;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Bt_embbd);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.button3);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.button5);
            this.splitContainer3.Panel1.Controls.Add(this.button4);
            this.splitContainer3.Panel1.Controls.Add(this.tb_file);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(358, 663);
            this.splitContainer3.SplitterDistance = 213;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer4.Size = new System.Drawing.Size(358, 446);
            this.splitContainer4.SplitterDistance = 108;
            this.splitContainer4.TabIndex = 0;
            // 
            // histogramaDesenat1
            // 
            this.histogramaDesenat1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.histogramaDesenat1.DisplayColor = System.Drawing.Color.Black;
            this.histogramaDesenat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramaDesenat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramaDesenat1.Location = new System.Drawing.Point(0, 0);
            this.histogramaDesenat1.Name = "histogramaDesenat1";
            this.histogramaDesenat1.Offset = 20;
            this.histogramaDesenat1.Size = new System.Drawing.Size(290, 318);
            this.histogramaDesenat1.TabIndex = 15;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(76)))), ((int)(((byte)(135)))));
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(582, 663);
            this.splitContainer2.SplitterDistance = 341;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.DCTMapImage);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.histogramaDesenat1);
            this.splitContainer5.Size = new System.Drawing.Size(582, 318);
            this.splitContainer5.SplitterDistance = 288;
            this.splitContainer5.TabIndex = 0;
            // 
            // DCTMapImage
            // 
            this.DCTMapImage.BackColor = System.Drawing.Color.Transparent;
            this.DCTMapImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DCTMapImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DCTMapImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCTMapImage.Location = new System.Drawing.Point(0, 0);
            this.DCTMapImage.Margin = new System.Windows.Forms.Padding(2);
            this.DCTMapImage.Name = "DCTMapImage";
            this.DCTMapImage.Size = new System.Drawing.Size(288, 318);
            this.DCTMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DCTMapImage.TabIndex = 5;
            this.DCTMapImage.TabStop = false;
            // 
            // Embedd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(76)))), ((int)(((byte)(135)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 663);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Embedd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embedd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DCTMapImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_img_size;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lb_max_amt_data;
        private System.Windows.Forms.Label lb_space;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label lb_max_amt_data1;
        private System.Windows.Forms.Label lb_space1;
        private System.Windows.Forms.Label lb_img_size1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        protected System.Windows.Forms.Button Bt_embbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private HistogramaDesenat histogramaDesenat1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.PictureBox DCTMapImage;


    }
}