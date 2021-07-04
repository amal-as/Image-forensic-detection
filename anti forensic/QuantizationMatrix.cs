using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;




namespace ImageForensic
{
    public partial class QuantizationMatrix : Form
    {
        public static Bitmap newimage;
        public static Int32[] words;
        public static Int32[,] quantizationmatrix=new Int32[7,7];

        public QuantizationMatrix()
        {
            InitializeComponent();
        }
        public QuantizationMatrix(Bitmap filepath)
        {
            InitializeComponent();
            //byte[] rgb=ReadImage(filepath, new string[] { ".gif", ".jpg", ".bmp" });
            DCTimage.Image = (Image)filepath;
            dcthistogram();
           BmpToBytes_Unsafe(filepath);
            //quantizationmatrixvalueload();

        }

        public void dcthistogram()
        {
            long[] myValues = GetHistogram(new Bitmap(DCTimage.Image));

            histogramaDesenat1.DrawHistogram(myValues);
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

         public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

      

        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);

                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);

                    BinaryReader br = new BinaryReader(fs);

                    byte[] image = br.ReadBytes((int)fs.Length);

                    br.Close();

                    fs.Close();

                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private static Double[,] InitCoefficientsMatrix(int dim)
        {
            Double[,] coefficientsMatrix = new double[dim, dim];

            for (int i = 0; i < dim; i++)
            {
                coefficientsMatrix[i, 0] = System.Math.Sqrt(2.0) / dim;
                coefficientsMatrix[0, i] = System.Math.Sqrt(2.0) / dim;
            }

            coefficientsMatrix[0, 0] = 1.0 / dim;

            for (int i = 1; i < dim; i++)
            {
                for (int j = 1; j < dim; j++)
                {
                    coefficientsMatrix[i, j] = 2.0 / dim;
                }
            }
            return coefficientsMatrix;
        }
        private static bool IsQuadricMatrix<T>(T[,] matrix)
        {
            int columnsCount = matrix.GetLength(0);
            int rowsCount = matrix.GetLength(1);
            return (columnsCount == rowsCount);
        }
        public static Double[,] ForwardDCT(Double[,] input)
        {
            double sqrtOfLength = System.Math.Sqrt(input.Length);

            if (IsQuadricMatrix<Double>(input) == false)
            {
                throw new ArgumentException("Matrix must be quadric");
            }

            int N = input.GetLength(0);

            double[,] coefficientsMatrix = InitCoefficientsMatrix(N);
            Double[,] output = new Double[N, N];

            for (int u = 0; u <= N - 1; u++)
            {
                for (int v = 0; v <= N - 1; v++)
                {
                    double sum = 0.0;
                    for (int x = 0; x <= N - 1; x++)
                    {
                        for (int y = 0; y <= N - 1; y++)
                        {
                            sum += input[x, y] * System.Math.Cos(((2.0 * x + 1.0) / (2.0 * N)) * u * System.Math.PI) * System.Math.Cos(((2.0 * y + 1.0) / (2.0 * N)) * v * System.Math.PI);
                        }
                    }
                    sum *= coefficientsMatrix[u, v];
                    output[u, v] = System.Math.Round(sum);
                }
            }
            return output;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void BmpToBytes_Unsafe(Bitmap bmp1)
        {
            Bitmap bmp = bmp1; 
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);

            // copy as bytes
            int byteCount = data.Stride * data.Height;
            byte[] bytes = new byte[byteCount];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, bytes, 0, byteCount);

            // -- OR -- copy as ints
            int wordCount = byteCount / 4;
            words = new Int32[wordCount];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, words, 0, wordCount);

            doquantization(words);
            //pictureBox2.Image = (Image)bmp;
        }


        public void quantizationmatrixvalueload()
        {
            quantizationmatrix[0, 0] = 16;
            quantizationmatrix[0, 1] = 11;
            quantizationmatrix[0, 2] = 10;
            quantizationmatrix[0, 3] = 16;
            quantizationmatrix[0, 4] = 24;
            quantizationmatrix[0, 5] = 40;
            quantizationmatrix[0, 6] = 51;
            quantizationmatrix[0, 7] = 61;
            quantizationmatrix[1, 0] = 12;
            quantizationmatrix[1, 1] = 12;
            quantizationmatrix[1, 2] = 14;
            quantizationmatrix[1, 3] = 19;
            quantizationmatrix[1, 4] = 26;
            quantizationmatrix[1, 5] = 58;
            quantizationmatrix[1, 6] = 60;
            quantizationmatrix[1, 7] = 55;
            quantizationmatrix[2, 0] = 14;
            quantizationmatrix[2, 1] = 13;
            quantizationmatrix[2, 2] = 16;
            quantizationmatrix[2, 3] = 24;
            quantizationmatrix[2, 4] = 40;
            quantizationmatrix[2, 5] = 57;
            quantizationmatrix[2, 6] = 69;
            quantizationmatrix[2, 7] = 56;
            quantizationmatrix[3, 0] = 14;
            quantizationmatrix[3, 1] = 17;
            quantizationmatrix[3, 2] = 22;
            quantizationmatrix[3, 3] = 29;
            quantizationmatrix[3, 4] = 51;
            quantizationmatrix[3, 5] = 87;
            quantizationmatrix[3, 6] = 80;
            quantizationmatrix[3, 7] = 62;
            quantizationmatrix[4, 0] = 18;
            quantizationmatrix[4, 1] = 22;
            quantizationmatrix[4, 2] = 37;
            quantizationmatrix[4, 3] = 56;
            quantizationmatrix[4, 4] = 68;
            quantizationmatrix[4, 5] = 109;
            quantizationmatrix[4, 6] = 103;
            quantizationmatrix[4, 7] = 77;
            quantizationmatrix[5, 0] = 24;
            quantizationmatrix[5, 1] = 35;
            quantizationmatrix[5, 2] = 55;
            quantizationmatrix[5, 3] = 54;
            quantizationmatrix[5, 4] = 81;
            quantizationmatrix[5, 5] = 104;
            quantizationmatrix[5, 6] = 113;
            quantizationmatrix[5, 7] = 92;
            quantizationmatrix[6, 0] = 49;
            quantizationmatrix[6, 1] = 64;
            quantizationmatrix[6, 2] = 78;
            quantizationmatrix[6, 3] = 87;
            quantizationmatrix[6, 4] = 103;
            quantizationmatrix[6, 5] = 121;
            quantizationmatrix[6, 6] = 120;
            quantizationmatrix[6, 7] = 101;
            quantizationmatrix[7, 0] = 72;
            quantizationmatrix[7, 1] = 92;
            quantizationmatrix[7, 2] = 95;
            quantizationmatrix[7, 3] = 98;
            quantizationmatrix[7, 4] = 112;
            quantizationmatrix[7, 5] = 100;
            quantizationmatrix[7, 6] = 103;
            quantizationmatrix[7, 7] = 99;
        }

        public void doquantization(Int32[]org)
        {
            Int32[] j = new Int32[org.Count()];
            for (int i = 0; i < org.Count(); i++)
            {
                j[i] = org[i] - 1;
            }


 
        }

        private void QuantizedDCT_Click(object sender, EventArgs e)
        {

        }
    }
}
