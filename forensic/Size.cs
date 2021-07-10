using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI;



namespace Forensic
{
    public partial class Size : Form
    {
        public static double s1, s2;
        ImageHandler imageHandler = new ImageHandler();
        public Size()
        {
            InitializeComponent();
            orginalpic.Image = (Image)Program.orginal;
            targetpic.Image = (Image)Program.suspected;
            information();
            information2();
            check();
        }

        public void check()
        {
            int c = 0;
            if (lblImageExtension.Text != lblImageExtension2.Text)
            {
              
                Program.results = Program.results +"0"+ "$";
            }
            else
            {
            
                Program.results = Program.results + "1" + "$";
            }
            if (lblImageDimension.Text != lblImageDimension2.Text)
            {
             
                Program.results = Program.results + "0" + "$";
            }
            else
            {
              
                Program.results = Program.results + "1" + "$";
            }
           
            if (lblImageCreatedOn.Text != lblImageCreatedOn2.Text)
            {
             
              Program.results = Program.results + "0" + "$";
            }
            else
            {
             
                Program.results = Program.results + "1" + "$";
            }
           
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Baseform obj = new Baseform();
          
            ActiveForm.Hide();
            obj.Show();
        }

        public void information2()
        {
            imageHandler.CurrentBitmap = Program.suspected;
            imageHandler.BitmapPath = Program.targetpath;
            imageinfo2(imageHandler);
        }
        public void information()
        {
            imageHandler.CurrentBitmap = Program.orginal;
            imageHandler.BitmapPath = Program.orgpath;
            imageinfo(imageHandler);
        }

        public void imageinfo(ImageHandler h)
        {
            FileInfo fileInfo = new FileInfo(h.BitmapPath);
            lblImageName.Text = fileInfo.Name.Replace(fileInfo.Extension, "");
            lblImageExtension.Text = fileInfo.Extension;
            string loc = fileInfo.DirectoryName;
            if (loc.Length > 50)
                loc = loc.Substring(0, 15) + "..." + loc.Substring(loc.LastIndexOf("\\"));
            lblImageLocation.Text = loc;
            lblImageDimension.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
            s1= fileInfo.Length / 1024.0;
            lblImageCreatedOn.Text = fileInfo.CreationTime.ToString("dddd MMMM dd, yyyy");

        }

        public void imageinfo2(ImageHandler h)
        {
            FileInfo fileInfo = new FileInfo(h.BitmapPath);
            lblImageName2.Text = fileInfo.Name.Replace(fileInfo.Extension, "");
            lblImageExtension2.Text = fileInfo.Extension;
            string loc = fileInfo.DirectoryName;
            if (loc.Length > 50)
                loc = loc.Substring(0, 15) + "..." + loc.Substring(loc.LastIndexOf("\\"));
            lblImageLocation2.Text = loc;
            lblImageDimension2.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
            s2 = fileInfo.Length / 1024.0;
            lblImageCreatedOn2.Text = fileInfo.CreationTime.ToString("dddd MMMM dd, yyyy");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (s1 == s2)
            {
                Program.size = "s";
            }
            else
            {
                Program.size = "n";
            }
            histo obj = new histo();
            ActiveForm.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Extract obj = new Extract();
            obj.Show();
        }
    }
}
