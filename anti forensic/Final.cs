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
    public partial class Final : Form
    {
        public Final(Bitmap dct)
        {
            InitializeComponent();
            picDCT.Image = (Image)dct;
        }

        public Bitmap Obj;                   // Input Object Image
        public Bitmap DCTMap;                //Colour DCT Map
        public Bitmap IDCTImage;

        public int[,] GreyImage;             //GreyScale Image Array Generated from input Image
        public double[,] Input;              //Greyscale Image in Double Format

        public double[,] DCTCoefficients;
        public double[,] IDTCoefficients;
        private double[,] DCTkernel;        // DCT Kernel to find Transform Coefficients

        int Width, Height;
        int Order;
        private void button1_Click(object sender, EventArgs e)
        {
            InverseDct2pic(Program.orginal);
        }

        public Bitmap Displayimage(double[,] image)
        {
            int i, j;
            Bitmap output = new Bitmap(image.GetLength(0), image.GetLength(1));
            BitmapData bitmapData1 = output.LockBits(new Rectangle(0, 0, image.GetLength(0), image.GetLength(1)),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData1.Scan0;
                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte)image[j, i];
                        imagePointer1[1] = (byte)image[j, i];
                        imagePointer1[2] = (byte)image[j, i];
                        imagePointer1[3] = 255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }//end for j
                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }//end for i
            }//end unsafe
            output.UnlockBits(bitmapData1);
            return output;// col;

        }

        public void FastInverseDCT()
        {
            double[,] temp = new double[Width, Height];
            IDTCoefficients = new double[Width, Height];
            DCTkernel = new double[Width, Height];
            DCTkernel = Transpose(GenerateDCTmatrix(Order));
            temp = multiply(DCTkernel, DCTCoefficients);
            IDTCoefficients = multiply(temp, Transpose(DCTkernel));
            IDCTImage = Displayimage(IDTCoefficients);
            return;
        }
        private double[,] Transpose(double[,] m)
        {
            int i, j;
            int Width, Height;
            Width = m.GetLength(0);
            Height = m.GetLength(1);

            double[,] mt = new double[m.GetLength(0), m.GetLength(1)];

            for (i = 0; i <= Height - 1; i++)
                for (j = 0; j <= Width - 1; j++)
                {
                    mt[j, i] = m[i, j];
                }
            return (mt);
        }
        private void DCTPlotGenerate()
        {
            int i, j;
            int[,] temp = new int[Width, Height];
            double[,] DCTLog = new double[Width, Height];

            // Compressing Range By taking Log    
            for (i = 0; i <= Width - 1; i++)
                for (j = 0; j <= Height - 1; j++)
                {
                    DCTLog[i, j] = Math.Log(1 + Math.Abs((int)DCTCoefficients[i, j]));

                }

            //Normalizing Array
            double min, max;
            min = max = DCTLog[1, 1];

            for (i = 1; i <= Width - 1; i++)
                for (j = 1; j <= Height - 1; j++)
                {
                    if (DCTLog[i, j] > max)
                        max = DCTLog[i, j];
                    if (DCTLog[i, j] < min)
                        min = DCTLog[i, j];
                }
            for (i = 0; i <= Width - 1; i++)
                for (j = 0; j <= Height - 1; j++)
                {
                    temp[i, j] = (int)(((float)(DCTLog[i, j] - min) / (float)(max - min)) * 750);
                }

            DCTMap = Displaymap(temp);
        }

        public void InverseDct2pic(Bitmap dct)
        {
            int i = dct.Width;
            int j=dct.Height;

            Bitmap newBitmap = new Bitmap(dct.Width, dct.Height);
            newBitmap = dct;
            double r = 0, g = 0, b = 0;

            Color originalColor = dct.GetPixel(dct.Width-1, dct.Height-1);
            

            Color originalColor3 = dct.GetPixel(dct.Width-1, dct.Height-1);
            r = originalColor.R;
            g = originalColor.B;
            b = originalColor.G;
            Color c3 = NewGetRgb(r, g, b-15);
            newBitmap.SetPixel(dct.Width-1, dct.Height-1, c3);

            picfinal.Image = (Image)newBitmap;

            

           

        }

        public static Color NewGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r-1), (byte)(g), (byte)(b));

        }

        public Bitmap Displaymap(int[,] output)
        {
            int i, j;
            Bitmap image = new Bitmap(output.GetLength(0), output.GetLength(1));
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, output.GetLength(0), output.GetLength(1)),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData1.Scan0;
                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        if (output[j, i] < 0)
                        {
                            // Changing to Red Color
                            // Changing to Green Color
                            imagePointer1[0] = 0; //(byte)output[j, i];
                            imagePointer1[1] = 255;
                            imagePointer1[2] = 0; //(byte)output[j, i];
                        }
                        else if ((output[j, i] >= 0) && (output[j, i] < 50))
                        {   // Changing to Green Color
                            imagePointer1[0] = (byte)((output[j, i]) * 4);  //(byte)output[j, i];
                            imagePointer1[1] = 0;
                            imagePointer1[2] = 0;// 0; //(byte)output[j, i];
                        }
                        else if ((output[j, i] >= 50) && (output[j, i] < 100))
                        {
                            imagePointer1[0] = 0;//(byte)(-output[j, i]);
                            imagePointer1[1] = (byte)(output[j, i] * 2);// (byte)(output[j, i]);
                            imagePointer1[2] = (byte)(output[j, i] * 2);
                        }
                        else if ((output[j, i] >= 100) && (output[j, i] < 255))
                        {   // Changing to Green Color
                            imagePointer1[0] = 0; //(byte)output[j, i];
                            imagePointer1[1] = (byte)(output[j, i]);// (byte)(output[j, i]);
                            imagePointer1[2] = 0;  //(byte)output[j, i];
                        }
                        else if ((output[j, i] > 255))
                        {   // Changing to Green Color
                            imagePointer1[0] = 0;  //(byte)output[j, i];
                            imagePointer1[1] = 0; //(byte)(output[j, i]);
                            imagePointer1[2] = (byte)((output[j, i]) * 0.7);
                        }
                        imagePointer1[3] = 255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }//end for j
                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }//end for i
            }//end unsafe
            image.UnlockBits(bitmapData1);
            return image;// col;

        }

        public double[,] GenerateDCTmatrix(int order)
        {
            int i, j;
            int N;
            N = order;
            double alpha;
            double denominator;
            double[,] DCTCoeff = new double[N, N];
            for (j = 0; j <= N - 1; j++)
            {
                DCTCoeff[0, j] = Math.Sqrt(1 / (double)N);
            }
            alpha = Math.Sqrt(2 / (double)N);
            denominator = (double)2 * N;
            for (j = 0; j <= N - 1; j++)
                for (i = 1; i <= N - 1; i++)
                {
                    DCTCoeff[i, j] = alpha * Math.Cos(((2 * j + 1) * i * 3.14159) / denominator);
                }

            return (DCTCoeff);
        }
        private double[,] multiply(double[,] m1, double[,] m2)
        {
            int row, col, i, j, k;
            row = col = m1.GetLength(0);
            double[,] m3 = new double[row, col];
            double sum;
            for (i = 0; i <= row - 1; i++)
            {
                for (j = 0; j <= col - 1; j++)
                {
                    Application.DoEvents();
                    sum = 0;
                    for (k = 0; k <= row - 1; k++)
                    {
                        sum = sum + m1[i, k] * m2[k, j];
                    }
                    m3[i, j] = sum;
                }
            }
            return m3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1=new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image i = picfinal.Image;
                i.Save(saveFileDialog1.FileName+".jpg");
            }
            MessageBox.Show("save sucessfully");
        }
    }
}
