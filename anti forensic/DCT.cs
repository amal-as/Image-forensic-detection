using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace ImageForensic
{
    public partial class DCT : Form
    {
        public static string imgpath;
        public static string s = "";
        public  Bitmap bmp;
        FastDCT2D ImgDCT;
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        public int WindowSize = 256;  // Dimension of Image Selection Window
        double[,] DCTCoefficients; //DCT Coefficient matrix
        private long[] myValues;
        private bool myIsDrawing;
        long myMaxValue;
        private ImageForensic.HistogramaDesenat Histogram;

        public DCT()
        {
            InitializeComponent();
        }

        public DCT(string path)
        {
            InitializeComponent();
            imgpath = path;
            picOrginal.ImageLocation = imgpath;
            
        }

        public void ConvertImage(Bitmap img)
        {
            string raw ="";
            int x=0;
           
            List<Color> pixels = new List<Color>();

            if (img.Height > img.Width)
            {
                x = img.Width;
            }
            else
            {
                x = img.Height;
            }
            
               
            
            for (int y = 0; y < x; y+=5)
            {
                
                for (int j = 0; j < x; j+=5)
                {
                    pixels.Add(img.GetPixel(j,y));
                }
                
                foreach (Color item in pixels)
                {
                   // raw = raw + RetColor(item);
                    s=s+RetColor(item)+" ";
                    
                }

                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = s;
                s = "";
               
                
            }
           
            
            
                      
        }


        public void ConvertDCTImage(Bitmap img)
        {
            string raw = "";
            int x = 0;

            List<Color> pixels = new List<Color>();

            if (img.Height > img.Width)
            {
                x = img.Width;
            }
            else
            {
                x = img.Height;
            }



            for (int y = 0; y < x; y += 5)
            {

                for (int j = 0; j < x; j += 5)
                {
                    pixels.Add(img.GetPixel(j, y));
                }

                foreach (Color item in pixels)
                {
                    // raw = raw + RetColor(item);
                    s = s + RetColor(item) + " ";

                }

                dataGridView2.Rows.Add();
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = s;
                s = "";


            }




        }
        public static string RetColor(Color color)
        {
            char[] hexDigits = {
     '0', '1', '2', '3', '4', '5', '6', '7',
     '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
           

            string sraw = new string(chars);
            string final = sraw;
            return final;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            Bitmap InputImage = new Bitmap(picOrginal.ImageLocation);
            Bitmap temp = (Bitmap)InputImage.Clone();
            int iheight = picOrginal.Image.Height;
            int iwidth = picOrginal.Image.Width;
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
            //bmp = (Bitmap)picOrginal.Image;
            ConvertImage((Bitmap)picOrginal.Image);

            ImgDCT = new FastDCT2D(bmp, WindowSize);
            ImgDCT.FastDCT();// Finding 2D DCT of Image
            DCTMapImage.Image = (Image)ImgDCT.DCTMap;

            long[] myValues = GetHistogram(new Bitmap(DCTMapImage.Image));

            histogramaDesenat1.DrawHistogram(myValues);
            ConvertDCTImage((Bitmap)DCTMapImage.Image);
            
          
        }
        static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Quantization obj = new Quantization((Bitmap)DCTMapImage.Image);
            ActiveForm.Hide();
            obj.Show();
        }
        
     
       
    }
}
