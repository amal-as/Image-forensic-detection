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
    public partial class DCTform : Form
    {
        public DCTform()
        {
            InitializeComponent();
        }
        private int buttonNumber = 1;
        public static int x = 0, y = 0;

        public DCTform(string path)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = path;
           
        }

        

        public double[,] B = new double[8, 8];
        private int quadX = 0;
        private int quadY = 0;
        private double[,] cosine = new double[8, 8];
        private double SQRT2o2 = Math.Sqrt(2.0) / 2.0;
        private byte[,] valueMatrix = new byte[8, 8];

        private byte[,] defaultQ = new byte[8, 8] {{8,16,19,22,26,27,29,34},
										{16,16,22,24,27,29,34,37},
										{19,22,26,27,29,34,34,38},
										{22,22,26,27,29,34,37,40},
										{22,26,27,29,32,35,40,48},
										{26,27,29,32,35,40,48,58},
										{26,27,29,34,38,46,56,69},
										{27,29,35,38,46,56,69,83}};


       

        public double[,] calculateDCT(byte[,] A)
        {
            int k1, k2, i, j;
            double Cu, Cv;
            double[,] B = new double[8, 8];

            for (k1 = 0; k1 < 8; k1++)
                for (k2 = 0; k2 < 8; k2++)
                {
                    B[k1, k2] = 0.0;
                    for (i = 0; i < 8; i++)
                        for (j = 0; j < 8; j++)
                            B[k1, k2] += A[i, j] * cosine[k1, i] * cosine[k2, j];

                    if (k1 == 0)
                        Cu = SQRT2o2;
                    else
                        Cu = 1.0;
                    if (k2 == 0)
                        Cv = SQRT2o2;
                    else
                        Cv = 1.0;

                    B[k1, k2] *= (0.25 * Cu * Cv);
                }
            return B;	// Return Frequency Component matrix
        }


        private void fillLV()
        {
            // Write selected quadrant of component values into ListView
            int i, j;
            string[] rowRGB = new string[9];
            byte pixelColor;
            double Y, Pr, Pb;
            double pixelR, pixelG, pixelB;

            Bitmap img = new Bitmap(pictureBox1.Image);

            listView1.Items.Clear();

            for (i = quadY; i < quadY + 8; i++)
            {
                rowRGB[0] = "y" + i.ToString();
                for (j = quadX; j < quadX + 8; j++)
                {
                    if (buttonNumber < 5)
                    {
                        pixelR = img.GetPixel(j, i).R;
                        pixelG = img.GetPixel(j, i).G;
                        pixelB = img.GetPixel(j, i).B;
                        Y = (219.0 * (0.59 * pixelR + 0.30 * pixelG + 0.11 * pixelB) / 255.0) + 16.0;
                        pixelColor = (byte)Y;
                        listView1.ForeColor = Color.Black;
                    }
                    else if (buttonNumber == 5)
                    {
                        pixelR = img.GetPixel(j * 2, i * 2).R;
                        pixelG = img.GetPixel(j * 2, i * 2).G;
                        pixelB = img.GetPixel(j * 2, i * 2).B;
                        Pr = (224.0 * (0.50 * pixelR - 0.42 * pixelG - 0.08 * pixelB) / 255.0) + 128.0;
                        pixelColor = (byte)Pr;
                        listView1.ForeColor = Color.Red;
                    }
                    else
                    {
                        pixelR = img.GetPixel(j * 2, i * 2).R;
                        pixelG = img.GetPixel(j * 2, i * 2).G;
                        pixelB = img.GetPixel(j * 2, i * 2).B;
                        Pb = (224.0 * (-0.17 * pixelR - 0.33 * pixelG + 0.50 * pixelB) / 255.0) + 128.0;
                        pixelColor = (byte)Pb;
                        listView1.ForeColor = Color.Blue;
                    }

                    rowRGB[j - quadX + 1] = pixelColor.ToString();

                    valueMatrix[i - quadY, j - quadX] = pixelColor;
                }
                listView1.Items.Add(new ListViewItem(rowRGB));
            }
        }

        private void DCTform_Load(object sender, EventArgs e)
        {
           
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            B=calculateDCT(valueMatrix);
            FillDCTLV(B);
        }

        private void FillDCTLV(double[,] values)
        {
            // Write calculated DCT values into ListView2
            int i, j;
            string[] rowRGB = new string[9];
            double DCTresult;

            listView2.Items.Clear();
            for (i = 0; i < 8; i++)
            {
                rowRGB[0] = "y" + i.ToString();
                for (j = 0; j < 8; j++)
                {
                    DCTresult = values[i, j];
                    rowRGB[j + 1] = DCTresult.ToString("f3");
                }
                listView2.Items.Add(new ListViewItem(rowRGB));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuantizationMatrix obj = new QuantizationMatrix((Bitmap)DCTMapImage.Image);
            obj.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            // Upper left Brightness quadrant of image section
            quadX = 0;
            quadY = 0;
            buttonNumber = 1;
            fillLV();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Upper right Brightness quadrant of image section
            quadX = 8;
            quadY = 0;
            buttonNumber = 2;
            fillLV();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Lower left Brightness quadrant of image section
            quadX = 0;
            quadY = 8;
            buttonNumber = 3;
            fillLV();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // Lower right Brightness quadrant of image section
            quadX = 8;
            quadY = 8;
            buttonNumber = 4;
            fillLV();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // Pr color component of image section
            quadX = 0;
            quadY = 0;
            buttonNumber = 5;
            fillLV();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            // Pb color component of image section
            quadX = 0;
            quadY = 0;
            buttonNumber = 6;
            fillLV();
        }
    }
}
