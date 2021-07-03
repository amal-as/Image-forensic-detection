using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;   
using System.Windows.Forms;
using System.IO;

namespace ImageForensic
{
    public partial class Embedd : Form
    {
        FastDCT2D ImgDCT;
        string image_path, File_Path, savetoimage = "", loadedFilePath = "", DLoadImagePath, DSaveFilePath;
        Image img,DecryptedImage, AfterEncryption;
        int height,width;
        long file_Size,file_NameSize;
        Bitmap enc_bitmap, DecryptedBitmap;
        bool canpaint = false, EncriptionDone = false;
        PictureBox pic;
        byte[] filecontent;
        Rectangle previewImage = new Rectangle(20, 160, 490, 470);
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        public int WindowSize = 256;  // Dimension of Image Selection Window
        double[,] DCTCoefficients; //DCT Coefficient matrix
        
        public Embedd(string filepaath,Bitmap BMP)
        {
            InitializeComponent();
            imgload(filepaath);
           // dct(BMP);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void imgload(string filepath)
        {
            try
            {
                image_path = filepath;
                
                img = Image.FromFile(image_path);
                height = img.Height;
                width = img.Width;
                enc_bitmap = new Bitmap(img);
                FileInfo imginf = new FileInfo(image_path);
                float fs = (float)imginf.Length / 1024;
                lb_img_size1.Visible = true;
                lb_img_size1.Text = smalldecimal(fs.ToString(), 2);
                lb_space1.Text = img.Height.ToString() + "*" + img.Width.ToString();
                lb_space1.Visible = true;
                double cansave = (8.0 * ((height * (width / 3) * 3) / 3 - 1)) / 1024;
                lb_max_amt_data1.Visible = true;
                lb_max_amt_data1.Text = smalldecimal(cansave.ToString(), 2) + " KB";
                canpaint = true;
                this.Invalidate();
                picload();
            }
            catch (Exception ex)
            { }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tb_file.Text = "";
              
                pictureBox1.Image = null;
                //pictureBox1.Load(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void picload()
        {
            try
            {
                pic = new PictureBox();
                pic.BorderStyle = BorderStyle.Fixed3D;
                pic.Height = this.Height / 2;
                pic.Width = Width / 2;
                pic.Left = (this.Width - pic.Width) / 2;
                pic.Top = (this.Height - pic.Height) / 2;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(img);
                this.Controls.Add(pic);
                long[] myValues = GetHistogram(new Bitmap(pictureBox1.Image));

                histogramaDesenat1.DrawHistogram(myValues);
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
        private string smalldecimal(string inp, int dec)
        {
            
            int i;
            for (i = inp.Length - 1; i > 0; i--)
                if (inp[i] == '.')
                    break;
            try
            {
                return inp.Substring(0, i + dec + 1);
            }
            catch
            {
                return inp;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    File_Path = openFileDialog2.FileName;
                    tb_file.Text = File_Path;
                    FileInfo f_info = new FileInfo(File_Path);
                    file_Size = f_info.Length;
                    file_NameSize = justFName(File_Path).Length;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string justFName(string path)
        {
            
                string output="";
                int i;
            try
            {
                if (path.Length == 3)   // i.e: "C:\\"
                    return path.Substring(0, 1);
                for (i = path.Length - 1; i > 0; i--)
                    if (path[i] == '\\')
                        break;
                output = path.Substring(i + 1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return output;

        }

        private void Bt_embbd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_file.Text == "")
                {
                    
                    if (tb_file.Text == "")
                        MessageBox.Show("Select a file....");
                }
                else
                {

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        savetoimage = saveFileDialog1.FileName;
                    }
                    else
                        return;
                    if (tb_file.Text == String.Empty)
                    {
                        MessageBox.Show("Encrypton information is incomplete!\nPlease complete them frist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (8 * ((height * (width / 3) * 3) / 3 - 1) < file_Size + file_NameSize)
                    {
                        MessageBox.Show("File size is too large!\nPlease use a larger image to hide this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    filecontent = File.ReadAllBytes(File_Path);

                    EncryptLayer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        progressBar1.Value += 20;
        //        if (progressBar1.Value >= 200)
        //            //this.Dispose();
        //            MessageBox.Show("embedding completed....");
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        
        //}
        private void EncryptLayer()
        {
            //toolStripStatusLabel1.Text = "Encrypting... Please wait";
            try
            {
                Application.DoEvents();
                long FSize = file_Size;
                Bitmap changedBitmap = EncryptLayer(8, enc_bitmap, 0, (height * (width / 3) * 3) / 3 - file_NameSize - 1, true);
                FSize -= (height * (width / 3) * 3) / 3 - file_NameSize - 1;
                if (FSize > 0)
                {
                    for (int i = 7; i >= 0 && FSize > 0; i--)
                    {
                        changedBitmap = EncryptLayer(i, changedBitmap, (((8 - i) * height * (width / 3) * 3) / 3 - file_NameSize - (8 - i)), (((9 - i) * height * (width / 3) * 3) / 3 - file_NameSize - (9 - i)), false);
                        FSize -= (height * (width / 3) * 3) / 3 - 1;
                    }
                }
                changedBitmap.Save(savetoimage+".jpg");
                //toolStripStatusLabel1.Text = "Encrypted image has been successfully saved.";
                MessageBox.Show("Embbeded image has been successfully saved.");
                tb_file.Text = "";
               
                lb_img_size1.Text = "";
                lb_max_amt_data1.Text = "";
                lb_space1.Text = "";
                pictureBox1.Image = null;
                EncriptionDone = true;
                AfterEncryption = Image.FromFile(savetoimage+".jpg");
                this.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private Bitmap EncryptLayer(int layer, Bitmap inputBitmap, long startPosition, long endPosition, bool writeFileName)
        {
           
                Bitmap outputBitmap = inputBitmap;
                layer--;
                int i = 0, j = 0;
                long FNSize = 0;
                bool[] t = new bool[8];
                bool[] rb = new bool[8];
                bool[] gb = new bool[8];
                bool[] bb = new bool[8];
                Color pixel = new Color();
                byte r, g, b;
            try
            {
                if (writeFileName)
                {
                    FNSize = file_NameSize;
                    string fileName = justFName(File_Path);

                    //write fileName:
                    for (i = 0; i < height && i * (height / 3) < file_NameSize; i++)
                        for (j = 0; j < (width / 3) * 3 && i * (height / 3) + (j / 3) < file_NameSize; j++)
                        {
                            byte2bool((byte)fileName[i * (height / 3) + j / 3], ref t);
                            pixel = inputBitmap.GetPixel(j, i);
                            r = pixel.R;
                            g = pixel.G;
                            b = pixel.B;
                            byte2bool(r, ref rb);
                            byte2bool(g, ref gb);
                            byte2bool(b, ref bb);
                            if (j % 3 == 0)
                            {
                                rb[7] = t[0];
                                gb[7] = t[1];
                                bb[7] = t[2];
                            }
                            else if (j % 3 == 1)
                            {
                                rb[7] = t[3];
                                gb[7] = t[4];
                                bb[7] = t[5];
                            }
                            else
                            {
                                rb[7] = t[6];
                                gb[7] = t[7];
                            }
                            Color result = Color.FromArgb((int)bool2byte(rb), (int)bool2byte(gb), (int)bool2byte(bb));
                            outputBitmap.SetPixel(j, i, result);
                        }
                    i--;
                }
                //write file (after file name):
                int tempj = j;

                for (; i < height && i * (height / 3) < endPosition - startPosition + FNSize && startPosition + i * (height / 3) < file_Size + FNSize; i++)
                    for (j = 0; j < (width / 3) * 3 && i * (height / 3) + (j / 3) < endPosition - startPosition + FNSize && startPosition + i * (height / 3) + (j / 3) < file_Size + FNSize; j++)
                    {
                        if (tempj != 0)
                        {
                            j = tempj;
                            tempj = 0;
                        }
                        byte2bool((byte)filecontent[startPosition + i * (height / 3) + j / 3 - FNSize], ref t);
                        pixel = inputBitmap.GetPixel(j, i);
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        byte2bool(r, ref rb);
                        byte2bool(g, ref gb);
                        byte2bool(b, ref bb);
                        if (j % 3 == 0)
                        {
                            rb[layer] = t[0];
                            gb[layer] = t[1];
                            bb[layer] = t[2];
                        }
                        else if (j % 3 == 1)
                        {
                            rb[layer] = t[3];
                            gb[layer] = t[4];
                            bb[layer] = t[5];
                        }
                        else
                        {
                            rb[layer] = t[6];
                            gb[layer] = t[7];
                        }
                        Color result = Color.FromArgb((int)bool2byte(rb), (int)bool2byte(gb), (int)bool2byte(bb));
                        outputBitmap.SetPixel(j, i, result);

                    }
                long tempFS = file_Size, tempFNS = file_NameSize;
                r = (byte)(tempFS % 100);
                tempFS /= 100;
                g = (byte)(tempFS % 100);
                tempFS /= 100;
                b = (byte)(tempFS % 100);
                Color flenColor = Color.FromArgb(r, g, b);
                outputBitmap.SetPixel(width - 1, height - 1, flenColor);

                r = (byte)(tempFNS % 100);
                tempFNS /= 100;
                g = (byte)(tempFNS % 100);
                tempFNS /= 100;
                b = (byte)(tempFNS % 100);
                Color fnlenColor = Color.FromArgb(r, g, b);
                outputBitmap.SetPixel(width - 2, height - 1, fnlenColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return outputBitmap;
        }
        private void byte2bool(byte inp, ref bool[] outp)
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
            
                byte outp = 0;
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



        public void dct(Bitmap bmp)
        {
            int x, y, width, height;
         //   Bitmap InputImage = new Bitmap(pictureBox1.ImageLocation);
            Bitmap InputImage = bmp;
            Image IMG = (Image)bmp;
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
            DCTMapImage.Image = (Image)ImgDCT.DCTMap;
 
        }
        private void lb_max_amt_data1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tb_image_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        

    }
}