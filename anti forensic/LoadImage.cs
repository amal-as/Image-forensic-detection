using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageForensic
{
    public partial class LoadImage : Form
    {
        public static string loadedfile = "";
        public LoadImage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog();
               // ofd.Filter = ofd.Filter = "Jpeg Images(*.jpg)|*.jpg";
                ofd.Filter = "JPG|*.jpg;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    orginalpic.ImageLocation = ofd.FileName;
                    orginalpic.BackgroundImageLayout = ImageLayout.Stretch;
                    textBox1.Text = ofd.FileName;
                    loadedfile = ofd.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error....");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1(loadedfile);
            Program.orginal = (Bitmap)orginalpic.Image;
            ActiveForm.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Embedd obj = new Embedd(orginalpic.ImageLocation.ToString(), (Bitmap)orginalpic.Image);
            Program.orginal = (Bitmap)orginalpic.Image;
           // ActiveForm.Hide();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
