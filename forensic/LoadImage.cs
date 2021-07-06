using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forensic
{
    public partial class LoadImage : Form
    {
        public LoadImage()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG|*.jpg;*.jpeg";
                //ofd.Filter = ofd.Filter = "Jpeg Images(*.jpg)|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    orginalpic.ImageLocation = ofd.FileName;
                    orginalpic.BackgroundImageLayout = ImageLayout.Stretch;
                    orginalpic.Dock = DockStyle.Fill;
                    label6.Visible = true;
                    label8.Visible = true;
                    label8.Text = ofd.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error....");
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            
                 try
            {
                System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG|*.jpg;*.jpeg";
               // ofd.Filter= "Jpeg Images(*.jpg)|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    targetpic.ImageLocation = ofd.FileName;
                    targetpic.BackgroundImageLayout = ImageLayout.Stretch;

                    targetpic.Dock = DockStyle.Fill;
                    label7.Visible = true;
                    label9.Visible = true;
                    label9.Text = ofd.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error....");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.orginal = (Bitmap)orginalpic.Image;
            Program.suspected = (Bitmap)targetpic.Image;
            Program.orgpath = orginalpic.ImageLocation;
            Program.targetpath = targetpic.ImageLocation;
            Forensic.Size obj = new Size();
            //Form ob = Form.ActiveForm;
            //Form ob1 = ob.ActiveMdiChild;
            //if (ob1 != null)
            //    ob1.Dispose();
            ActiveForm.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
