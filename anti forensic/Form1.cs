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
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;



namespace ImageForensic
{
    public partial class Form1 : Form
    {
        ImageHandler imageHandler = new ImageHandler();

        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),};

        private AForge.Math.Histogram activeHistogram = null;
        private int currentImageHash = 0;
        private ImageStatistics stat;

        private IntRange red = new IntRange(0, 255);
        private IntRange green = new IntRange(0, 255);
        private IntRange blue = new IntRange(0, 255);

        System.Drawing.Bitmap image = null;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string filepath)
        {
            InitializeComponent();
            orginalpic.ImageLocation = filepath;
            orginalpic.BackgroundImageLayout = ImageLayout.Stretch;

            try
            {
            imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(filepath);
            imageHandler.BitmapPath = filepath;
            imageinfo(imageHandler);
            GatherStatistics((Bitmap)Bitmap.FromFile(filepath));
            GatherStatistics1((Bitmap)(graypicture.Image));

            ApplyFilterRed(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0)), (Bitmap)Bitmap.FromFile(filepath));
            ApplyFilterGreen(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0)), (Bitmap)Bitmap.FromFile(filepath));
            ApplyFilterBlue(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255)), (Bitmap)Bitmap.FromFile(filepath));

            Grayscale((Bitmap)Bitmap.FromFile(filepath));
            }
            catch (Exception ex)
            {
                MessageBox.Show("error....");
            }
        }

        //...............................load image................................-------------------.

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Windows.Forms.OpenFileDialog ofd = new OpenFileDialog(); 
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        orginalpic.ImageLocation = ofd.FileName;
            //        orginalpic.BackgroundImageLayout = ImageLayout.Stretch;

            //        imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(ofd.FileName);
            //        imageHandler.BitmapPath = ofd.FileName;
            //        imageinfo(imageHandler);
            //        GatherStatistics((Bitmap)Bitmap.FromFile(ofd.FileName));
            //        GatherStatistics1((Bitmap)(graypicture.Image));

            //        ApplyFilterRed(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0)), (Bitmap)Bitmap.FromFile(ofd.FileName));
            //        ApplyFilterGreen(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0)), (Bitmap)Bitmap.FromFile(ofd.FileName));
            //        ApplyFilterBlue(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255)), (Bitmap)Bitmap.FromFile(ofd.FileName));
            //        Grayscale((Bitmap)Bitmap.FromFile(ofd.FileName));
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error....");
            //}
        }

        //----------------------------info for the picture----------------------------------------------

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
            lblImageSize.Text = (fileInfo.Length / 1024.0).ToString("0.0") + " KB";
            lblImageCreatedOn.Text = fileInfo.CreationTime.ToString("dddd MMMM dd, yyyy");

        }

        //---------------------------------histogramz----------------------------------------------------

        public void GatherStatistics(Bitmap image)
        {
            // avoid calculation in the case of the same image
            if (image != null)
            {
                if (currentImageHash == image.GetHashCode())
                    return;
                currentImageHash = image.GetHashCode();
            }

            if (image != null)
                System.Diagnostics.Debug.WriteLine("=== Gathering histogram");

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            stat = (image == null) ? null : new ImageStatistics(image);

            // free
            Cursor = Cursors.Arrow;
            Capture = false;

         
            if (stat != null)
            {
                if (!stat.IsGrayscale)
                {
                    histogram2.Color = colors[0];
                    activeHistogram = null;
                    activeHistogram = stat.Red;
                    histogram2.Values = activeHistogram.Values;

                    activeHistogram = null;
                    histogram3.Color = colors[1];
                    activeHistogram = stat.Green;
                    histogram3.Values = activeHistogram.Values;

                    activeHistogram = null;
                    histogram4.Color = colors[2];
                    activeHistogram = stat.Blue;
                    histogram4.Values = activeHistogram.Values;

                   

                }
                else
                {
                    activeHistogram = null;
                    histogram1.Color = colors[3];
                    activeHistogram = stat.Gray;
                    histogram1.Values = activeHistogram.Values;
                }
            
            }
            else
            {
              
            }
        }

        public void GatherStatistics1(Bitmap image)
        {
            // avoid calculation in the case of the same image
            if (image != null)
            {
                if (currentImageHash == image.GetHashCode())
                    return;
                currentImageHash = image.GetHashCode();
            }

            if (image != null)
                System.Diagnostics.Debug.WriteLine("=== Gathering histogram");

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            stat = (image == null) ? null : new ImageStatistics(image);

            // free
            Cursor = Cursors.Arrow;
            Capture = false;


            if (stat != null)
            {
                if (!stat.IsGrayscale)
                {
                    
                }
                else
                {
                    activeHistogram = null;
                    histogram1.Color = colors[3];
                    activeHistogram = stat.Gray;
                    histogram1.Values = activeHistogram.Values;
                }

            }
            else
            {

            }
        }

        //------------------------------ Apply filter on the image----------------------------------------

        private void ApplyFilterRed(IFilter filter,Bitmap image)
        {
            try
            {
               

                // apply filter to the image
                Bitmap newImage = filter.Apply(image);
                redpicture.Image = newImage;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }
        }

        private void ApplyFilterGreen(IFilter filter, Bitmap image)
        {
            try
            {
               Bitmap newImage = filter.Apply(image);
               greenpicture.Image = newImage;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void ApplyFilterBlue(IFilter filter, Bitmap image)
        {
            try
            {
                Bitmap newImage = filter.Apply(image);
                bluepicture.Image = newImage;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }


        private void Grayscale(Bitmap image)
        {
             IFilter filler=new GrayscaleBT709();
             Bitmap newImage = filler.Apply(image);
             graypicture.Image = newImage;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DCT obj = new DCT(orginalpic.ImageLocation);
            ActiveForm.Hide();
            obj.Show();

        }


       
    }
}
