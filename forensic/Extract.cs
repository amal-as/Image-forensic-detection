using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge;



namespace Forensic
{
    public partial class Extract : Form
    {
        ImageHandler imageHandler = new ImageHandler();
        FastDCT2D ImgDCT;
        public int WindowSize = 256;  
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),};

        private AForge.Math.Histogram activeHistogram = null;
        private int currentImageHash = 0;
        private ImageStatistics stat;
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        private IntRange red = new IntRange(0, 255);
        private IntRange green = new IntRange(0, 255);
        private IntRange blue = new IntRange(0, 255);
   
        FolderBrowserDialog f = new FolderBrowserDialog();
        OpenFileDialog o = new OpenFileDialog();
        Bitmap DecryptedBitmap;
        System.Drawing.Image DecryptedImage;
        string DSaveFilePath;
        string DLoadImagePath;
        int height, width;
         public Extract()
        {
            InitializeComponent();
            imgload();
            GatherStatistics(Program.orginal);
            GatherStatistics2(Program.suspected);
            long[] myValues = GetHistogram(Program.orginal);
            histogramaDesenat1.DrawHistogram(myValues);
            long[] myValues2 = GetHistogram(Program.suspected);
            histogramaDesenat2.DrawHistogram(myValues);
            label11.Text = "...";
           
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
         public void imgload()
         {
             //tb_image.Text = o.FileName; 
             DLoadImagePath = Program.targetpath;
             pictureBox1.ImageLocation = DLoadImagePath;

             DecryptedImage = System.Drawing.Image.FromFile(DLoadImagePath);
             height = DecryptedImage.Height;
             width = DecryptedImage.Width;
             DecryptedBitmap = new Bitmap(DecryptedImage);
             pictureBox2.ImageLocation = Program.orgpath;

             FileInfo imginf = new FileInfo(DLoadImagePath);
             float fs = (float)imginf.Length / 1024;
             //ImageSize_lbl.Text = smalldecimal(fs.ToString(), 2) + " KB";
             //ImageHeight_lbl.Text = DecryptedImage.Height.ToString() + " Pixel";
             //ImageWidth_lbl.Text = DecryptedImage.Width.ToString() + " Pixel";
             //double cansave = (8.0 * ((height * (width / 3) * 3) / 3 - 1)) / 1024;
             //CanSave_lbl.Text = smalldecimal(cansave.ToString(), 2) + " KB";

             //canPaint = true;
             this.Invalidate();
         }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_file.Text == "")
                {
                  
                    if (tb_file.Text == "")
                        MessageBox.Show("Select a location....");
                }
                else
                {

                    if (tb_file.Text == String.Empty)
                    {
                        MessageBox.Show("Text boxes must not be empty!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (System.IO.File.Exists(Program.orgpath) == false)
                    {
                        MessageBox.Show("Select image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       
                        return;
                    }
                    DecryptLayer();
                }
            }
            catch (Exception ex)
            {
                label11.Text = "No file embedded.....";
            }
        }
        private void DecryptLayer()
        {
            //toolStripStatusLabel1.Text = "Decrypting... Please wait";
            Application.DoEvents();
            int i, j = 0;
            bool[] t = new bool[8];
            bool[] rb = new bool[8];
            bool[] gb = new bool[8];
            bool[] bb = new bool[8];
            Color pixel = new Color();
            byte r, g, b;
            try
            {
                pixel = DecryptedBitmap.GetPixel(width - 1, height - 1);
                long fSize = pixel.R + pixel.G * 100 + pixel.B * 10000;
                pixel = DecryptedBitmap.GetPixel(width - 2, height - 1);
                long fNameSize = pixel.R + pixel.G * 100 + pixel.B * 10000;
                byte[] res = new byte[fSize];
                string resFName = "";
                byte temp;

                //Read file name:
                for (i = 0; i < height && i * (height / 3) < fNameSize; i++)
                    for (j = 0; j < (width / 3) * 3 && i * (height / 3) + (j / 3) < fNameSize; j++)
                    {
                        pixel = DecryptedBitmap.GetPixel(j, i);
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        byte2bool(r, ref rb);
                        byte2bool(g, ref gb);
                        byte2bool(b, ref bb);
                        if (j % 3 == 0)
                        {
                            t[0] = rb[7];
                            t[1] = gb[7];
                            t[2] = bb[7];
                        }
                        else if (j % 3 == 1)
                        {
                            t[3] = rb[7];
                            t[4] = gb[7];
                            t[5] = bb[7];
                        }
                        else
                        {
                            t[6] = rb[7];
                            t[7] = gb[7];
                            temp = bool2byte(t);
                            resFName += (char)temp;
                        }
                    }

                //Read file on layer 8 (after file name):
                int tempj = j;
                i--;

                for (; i < height && i * (height / 3) < fSize + fNameSize; i++)
                    for (j = 0; j < (width / 3) * 3 && i * (height / 3) + (j / 3) < (height * (width / 3) * 3) / 3 - 1 && i * (height / 3) + (j / 3) < fSize + fNameSize; j++)
                    {
                        if (tempj != 0)
                        {
                            j = tempj;
                            tempj = 0;
                        }
                        pixel = DecryptedBitmap.GetPixel(j, i);
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        byte2bool(r, ref rb);
                        byte2bool(g, ref gb);
                        byte2bool(b, ref bb);
                        if (j % 3 == 0)
                        {
                            t[0] = rb[7];
                            t[1] = gb[7];
                            t[2] = bb[7];
                        }
                        else if (j % 3 == 1)
                        {
                            t[3] = rb[7];
                            t[4] = gb[7];
                            t[5] = bb[7];
                        }
                        else
                        {
                            t[6] = rb[7];
                            t[7] = gb[7];
                            temp = bool2byte(t);
                            res[i * (height / 3) + j / 3 - fNameSize] = temp;
                        }
                    }

                //Read file on other layers:
                long readedOnL8 = (height * (width / 3) * 3) / 3 - fNameSize - 1;

                for (int layer = 6; layer >= 0 && readedOnL8 + (6 - layer) * ((height * (width / 3) * 3) / 3 - 1) < fSize; layer--)
                    for (i = 0; i < height && i * (height / 3) + readedOnL8 + (6 - layer) * ((height * (width / 3) * 3) / 3 - 1) < fSize; i++)
                        for (j = 0; j < (width / 3) * 3 && i * (height / 3) + (j / 3) + readedOnL8 + (6 - layer) * ((height * (width / 3) * 3) / 3 - 1) < fSize; j++)
                        {
                            pixel = DecryptedBitmap.GetPixel(j, i);
                            r = pixel.R;
                            g = pixel.G;
                            b = pixel.B;
                            byte2bool(r, ref rb);
                            byte2bool(g, ref gb);
                            byte2bool(b, ref bb);
                            if (j % 3 == 0)
                            {
                                t[0] = rb[layer];
                                t[1] = gb[layer];
                                t[2] = bb[layer];
                            }
                            else if (j % 3 == 1)
                            {
                                t[3] = rb[layer];
                                t[4] = gb[layer];
                                t[5] = bb[layer];
                            }
                            else
                            {
                                t[6] = rb[layer];
                                t[7] = gb[layer];
                                temp = bool2byte(t);
                                res[i * (height / 3) + j / 3 + (6 - layer) * ((height * (width / 3) * 3) / 3 - 1) + readedOnL8] = temp;
                            }
                        }

                if (File.Exists(DSaveFilePath + "\\" + resFName))
                {
                    MessageBox.Show("File \"" + resFName + "\" already exist please choose another path to save file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    File.WriteAllBytes(DSaveFilePath + "\\" + resFName, res);
                label11.Text = "There was an embedded file in the image..file saved in specified path";
                tb_file.Text = "";
              
                pictureBox1.Image = null;
                //toolStripStatusLabel1.Text = "Decrypted file has been successfully saved.";
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                label11.Text = "No file embedded.....";
            }
        }

       private void byte2bool(byte inp,ref bool[] outp)
       {
           try
           {
               if (inp >= 0 && inp <= 255)
                   for (short i = 7; i >= 0; i--)
                   {
                       if (inp % 2 == 1)
                           outp[i] = true;
                       else
                           outp[i] = false;
                       inp /= 2;
                   }
               else
                   throw new Exception("Input number is illegal.");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
       }
        private byte bool2byte(bool[] inp)
        {
            byte outp=0;
            try
            {
                for (short i = 7; i >= 0; i--)
                {
                    if (inp[i])
                        outp += (byte)Math.Pow(2.0, (double)(7 - i));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return outp;
        }
    

        private void Extract_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {

                if (f.ShowDialog() == DialogResult.OK)
                {
                    tb_file.Text = f.SelectedPath;
                    DSaveFilePath = tb_file.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (o.ShowDialog() == DialogResult.OK)
                {
                  




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb_file.Text = "";
           
            pictureBox1.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        public void dct(Bitmap bmp)
        {
            int x, y, width, height;
            //   Bitmap InputImage = new Bitmap(pictureBox1.ImageLocation);
            Bitmap InputImage = bmp;
            System.Drawing.Image IMG = (System.Drawing.Image)bmp;
            pictureBox1.Image = IMG;
            Bitmap temp = (Bitmap)InputImage.Clone();
            int iheight = pictureBox1.Image.Height;
            int iwidth = pictureBox1.Image.Width;
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


            ImgDCT = new FastDCT2D(bmp, WindowSize);
            ImgDCT.FastDCT();// Finding 2D DCT of Image
            DCTMapImage.Image = (System.Drawing.Image)ImgDCT.DCTMap;

        }


        public void dct2(Bitmap bmp)
        {
            int x, y, width, height;
            //   Bitmap InputImage = new Bitmap(pictureBox1.ImageLocation);
            Bitmap InputImage = bmp;
            System.Drawing.Image IMG = (System.Drawing.Image)bmp;
            pictureBox1.Image = IMG;
            Bitmap temp = (Bitmap)InputImage.Clone();
            int iheight = pictureBox2.Image.Height;
            int iwidth = pictureBox2.Image.Width;
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


            ImgDCT = new FastDCT2D(bmp, WindowSize);
            ImgDCT.FastDCT();// Finding 2D DCT of Image
            DCTMapImage2.Image = (System.Drawing.Image)ImgDCT.DCTMap;

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            dct(Program.orginal);
            dct2(Program.suspected);
        }
    }
}