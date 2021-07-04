using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageForensic
{
    public partial class TEmbed : Form
    {
        FastDCT2D ImgDCT;
        string image_path, File_Path, savetoimage = "", loadedFilePath = "", DLoadImagePath, DSaveFilePath;
        Image img, DecryptedImage, AfterEncryption;
        int height, width;
        long file_Size, file_NameSize;
        Bitmap enc_bitmap, DecryptedBitmap;
        bool canpaint = false, EncriptionDone = false;
        PictureBox pic;
        byte[] filecontent;
        Rectangle previewImage = new Rectangle(20, 160, 490, 470);
        public int rec_width, rec_height;
        public int scale = 25; // Scaling percentage
        public int WindowSize = 256;  // Dimension of Image Selection Window
        double[,] DCTCoefficients;
        public TEmbed()
        {
            InitializeComponent();
        }
        private string justFName(string path)
        {

            string output = "";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Bt_embbd_Click(object sender, EventArgs e)
        {

        }
    }
}
