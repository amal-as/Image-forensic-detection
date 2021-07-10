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
    public partial class Noise : Form
    {
        public static int c = 0;
        public static Bitmap dct;
        public static Bitmap sdct;
        public Noise(Bitmap orgdct,Bitmap suspdct)
        {
            InitializeComponent();
            dct = orgdct;
            sdct = suspdct;
            pdctorginal.Image = (Image)orgdct;
            targetpic.Image = (Image)Program.suspected;
            orginalpic.Image = (Image)Program.orginal;
           // ApplyFilter(true, "8");
            setup();
            newdct.Image = (Image)InverseDct4mQuantization2((Bitmap)pdctorginal.Image);
            comparedct.Image = (Image)difference((Bitmap)pdctorginal.Image, (Bitmap)newdct.Image);
            fillquantizationmatrix("1");
            callactive();
           
        }

        public void callactive()
        {
            if (Program.size == "s")
            {
                inactive();
                label11.Text = "No Noise deteceted....Picture is orginal...";
                
            }
            else
            {
                active();
                label11.Text = "Noise deteceted....Picture is compressed or not same..";
                label12.Visible = true;
                label13.Visible = true;
            }
        }


        private void ApplyFilter(bool preview,string no)
        {
            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = (Bitmap)targetpic.Image;
            }
            else
            {
                selectedSource = (Bitmap)targetpic.Image;
            }
            if (no == "1")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.GaussianBlur3x3);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }
                   
                }
            }
            else if (no == "2")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur5x5At45Degrees);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "3")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur9x9At45Degrees);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "4")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.Mean5x5);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "5")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.Mean7x7);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "6")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.Mean9x9);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "7")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur9x9);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "8")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur5x5At135Degrees);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "9")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur9x9At45Degrees);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }
            else if (no == "10")
            {
                if (selectedSource != null)
                {
                    ExtBitmap.BlurType blurType =
                        ((ExtBitmap.BlurType)ExtBitmap.BlurType.MotionBlur7x7At45Degrees);

                    bitmapResult = selectedSource.ImageBlurFilter(blurType);
                }
                if (bitmapResult != null)
                {
                    if (preview == true)
                    {
                        picPreview.Image = bitmapResult;
                    }

                }
            }









          
           
        }

        public void setup()
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
        }
        public void fillquantizationmatrix(string n)
        {

            if (n == "1")
            {
                picPreview.Image = (Image)Program.orginal;
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "1"));
                addNoise((Bitmap)newdct.Image, (Bitmap)comparedct.Image);
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
            else if (n == "2")
            {
                ApplyFilter(true, "3");
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "2"));
                addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
                dataGridView1.Rows[0].Cells[0].Value = "13";
                dataGridView1.Rows[0].Cells[1].Value = "14";
                dataGridView1.Rows[0].Cells[2].Value = "10";
                dataGridView1.Rows[0].Cells[3].Value = "15";
                dataGridView1.Rows[0].Cells[4].Value = "264";
                dataGridView1.Rows[0].Cells[5].Value = "450";
                dataGridView1.Rows[0].Cells[6].Value = "541";
                dataGridView1.Rows[0].Cells[7].Value = "261";

                dataGridView1.Rows[1].Cells[0].Value = "112";
                dataGridView1.Rows[1].Cells[1].Value = "12";
                dataGridView1.Rows[1].Cells[2].Value = "104";
                dataGridView1.Rows[1].Cells[3].Value = "19";
                dataGridView1.Rows[1].Cells[4].Value = "16";
                dataGridView1.Rows[1].Cells[5].Value = "581";
                dataGridView1.Rows[1].Cells[6].Value = "60";
                dataGridView1.Rows[1].Cells[7].Value = "55";

                dataGridView1.Rows[2].Cells[0].Value = "142";
                dataGridView1.Rows[2].Cells[1].Value = "13";
                dataGridView1.Rows[2].Cells[2].Value = "16";
                dataGridView1.Rows[2].Cells[3].Value = "24";
                dataGridView1.Rows[2].Cells[4].Value = "40";
                dataGridView1.Rows[2].Cells[5].Value = "57";
                dataGridView1.Rows[2].Cells[6].Value = "69";
                dataGridView1.Rows[2].Cells[7].Value = "56";

                dataGridView1.Rows[3].Cells[0].Value = "94";
                dataGridView1.Rows[3].Cells[1].Value = "4";
                dataGridView1.Rows[3].Cells[2].Value = "2";
                dataGridView1.Rows[3].Cells[3].Value = "9";
                dataGridView1.Rows[3].Cells[4].Value = "541";
                dataGridView1.Rows[3].Cells[5].Value = "57";
                dataGridView1.Rows[3].Cells[6].Value = "80";
                dataGridView1.Rows[3].Cells[7].Value = "62";

                dataGridView1.Rows[4].Cells[0].Value = "68";
                dataGridView1.Rows[4].Cells[1].Value = "62";
                dataGridView1.Rows[4].Cells[2].Value = "347";
                dataGridView1.Rows[4].Cells[3].Value = "536";
                dataGridView1.Rows[4].Cells[4].Value = "62";
                dataGridView1.Rows[4].Cells[5].Value = "19";
                dataGridView1.Rows[4].Cells[6].Value = "3";
                dataGridView1.Rows[4].Cells[7].Value = "727";

                dataGridView1.Rows[5].Cells[0].Value = "21";
                dataGridView1.Rows[5].Cells[1].Value = "31";
                dataGridView1.Rows[5].Cells[2].Value = "12";
                dataGridView1.Rows[5].Cells[3].Value = "63";
                dataGridView1.Rows[5].Cells[4].Value = "85";
                dataGridView1.Rows[5].Cells[5].Value = "4";
                dataGridView1.Rows[5].Cells[6].Value = "13";
                dataGridView1.Rows[5].Cells[7].Value = "9";

                dataGridView1.Rows[6].Cells[0].Value = "19";
                dataGridView1.Rows[6].Cells[1].Value = "34";
                dataGridView1.Rows[6].Cells[2].Value = "58";
                dataGridView1.Rows[6].Cells[3].Value = "67";
                dataGridView1.Rows[6].Cells[4].Value = "03";
                dataGridView1.Rows[6].Cells[5].Value = "11";
                dataGridView1.Rows[6].Cells[6].Value = "10";
                dataGridView1.Rows[6].Cells[7].Value = "11";

                dataGridView1.Rows[7].Cells[0].Value = "62";
                dataGridView1.Rows[7].Cells[1].Value = "62";
                dataGridView1.Rows[7].Cells[2].Value = "75";
                dataGridView1.Rows[7].Cells[3].Value = "98";
                dataGridView1.Rows[7].Cells[4].Value = "712";
                dataGridView1.Rows[7].Cells[5].Value = "160";
                dataGridView1.Rows[7].Cells[6].Value = "153";
                dataGridView1.Rows[7].Cells[7].Value = "96";
            }
            else if (n == "3")
            {
                ApplyFilter(true, "4");
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "3"));
                addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
                dataGridView1.Rows[0].Cells[0].Value = "19";
                dataGridView1.Rows[0].Cells[1].Value = "2";
                dataGridView1.Rows[0].Cells[2].Value = "1";
                dataGridView1.Rows[0].Cells[3].Value = "13";
                dataGridView1.Rows[0].Cells[4].Value = "4";
                dataGridView1.Rows[0].Cells[5].Value = "50";
                dataGridView1.Rows[0].Cells[6].Value = "51";
                dataGridView1.Rows[0].Cells[7].Value = "1";

                dataGridView1.Rows[1].Cells[0].Value = "12";
                dataGridView1.Rows[1].Cells[1].Value = "11";
                dataGridView1.Rows[1].Cells[2].Value = "4";
                dataGridView1.Rows[1].Cells[3].Value = "19";
                dataGridView1.Rows[1].Cells[4].Value = "16";
                dataGridView1.Rows[1].Cells[5].Value = "51";
                dataGridView1.Rows[1].Cells[6].Value = "10";
                dataGridView1.Rows[1].Cells[7].Value = "15";

                dataGridView1.Rows[2].Cells[0].Value = "42";
                dataGridView1.Rows[2].Cells[1].Value = "113";
                dataGridView1.Rows[2].Cells[2].Value = "116";
                dataGridView1.Rows[2].Cells[3].Value = "124";
                dataGridView1.Rows[2].Cells[4].Value = "140";
                dataGridView1.Rows[2].Cells[5].Value = "157";
                dataGridView1.Rows[2].Cells[6].Value = "69";
                dataGridView1.Rows[2].Cells[7].Value = "56";

                dataGridView1.Rows[3].Cells[0].Value = "94";
                dataGridView1.Rows[3].Cells[1].Value = "3";
                dataGridView1.Rows[3].Cells[2].Value = "45";
                dataGridView1.Rows[3].Cells[3].Value = "32";
                dataGridView1.Rows[3].Cells[4].Value = "541";
                dataGridView1.Rows[3].Cells[5].Value = "57";
                dataGridView1.Rows[3].Cells[6].Value = "80";
                dataGridView1.Rows[3].Cells[7].Value = "62";

                dataGridView1.Rows[4].Cells[0].Value = "38";
                dataGridView1.Rows[4].Cells[1].Value = "12";
                dataGridView1.Rows[4].Cells[2].Value = "47";
                dataGridView1.Rows[4].Cells[3].Value = "6";
                dataGridView1.Rows[4].Cells[4].Value = "62";
                dataGridView1.Rows[4].Cells[5].Value = "19";
                dataGridView1.Rows[4].Cells[6].Value = "32";
                dataGridView1.Rows[4].Cells[7].Value = "717";

                dataGridView1.Rows[5].Cells[0].Value = "21";
                dataGridView1.Rows[5].Cells[1].Value = "313";
                dataGridView1.Rows[5].Cells[2].Value = "2";
                dataGridView1.Rows[5].Cells[3].Value = "263";
                dataGridView1.Rows[5].Cells[4].Value = "845";
                dataGridView1.Rows[5].Cells[5].Value = "32";
                dataGridView1.Rows[5].Cells[6].Value = "11";
                dataGridView1.Rows[5].Cells[7].Value = "2";

                dataGridView1.Rows[6].Cells[0].Value = "19";
                dataGridView1.Rows[6].Cells[1].Value = "34";
                dataGridView1.Rows[6].Cells[2].Value = "528";
                dataGridView1.Rows[6].Cells[3].Value = "61";
                dataGridView1.Rows[6].Cells[4].Value = "12";
                dataGridView1.Rows[6].Cells[5].Value = "13";
                dataGridView1.Rows[6].Cells[6].Value = "13";
                dataGridView1.Rows[6].Cells[7].Value = "11";

                dataGridView1.Rows[7].Cells[0].Value = "62";
                dataGridView1.Rows[7].Cells[1].Value = "62";
                dataGridView1.Rows[7].Cells[2].Value = "75";
                dataGridView1.Rows[7].Cells[3].Value = "98";
                dataGridView1.Rows[7].Cells[4].Value = "712";
                dataGridView1.Rows[7].Cells[5].Value = "160";
                dataGridView1.Rows[7].Cells[6].Value = "153";
                dataGridView1.Rows[7].Cells[7].Value = "96";
            }
            else if (n == "4")
            {
                ApplyFilter(true, "5");
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "4"));
                addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
                dataGridView1.Rows[0].Cells[0].Value = "19";
                dataGridView1.Rows[0].Cells[1].Value = "2";
                dataGridView1.Rows[0].Cells[2].Value = "1";
                dataGridView1.Rows[0].Cells[3].Value = "13";
                dataGridView1.Rows[0].Cells[4].Value = "4";
                dataGridView1.Rows[0].Cells[5].Value = "50";
                dataGridView1.Rows[0].Cells[6].Value = "51";
                dataGridView1.Rows[0].Cells[7].Value = "1";

                dataGridView1.Rows[1].Cells[0].Value = "12";
                dataGridView1.Rows[1].Cells[1].Value = "11";
                dataGridView1.Rows[1].Cells[2].Value = "4";
                dataGridView1.Rows[1].Cells[3].Value = "19";
                dataGridView1.Rows[1].Cells[4].Value = "16";
                dataGridView1.Rows[1].Cells[5].Value = "51";
                dataGridView1.Rows[1].Cells[6].Value = "10";
                dataGridView1.Rows[1].Cells[7].Value = "15";

                dataGridView1.Rows[2].Cells[0].Value = "42";
                dataGridView1.Rows[2].Cells[1].Value = "113";
                dataGridView1.Rows[2].Cells[2].Value = "116";
                dataGridView1.Rows[2].Cells[3].Value = "124";
                dataGridView1.Rows[2].Cells[4].Value = "140";
                dataGridView1.Rows[2].Cells[5].Value = "157";
                dataGridView1.Rows[2].Cells[6].Value = "69";
                dataGridView1.Rows[2].Cells[7].Value = "56";

                dataGridView1.Rows[3].Cells[0].Value = "94";
                dataGridView1.Rows[3].Cells[1].Value = "3";
                dataGridView1.Rows[3].Cells[2].Value = "45";
                dataGridView1.Rows[3].Cells[3].Value = "32";
                dataGridView1.Rows[3].Cells[4].Value = "541";
                dataGridView1.Rows[3].Cells[5].Value = "57";
                dataGridView1.Rows[3].Cells[6].Value = "80";
                dataGridView1.Rows[3].Cells[7].Value = "62";

                dataGridView1.Rows[4].Cells[0].Value = "38";
                dataGridView1.Rows[4].Cells[1].Value = "12";
                dataGridView1.Rows[4].Cells[2].Value = "47";
                dataGridView1.Rows[4].Cells[3].Value = "6";
                dataGridView1.Rows[4].Cells[4].Value = "62";
                dataGridView1.Rows[4].Cells[5].Value = "19";
                dataGridView1.Rows[4].Cells[6].Value = "32";
                dataGridView1.Rows[4].Cells[7].Value = "717";

                dataGridView1.Rows[5].Cells[0].Value = "21";
                dataGridView1.Rows[5].Cells[1].Value = "31";
                dataGridView1.Rows[5].Cells[2].Value = "12";
                dataGridView1.Rows[5].Cells[3].Value = "63";
                dataGridView1.Rows[5].Cells[4].Value = "85";
                dataGridView1.Rows[5].Cells[5].Value = "4";
                dataGridView1.Rows[5].Cells[6].Value = "13";
                dataGridView1.Rows[5].Cells[7].Value = "9";

                dataGridView1.Rows[6].Cells[0].Value = "19";
                dataGridView1.Rows[6].Cells[1].Value = "34";
                dataGridView1.Rows[6].Cells[2].Value = "58";
                dataGridView1.Rows[6].Cells[3].Value = "67";
                dataGridView1.Rows[6].Cells[4].Value = "03";
                dataGridView1.Rows[6].Cells[5].Value = "11";
                dataGridView1.Rows[6].Cells[6].Value = "10";
                dataGridView1.Rows[6].Cells[7].Value = "11";

                dataGridView1.Rows[7].Cells[0].Value = "62";
                dataGridView1.Rows[7].Cells[1].Value = "62";
                dataGridView1.Rows[7].Cells[2].Value = "75";
                dataGridView1.Rows[7].Cells[3].Value = "98";
                dataGridView1.Rows[7].Cells[4].Value = "712";
                dataGridView1.Rows[7].Cells[5].Value = "160";
                dataGridView1.Rows[7].Cells[6].Value = "153";
                dataGridView1.Rows[7].Cells[7].Value = "96";
            }
            else if (n == "5")
            {
                ApplyFilter(true, "9");
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "2"));
                addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
                dataGridView1.Rows[0].Cells[0].Value = "19";
                dataGridView1.Rows[0].Cells[1].Value = "2";
                dataGridView1.Rows[0].Cells[2].Value = "1";
                dataGridView1.Rows[0].Cells[3].Value = "13";
                dataGridView1.Rows[0].Cells[4].Value = "4";
                dataGridView1.Rows[0].Cells[5].Value = "50";
                dataGridView1.Rows[0].Cells[6].Value = "51";
                dataGridView1.Rows[0].Cells[7].Value = "1";

                dataGridView1.Rows[1].Cells[0].Value = "12";
                dataGridView1.Rows[1].Cells[1].Value = "11";
                dataGridView1.Rows[1].Cells[2].Value = "4";
                dataGridView1.Rows[1].Cells[3].Value = "19";
                dataGridView1.Rows[1].Cells[4].Value = "16";
                dataGridView1.Rows[1].Cells[5].Value = "51";
                dataGridView1.Rows[1].Cells[6].Value = "10";
                dataGridView1.Rows[1].Cells[7].Value = "15";

                dataGridView1.Rows[2].Cells[0].Value = "42";
                dataGridView1.Rows[2].Cells[1].Value = "113";
                dataGridView1.Rows[2].Cells[2].Value = "116";
                dataGridView1.Rows[2].Cells[3].Value = "124";
                dataGridView1.Rows[2].Cells[4].Value = "140";
                dataGridView1.Rows[2].Cells[5].Value = "157";
                dataGridView1.Rows[2].Cells[6].Value = "69";
                dataGridView1.Rows[2].Cells[7].Value = "56";

                dataGridView1.Rows[3].Cells[0].Value = "94";
                dataGridView1.Rows[3].Cells[1].Value = "3";
                dataGridView1.Rows[3].Cells[2].Value = "45";
                dataGridView1.Rows[3].Cells[3].Value = "32";
                dataGridView1.Rows[3].Cells[4].Value = "541";
                dataGridView1.Rows[3].Cells[5].Value = "57";
                dataGridView1.Rows[3].Cells[6].Value = "80";
                dataGridView1.Rows[3].Cells[7].Value = "62";

                dataGridView1.Rows[4].Cells[0].Value = "38";
                dataGridView1.Rows[4].Cells[1].Value = "12";
                dataGridView1.Rows[4].Cells[2].Value = "47";
                dataGridView1.Rows[4].Cells[3].Value = "6";
                dataGridView1.Rows[4].Cells[4].Value = "62";
                dataGridView1.Rows[4].Cells[5].Value = "19";
                dataGridView1.Rows[4].Cells[6].Value = "32";
                dataGridView1.Rows[4].Cells[7].Value = "717";

                dataGridView1.Rows[5].Cells[0].Value = "21";
                dataGridView1.Rows[5].Cells[1].Value = "313";
                dataGridView1.Rows[5].Cells[2].Value = "2";
                dataGridView1.Rows[5].Cells[3].Value = "263";
                dataGridView1.Rows[5].Cells[4].Value = "845";
                dataGridView1.Rows[5].Cells[5].Value = "32";
                dataGridView1.Rows[5].Cells[6].Value = "11";
                dataGridView1.Rows[5].Cells[7].Value = "2";

                dataGridView1.Rows[6].Cells[0].Value = "19";
                dataGridView1.Rows[6].Cells[1].Value = "34";
                dataGridView1.Rows[6].Cells[2].Value = "528";
                dataGridView1.Rows[6].Cells[3].Value = "61";
                dataGridView1.Rows[6].Cells[4].Value = "12";
                dataGridView1.Rows[6].Cells[5].Value = "13";
                dataGridView1.Rows[6].Cells[6].Value = "13";
                dataGridView1.Rows[6].Cells[7].Value = "11";

                dataGridView1.Rows[7].Cells[0].Value = "62";
                dataGridView1.Rows[7].Cells[1].Value = "62";
                dataGridView1.Rows[7].Cells[2].Value = "75";
                dataGridView1.Rows[7].Cells[3].Value = "98";
                dataGridView1.Rows[7].Cells[4].Value = "712";
                dataGridView1.Rows[7].Cells[5].Value = "160";
                dataGridView1.Rows[7].Cells[6].Value = "153";
                dataGridView1.Rows[7].Cells[7].Value = "96";
            }
            else if (n == "6")
            {
                ApplyFilter(true, "6");
                psuspdct.Image = (Image)(InverseDct4mQuantization((Bitmap)pdctorginal.Image, "5"));
                addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
                dataGridView1.Rows[0].Cells[0].Value = "19";
                dataGridView1.Rows[0].Cells[1].Value = "2";
                dataGridView1.Rows[0].Cells[2].Value = "1";
                dataGridView1.Rows[0].Cells[3].Value = "13";
                dataGridView1.Rows[0].Cells[4].Value = "4";
                dataGridView1.Rows[0].Cells[5].Value = "50";
                dataGridView1.Rows[0].Cells[6].Value = "51";
                dataGridView1.Rows[0].Cells[7].Value = "1";

                dataGridView1.Rows[1].Cells[0].Value = "12";
                dataGridView1.Rows[1].Cells[1].Value = "11";
                dataGridView1.Rows[1].Cells[2].Value = "4";
                dataGridView1.Rows[1].Cells[3].Value = "19";
                dataGridView1.Rows[1].Cells[4].Value = "16";
                dataGridView1.Rows[1].Cells[5].Value = "51";
                dataGridView1.Rows[1].Cells[6].Value = "10";
                dataGridView1.Rows[1].Cells[7].Value = "15";

                dataGridView1.Rows[2].Cells[0].Value = "42";
                dataGridView1.Rows[2].Cells[1].Value = "113";
                dataGridView1.Rows[2].Cells[2].Value = "116";
                dataGridView1.Rows[2].Cells[3].Value = "124";
                dataGridView1.Rows[2].Cells[4].Value = "140";
                dataGridView1.Rows[2].Cells[5].Value = "157";
                dataGridView1.Rows[2].Cells[6].Value = "69";
                dataGridView1.Rows[2].Cells[7].Value = "56";

                dataGridView1.Rows[3].Cells[0].Value = "94";
                dataGridView1.Rows[3].Cells[1].Value = "3";
                dataGridView1.Rows[3].Cells[2].Value = "45";
                dataGridView1.Rows[3].Cells[3].Value = "32";
                dataGridView1.Rows[3].Cells[4].Value = "541";
                dataGridView1.Rows[3].Cells[5].Value = "57";
                dataGridView1.Rows[3].Cells[6].Value = "80";
                dataGridView1.Rows[3].Cells[7].Value = "62";

                dataGridView1.Rows[4].Cells[0].Value = "38";
                dataGridView1.Rows[4].Cells[1].Value = "12";
                dataGridView1.Rows[4].Cells[2].Value = "47";
                dataGridView1.Rows[4].Cells[3].Value = "6";
                dataGridView1.Rows[4].Cells[4].Value = "62";
                dataGridView1.Rows[4].Cells[5].Value = "19";
                dataGridView1.Rows[4].Cells[6].Value = "32";
                dataGridView1.Rows[4].Cells[7].Value = "717";

                dataGridView1.Rows[5].Cells[0].Value = "21";
                dataGridView1.Rows[5].Cells[1].Value = "313";
                dataGridView1.Rows[5].Cells[2].Value = "2";
                dataGridView1.Rows[5].Cells[3].Value = "263";
                dataGridView1.Rows[5].Cells[4].Value = "845";
                dataGridView1.Rows[5].Cells[5].Value = "32";
                dataGridView1.Rows[5].Cells[6].Value = "11";
                dataGridView1.Rows[5].Cells[7].Value = "2";

                dataGridView1.Rows[6].Cells[0].Value = "19";
                dataGridView1.Rows[6].Cells[1].Value = "34";
                dataGridView1.Rows[6].Cells[2].Value = "528";
                dataGridView1.Rows[6].Cells[3].Value = "61";
                dataGridView1.Rows[6].Cells[4].Value = "12";
                dataGridView1.Rows[6].Cells[5].Value = "13";
                dataGridView1.Rows[6].Cells[6].Value = "13";
                dataGridView1.Rows[6].Cells[7].Value = "11";

                dataGridView1.Rows[7].Cells[0].Value = "62";
                dataGridView1.Rows[7].Cells[1].Value = "62";
                dataGridView1.Rows[7].Cells[2].Value = "75";
                dataGridView1.Rows[7].Cells[3].Value = "98";
                dataGridView1.Rows[7].Cells[4].Value = "712";
                dataGridView1.Rows[7].Cells[5].Value = "160";
                dataGridView1.Rows[7].Cells[6].Value = "153";
                dataGridView1.Rows[7].Cells[7].Value = "96";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c++;
            if (c == 7)
            {
                c = 0;
            }
            fillquantizationmatrix(c.ToString());
            newdct.Image = (Image)InverseDct4mQuantization2((Bitmap)pdctorginal.Image);
            comparedct.Image = (Image)difference((Bitmap)pdctorginal.Image, (Bitmap)newdct.Image);
            addNoise((Bitmap)pdctorginal.Image, (Bitmap)comparedct.Image);
            
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
                    if (originalColor.R > 250)
                    {
                        Color newcolor = GetRgb(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.G > 250)
                    {
                        Color newcolor = GetRgb1(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else if (originalColor.B > 250)
                    {
                        Color newcolor = GetRgb2(originalColor.R, originalColor.G, originalColor.B);
                        newBitmap.SetPixel(i, j, newcolor);
                    }
                    else
                    {
                        c++;
                        newBitmap.SetPixel(i, j, Color.White);
                    }
                }

                decimal total = orgDCT.Width * orgDCT.Height;
                decimal change = ((total - c) / total) * 100;

                label12.Text = Math.Round(change, 2).ToString() + " %";

            }
            return newBitmap;

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
       
            picnoise.Image = (Image)noisesignal;
            

           

               
            

           
        }
        public static Color NewGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g), (byte)(b));

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

        public Bitmap InverseDct4mQuantization(Bitmap scrBitmap,string n)
        {
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            if (n == "1")
            {
               
                for (int i = 0; i < scrBitmap.Width; i++)
                {
                    for (int j = 0; j < scrBitmap.Height; j++)
                    {
                        Color originalColor = scrBitmap.GetPixel(i, j);
                        if (originalColor.R > 250)
                        {
                            Color newcolor = xGetRgb(originalColor.R, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.G > 180)
                        {
                            Color newcolor = xGetRgb1(originalColor.R, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.B > 180)
                        {
                            Color newcolor = xGetRgb2(originalColor.R, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, originalColor);
                        }
                    }


                }
            }
            else if (n == "2")
            {
                for (int i = 0; i < scrBitmap.Width; i++)
                {
                    for (int j = 0; j < scrBitmap.Height; j++)
                    {
                        Color originalColor = scrBitmap.GetPixel(i, j);
                        if (originalColor.R > 250)
                        {
                            Color newcolor = nGetRgb(originalColor.R-1, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.G > 180)
                        {
                            Color newcolor = nGetRgb1(originalColor.R, originalColor.G-1, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.B > 180)
                        {
                            Color newcolor = nGetRgb2(originalColor.R, originalColor.G, originalColor.B-1);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, originalColor);
                        }
                    }


                }
            }
            else if (n == "3")
            {
                for (int i = 0; i < scrBitmap.Width; i++)
                {
                    for (int j = 0; j < scrBitmap.Height; j++)
                    {
                        Color originalColor = scrBitmap.GetPixel(i, j);
                        if (originalColor.R > 250)
                        {
                            Color newcolor = nGetRgb(originalColor.R - 1, originalColor.G - 1, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.G > 180)
                        {
                            Color newcolor = nGetRgb1(originalColor.R, originalColor.G - 1, originalColor.B - 1);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.B > 180)
                        {
                            Color newcolor = nGetRgb2(originalColor.R - 1, originalColor.G, originalColor.B - 1);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, originalColor);
                        }
                    }
                }
            }
            else if (n == "4")
            {
                for (int i = 0; i < scrBitmap.Width; i++)
                {
                    for (int j = 0; j < scrBitmap.Height; j++)
                    {
                        Color originalColor = scrBitmap.GetPixel(i, j);
                        if (originalColor.R > 250)
                        {
                            Color newcolor = nGetRgb(originalColor.R - 1, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.G > 180)
                        {
                            Color newcolor = nGetRgb1(originalColor.R, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.B > 180)
                        {
                            Color newcolor = nGetRgb2(originalColor.R - 1, originalColor.G, originalColor.B - 1);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, originalColor);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < scrBitmap.Width; i++)
                {
                    for (int j = 0; j < scrBitmap.Height; j++)
                    {
                        Color originalColor = scrBitmap.GetPixel(i, j);
                        if (originalColor.R > 250)
                        {
                            Color newcolor = nGetRgb(originalColor.R , originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.G > 180)
                        {
                            Color newcolor = nGetRgb1(originalColor.R, originalColor.G, originalColor.B);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else if (originalColor.B > 180)
                        {
                            Color newcolor = nGetRgb2(originalColor.R - 1, originalColor.G, originalColor.B - 1);
                            newBitmap.SetPixel(i, j, newcolor);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, originalColor);
                        }
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

        public static Color xGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r - 5), (byte)(g - 1), (byte)(b - 1));
        }
        public static Color xGetRgb1(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r - 1), (byte)(g - 5), (byte)(b - 1));
        }
        public static Color xGetRgb2(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r - 1), (byte)(g - 1), (byte)(b - 5));
        }

        public Bitmap InverseDct4mQuantization2(Bitmap scrBitmap)
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

        public static Color yGetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r - 1), (byte)(g), (byte)(b));

        }
        public static Color yGetRgb1(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g - 1), (byte)(b));

        }
        public static Color yGetRgb2(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r), (byte)(g), (byte)(b - 1));


        }

        public void inactive()
        {
           
            label1.Visible = false;
            label8.Visible = false;
            label2.Visible = false;
            label9.Visible = false;
            label6.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            dataGridView1.Visible = false;
            button1.Visible = false;
            picnoise.Visible = false;
            panel9.Visible =false;
        }
        public void active()
        {
            label4.Visible = true;
            label1.Visible = true;
            label8.Visible = true;
            label2.Visible = true;
            label9.Visible = true;
            label6.Visible = true;
            panel3.Visible = true;
            panel5.Visible = true;
            panel7.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = true;
            picnoise.Visible = true;
            panel9.Visible = true;
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Baseform OBJ = new Baseform();
            ActiveForm.Hide();
            OBJ.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
