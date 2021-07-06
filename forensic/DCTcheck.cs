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
    public partial class DCTcheck : Form
    {
        public DCTcheck()
        {
            InitializeComponent();
            orginalpic.Image = (Image)Program.orginal;
            targetpic.Image = (Image)Program.suspected;
            orgDct();
            orgDct2();
            checkdct();
        }

        public void checkdct()
        {
            int h = 0, w = 0,m=0,d=0;
            double per=0;
            if (orginalpic.Image.Height > targetpic.Image.Height)
            {
                h = targetpic.Image.Height;
            }
            else if (orginalpic.Image.Height < targetpic.Image.Height)
            {
                h = orginalpic.Image.Height;
            }
            else
            {
                h = orginalpic.Image.Height;
            }

            if (orginalpic.Image.Width > targetpic.Image.Width)
            {
                w = targetpic.Image.Width;
            }
            else if (orginalpic.Image.Width < targetpic.Image.Width)
            {
                w = orginalpic.Image.Width;
            }
            else
            {
                w = orginalpic.Image.Width;
            }

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {

                    Color originalColor = Program.orginal.GetPixel(i, j);
                    Color susp = Program.suspected.GetPixel(i, j);
                    if (originalColor.R == susp.R)
                    {
                        if (originalColor.G == susp.G)
                        {
                            if (originalColor.B == susp.B)
                            {
                                m++;
                            }
                            else
                            {
                                d++;
                            }
                        }
                        else
                        {
                            d++;
                        }
                    }
                    else
                    {
                        d++;
                    }
                }
            }

            int total = h * w;
           
            
            if (d==0 || d==1 || d==2)
            {
                
            }
            else 
            {
               
            }

        }
        public static string imgpath;
        public static string s = "";
        public Bitmap bmp;
        FastDCT2D ImgDCT;
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        public int WindowSize = 256;  // Dimension of Image Selection Window
        double[,] DCTCoefficients; //DCT Coefficient matrix

        public void orgDct()
        {
            int x, y, width, height;
            Bitmap InputImage = new Bitmap(Program.orginal);
            Bitmap temp = (Bitmap)InputImage.Clone();
            int iheight = orginalpic.Image.Height;
            int iwidth = orginalpic.Image.Width;
            if (iheight < iwidth)
            {
                WindowSize = iheight;
            }
            else
            {
                WindowSize = iwidth;
            }

            width = height = (int)(WindowSize * Convert.ToInt32(100) / 100);
            bmp = new Bitmap(width, height, InputImage.PixelFormat);
            rec_width = rec_height = (int)(512 * ((float)100 / 100));
            x = (int)((float)0 * (100 / Convert.ToDouble(100)));
            y = (int)((float)0 * (100 / Convert.ToDouble(100)));
            width = height = (int)(rec_width * (100 / (float)scale));
            if (width > WindowSize)
            {
                width = height = WindowSize;
            }

            Rectangle area = new Rectangle(x, y, width, height);


            bmp = (Bitmap)InputImage.Clone(area, InputImage.PixelFormat);
            
            ImgDCT = new FastDCT2D(bmp, WindowSize);
            ImgDCT.FastDCT();// Finding 2D DCT of Image

            orginaldct.Image = (Image)ImgDCT.DCTMap;

        }

        public void orgDct2()
        {
            int x, y, width, height;
            Bitmap InputImage = new Bitmap(Program.suspected);
            Bitmap temp = (Bitmap)InputImage.Clone();
            int iheight = targetpic.Image.Height;
            int iwidth = targetpic.Image.Width;
            if (iheight < iwidth)
            {
                WindowSize = iheight;
            }
            else
            {
                WindowSize = iwidth;
            }

            width = height = (int)(WindowSize * Convert.ToInt32(100) / 100);
            bmp = new Bitmap(width, height, InputImage.PixelFormat);
            rec_width = rec_height = (int)(512 * ((float)100 / 100));
            x = (int)((float)0 * (100 / Convert.ToDouble(100)));
            y = (int)((float)0 * (100 / Convert.ToDouble(100)));
            width = height = (int)(rec_width * (100 / (float)scale));
            if (width > WindowSize)
            {
                width = height = WindowSize;
            }

            Rectangle area = new Rectangle(x, y, width, height);


            bmp = (Bitmap)InputImage.Clone(area, InputImage.PixelFormat);

            ImgDCT = new FastDCT2D(bmp, WindowSize);
            ImgDCT.FastDCT();// Finding 2D DCT of Image

            suspdct.Image = (Image)ImgDCT.DCTMap;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Baseform OBJ = new Baseform();
            ActiveForm.Hide();
            OBJ.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Noise obj = new Noise((Bitmap)orginaldct.Image,(Bitmap)suspdct.Image);
            ActiveForm.Hide();
            obj.Show();
        }

        private void orginaldct_Click(object sender, EventArgs e)
        {

        }
    }
}
