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
    public partial class Noise : Form
    {
        public Noise()
        {
            InitializeComponent();
        }
        public static Bitmap ov;
        public Noise(Bitmap orgDCT,Bitmap NewDCT)
        {
            InitializeComponent();
            ov = orgDCT;
            orgDCTimg.Image = (Image)orgDCT;
            Bitmap jj = InverseDct4mQuantization(orgDCT);
            newDCTimage.Image = (Image)jj;
            CompareDCT.Image = (Image)difference((Bitmap)orgDCTimg.Image, (Bitmap)newDCTimage.Image);
            showhistogram();
        }
        public Bitmap difference(Bitmap orgDCT, Bitmap NewDCT)
        {
            int c = 0;
            Bitmap newBitmap = new Bitmap(orgDCT.Width, orgDCT.Height);
            for (int i = 0; i < orgDCT.Width; i++)
            {
            for (int j = 0; j < orgDCT.Height; j++)
                {
                    Color originalColor = orgDCT.GetPixel(i, j);
                    if (originalColor.R>250)
                    {
                        Color newcolor = GetRgb(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.G >250)
                    {
                        Color newcolor = GetRgb1(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.B >250)
                    {
                        Color newcolor = GetRgb2(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else
                    {
                        c++;
                        newBitmap.SetPixel(i, j,Color.White);
                    }
                }

            decimal total = orgDCT.Width * orgDCT.Height;
            decimal change = ((total -c) / total) * 100;

            label2.Text = Math.Round(change, 2).ToString() + " %";
                    
            }
            return newBitmap;
            
        }


        public static Color GetRgb(double r, double g, double b)
        {
          //  return Color.FromArgb(255, (byte)(r - 1), (byte)(g), (byte)(b));
            return Color.RoyalBlue;
        }
        public static Color GetRgb1(double r, double g, double b)
        {
            //return Color.FromArgb(255, (byte)(r), (byte)(g - 1), (byte)(b));
            return Color.RoyalBlue;
        }
        public static Color GetRgb2(double r, double g, double b)
        {
            //return Color.FromArgb(255, (byte)(r), (byte)(g), (byte)(b - 1));
            return Color.RoyalBlue;
                
        }

        public void showhistogram()
        {
            long[] myValues = GetHistogram(new Bitmap(orgDCTimg.Image));

            histogramaDesenat1.DrawHistogram(myValues);

            long[] myvalues2 = GetHistogram(new Bitmap(newDCTimage.Image));

            histogramaDesenat2.DrawHistogram(myvalues2);
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

        public Bitmap InverseDct4mQuantization(Bitmap scrBitmap)
        {
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    Color originalColor = scrBitmap.GetPixel(i, j);
                    if (originalColor.R > 250)
                    {
                        Color newcolor = nGetRgb(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.G > 180)
                    {
                        Color newcolor = nGetRgb1(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.B > 180)
                    {
                        Color newcolor = nGetRgb2(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, originalColor);
                    }
                }

            }
            return newBitmap;

        }

        public static Color nGetRgb(double r, double g, double b)
        {
           return Color.FromArgb(255, (byte)(r - 1), (byte)(g), (byte)(b));
            
        }
        public static Color nGetRgb1(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g - 1), (byte)(b));
            
        }
        public static Color nGetRgb2(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g), (byte)(b - 1));
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            addNoise((Bitmap)newDCTimage.Image, (Bitmap)CompareDCT.Image);
        }
        public void addNoise(Bitmap orgDCT, Bitmap NewDCT)
        {
            Bitmap newBitmap = new Bitmap(orgDCT.Width, orgDCT.Height);
            double r = 0, g = 0, b = 0;
            for (int i = 0; i < orgDCT.Width; i++)
            {
                for (int j = 0; j < orgDCT.Height; j++)
                {
                    Color originalColor = orgDCT.GetPixel(i, j);
                    Color newcolor = NewDCT.GetPixel(i, j);

                    r = originalColor.R - newcolor.R;
                    g = originalColor.G - newcolor.G;
                    b = originalColor.B - originalColor.B;
                    Color newone = NewGetRgb(r, g, b);
                    newBitmap.SetPixel(i, j, newone);

                }
            }
            Bitmap noisesignal = new Bitmap(orgDCT.Width, orgDCT.Height);
            for (int i = 0; i < orgDCT.Width; i++)
            {
                for (int j = 0; j < orgDCT.Height; j++)
                {
                    Color originalColor = orgDCT.GetPixel(i, j);
                    Color newcolor = newBitmap.GetPixel(i, j);

                    r = originalColor.R - newcolor.R;
                    g = originalColor.G - newcolor.G;
                    b = originalColor.B - originalColor.B;
                    Color newone = NewGetRgb(r, g, b);
                    noisesignal.SetPixel(i, j, newone);

                }
            }

            Noisedetails.Image = (Image)noisesignal;
            NOISEDCT.Image = (Image)ov;
            Noisequantized.Image = (Image)ov;

            int c = 0;
            for (int i = 0; i < ov.Width; i++)
            {
                for (int j = 0; j < ov.Height; j++)
                {
                    Color originalColor = ov.GetPixel(i, j);
                    Color newcolor = ov.GetPixel(i, j);

                    r = originalColor.R - newcolor.R;
                    g = originalColor.G - newcolor.G;
                    b = originalColor.B - originalColor.B;
                    if (r != 0 || g != 0 || b != 0)
                    {
                        c++;
                    }

                }

                if (c == 0)
                {
                    label3.Text = "0.00 %";
                }
                else
                {
                    decimal total = ov.Width * ov.Height;
                    decimal change = ((total - (total - c)) / total) * 100;

                    label3.Text = Math.Round(change, 2).ToString() + " %";
 
                }
            }

            long[] myValues = GetHistogram(ov);

            histogramaDesenat3.DrawHistogram(myValues);

            long[] myvalues2 = GetHistogram(ov);

            histogramaDesenat4.DrawHistogram(myvalues2);
        }

        public static Color NewGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g), (byte)(b));
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Final obj = new Final((Bitmap)NOISEDCT.Image);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
