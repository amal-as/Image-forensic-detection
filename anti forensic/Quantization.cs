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
    public partial class Quantization : Form
    {
        public static string s = "";
        private ImageForensic.HistogramaDesenat Histogram;
        public Quantization()
        {
            InitializeComponent();
            fillquantizationmatrix();
        }
        public Quantization(Bitmap dct)
        {
            InitializeComponent();
            fillquantizationmatrix();
            DCTimage.Image = (Image)dct;
            long[] myValues = GetHistogram(new Bitmap(DCTimage.Image));

            histogramaDesenat1.DrawHistogram(myValues);
            ConvertDCTImage((Bitmap)DCTimage.Image);

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
       
        public void fillquantizationmatrix()
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[0].Value = "16";
            dataGridView1.Rows[0].Cells[1].Value = "11";
            dataGridView1.Rows[0].Cells[2].Value = "10";
            dataGridView1.Rows[0].Cells[3].Value = "16";
            dataGridView1.Rows[0].Cells[4].Value = "24";
            dataGridView1.Rows[0].Cells[5].Value = "40";
            dataGridView1.Rows[0].Cells[6].Value = "51";
            dataGridView1.Rows[0].Cells[7].Value = "61";
            
            dataGridView1.Rows[1].Cells[0].Value = "12";
            dataGridView1.Rows[1].Cells[1].Value = "12";
            dataGridView1.Rows[1].Cells[2].Value = "14";
            dataGridView1.Rows[1].Cells[3].Value = "19";
            dataGridView1.Rows[1].Cells[4].Value = "26";
            dataGridView1.Rows[1].Cells[5].Value = "58";
            dataGridView1.Rows[1].Cells[6].Value = "60";
            dataGridView1.Rows[1].Cells[7].Value = "55";
            
            dataGridView1.Rows[2].Cells[0].Value = "14";
            dataGridView1.Rows[2].Cells[1].Value = "13";
            dataGridView1.Rows[2].Cells[2].Value = "16";
            dataGridView1.Rows[2].Cells[3].Value = "24";
            dataGridView1.Rows[2].Cells[4].Value = "40";
            dataGridView1.Rows[2].Cells[5].Value = "57";
            dataGridView1.Rows[2].Cells[6].Value = "69";
            dataGridView1.Rows[2].Cells[7].Value = "56";
           
            dataGridView1.Rows[3].Cells[0].Value = "14";
            dataGridView1.Rows[3].Cells[1].Value = "17";
            dataGridView1.Rows[3].Cells[2].Value = "22";
            dataGridView1.Rows[3].Cells[3].Value = "29";
            dataGridView1.Rows[3].Cells[4].Value = "51";
            dataGridView1.Rows[3].Cells[5].Value = "87";
            dataGridView1.Rows[3].Cells[6].Value = "80";
            dataGridView1.Rows[3].Cells[7].Value = "62";
           
            dataGridView1.Rows[4].Cells[0].Value = "18";
            dataGridView1.Rows[4].Cells[1].Value = "22";
            dataGridView1.Rows[4].Cells[2].Value = "37";
            dataGridView1.Rows[4].Cells[3].Value = "56";
            dataGridView1.Rows[4].Cells[4].Value = "68";
            dataGridView1.Rows[4].Cells[5].Value = "109";
            dataGridView1.Rows[4].Cells[6].Value = "103";
            dataGridView1.Rows[4].Cells[7].Value = "77";
            
            dataGridView1.Rows[5].Cells[0].Value = "24";
            dataGridView1.Rows[5].Cells[1].Value = "35";
            dataGridView1.Rows[5].Cells[2].Value = "55";
            dataGridView1.Rows[5].Cells[3].Value = "64";
            dataGridView1.Rows[5].Cells[4].Value = "81";
            dataGridView1.Rows[5].Cells[5].Value = "104";
            dataGridView1.Rows[5].Cells[6].Value = "113";
            dataGridView1.Rows[5].Cells[7].Value = "92";
          
            dataGridView1.Rows[6].Cells[0].Value = "49";
            dataGridView1.Rows[6].Cells[1].Value = "64";
            dataGridView1.Rows[6].Cells[2].Value = "78";
            dataGridView1.Rows[6].Cells[3].Value = "87";
            dataGridView1.Rows[6].Cells[4].Value = "103";
            dataGridView1.Rows[6].Cells[5].Value = "121";
            dataGridView1.Rows[6].Cells[6].Value = "120";
            dataGridView1.Rows[6].Cells[7].Value = "101";
           
            dataGridView1.Rows[7].Cells[0].Value = "72";
            dataGridView1.Rows[7].Cells[1].Value = "92";
            dataGridView1.Rows[7].Cells[2].Value = "95";
            dataGridView1.Rows[7].Cells[3].Value = "98";
            dataGridView1.Rows[7].Cells[4].Value = "112";
            dataGridView1.Rows[7].Cells[5].Value = "100";
            dataGridView1.Rows[7].Cells[6].Value = "103";
            dataGridView1.Rows[7].Cells[7].Value = "99";
        }

        public Bitmap pixelquantization(Bitmap scrBitmap)
        {
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    Color originalColor = scrBitmap.GetPixel(i, j);
                    if (originalColor.R>250)
                    {
                        Color newcolor = GetRgb(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.G > 180)
                    {
                        Color newcolor = GetRgb1(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.B > 180)
                    {
                        Color newcolor = GetRgb2(originalColor.R, originalColor.G, originalColor.B);
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
            public static Color GetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r-5), (byte)(g-1), (byte)(b-1));
        }
            public static Color GetRgb1(double r, double g, double b)
            {
                return Color.FromArgb(255, (byte)(r-1), (byte)(g-5), (byte)(b-1));
            }
            public static Color GetRgb2(double r, double g, double b)
            {
                return Color.FromArgb(255, (byte)(r - 1), (byte)(g-1), (byte)(b-5));
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = pixelquantization((Bitmap)DCTimage.Image);
            NewDctImage.Image = (Image)bmp;

            long[] myValues = GetHistogram(new Bitmap(NewDctImage.Image));

            histogramaDesenat2.DrawHistogram(myValues);
            ConvertDCTImage2(bmp);
        }
        public void ConvertDCTImage2(Bitmap img)
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
                dataGridView3.Rows.Add();
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[0].Value = s;
                s = "";

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Noise obj = new Noise((Bitmap)DCTimage.Image, (Bitmap)NewDctImage.Image);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
