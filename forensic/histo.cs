using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;

namespace Forensic
{
    public partial class histo : Form
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

        public histo()
        {
            InitializeComponent();
            orginalpic.ImageLocation = Program.orgpath;
            targetpic.ImageLocation = Program.targetpath;
            GatherStatistics(Program.orginal);
            GatherStatistics2(Program.suspected);
            long[] myValues = GetHistogram(Program.orginal);
            histogramaDesenat1.DrawHistogram(myValues);
            long[] myValues2 = GetHistogram(Program.suspected);
            histogramaDesenat2.DrawHistogram(myValues);
            checkhisto(myValues, myValues);
            

        }
        public Bitmap Gettarget(Bitmap bmp)
        {
            Bitmap newBitmap = new Bitmap(bmp.Width, bmp.Height);
            newBitmap = bmp;
            int r = 0, g = 0, b = 0;
            Color originalColor3 = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
            r = originalColor3.R;
            g = originalColor3.B;
            b = originalColor3.G;
            Color c3 = NewGetRgb(r,b,g);
            newBitmap.SetPixel(bmp.Width - 1, bmp.Height - 1, c3);
            return newBitmap;

            
        }
        public static Color NewGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r + 1), (byte)(g), (byte)(b));

        }
        public void checkhisto(long[] org,long[] susp)
        {
            int c=0;
            if (org.Count() == susp.Count())
            {
                for (int i = 0; i < org.Count(); i++)
                {
                    if (org[i] != susp[i])
                    {
                        c++;
                    }
                }
            }
            else
            {
                c++;
            }
            if (c == 0 || c<200)
            {
              
                Program.results=Program.results+"histogram$";
            }
            else
            {
          
                Program.failures = Program.failures + "histogram$";
            }
 
        }


        public void checkbitmap(Bitmap bmp1, Bitmap bmp2)
        {
            int d = 0;
            if (bmp1.Width == bmp2.Width)
            {
                if (bmp1.Height == bmp2.Height)
                {
                    for (int i = 0; i < bmp1.Width; i++)
                    {
                        for (int j = 0; j < bmp2.Height; j++)
                        {
                            Color originalColor = bmp1.GetPixel(i, j);
                            Color targetcolor = bmp2.GetPixel(i, j);
                            if (originalColor.R != targetcolor.R || originalColor.G!=targetcolor.G || originalColor.B!=targetcolor.B)
                            {
                                d++;
                            }
                        }
                    }
                }
            }
        }
        public void draworginalhistogram()
        {
 
        }

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
                    or.Color = colors[0];
                    activeHistogram = null;
                    activeHistogram = stat.Red;
                    or.Values = activeHistogram.Values;

                    activeHistogram = null;
                    og.Color = colors[1];
                    activeHistogram = stat.Green;
                    og.Values = activeHistogram.Values;

                    activeHistogram = null;
                    ob.Color = colors[2];
                    activeHistogram = stat.Blue;
                    ob.Values = activeHistogram.Values;



                }
                else
                {
                   
                }

            }
            else
            {

            }
        }


        public void GatherStatistics2(Bitmap image)
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
                    tr.Color = colors[0];
                    activeHistogram = null;
                    activeHistogram = stat.Red;
                    tr.Values = activeHistogram.Values;

                    activeHistogram = null;
                    tg.Color = colors[1];
                    activeHistogram = stat.Green;
                    tg.Values = activeHistogram.Values;

                    activeHistogram = null;
                    tb.Color = colors[2];
                    activeHistogram = stat.Blue;
                    tb.Values = activeHistogram.Values;



                }
                else
                {

                }

            }
            else
            {

            }
        }
        public long[] GetHistogram(System.Drawing.Bitmap picture)
        {
            long[] myHistogram = new long[256];

            for (int i = 0; i < picture.Size.Width; i++)
                for (int j = 0; j < picture.Size.Height; j++)
                {
                    System.Drawing.Color c = picture.GetPixel(i, j);

                    long Temp = 0;
                    Temp += c.R;
                    Temp += c.G;
                    Temp += c.B;

                    Temp = (int)Temp / 3;
                    myHistogram[Temp]++;
                }

            return myHistogram;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Baseform obj = new Baseform();
            ActiveForm.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DCTcheck obj = new DCTcheck();
            ActiveForm.Hide();
            obj.Show();
        }

        private void tr_Click(object sender, EventArgs e)
        {

        }


    }
}
