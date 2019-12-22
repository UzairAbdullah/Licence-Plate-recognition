using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace LicencePlateRecognition
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(open.FileName);
                pictureBox1.Image = imgInput.Bitmap;
            }
            //Image<Bgr, byte> imgContour = new Image<Bgr, byte>(open.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //Converting to greyscale
            Image<Gray, byte> imgOutput = imgInput.Convert<Gray,byte>().ThresholdBinary(new Gray(150), new Gray(255));
            Image<Gray, byte> gray = new Image<Gray, byte>(open.FileName);
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat hier = new Mat();
            CvInvoke.FindContours(imgOutput,contours,hier,Emgu.CV.CvEnum.RetrType.External,Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            CvInvoke.DrawContours(imgInput, contours, -1, new MCvScalar(255, 0, 0));
            CvInvoke.DrawContours(imgOutput, contours, -1, new MCvScalar(255, 0, 0));
            pictureBox2.Image = imgInput.Bitmap;
            pictureBox1.Image = imgOutput.Bitmap;

            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
       
            //pictureBox2.Image = grayscale.Bitmap;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
           // pictureBox1.Image = gray.Bitmap;


            //conversion to binary image
            //pictureBox3.Image = Image.FromFile(op.FileName);
            //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            //Bitmap img = new Bitmap(pictureBox2.Image);
            
            
            ///----------------BINARY IMAGE CODE------------------------------
            /*StringBuilder t = new StringBuilder();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    t.Append((img.GetPixel(i, j).R > 100 && img.GetPixel(i, j).G > 100 &&
                             img.GetPixel(i, j).B > 100) ? 0 : 1);
                }
                t.AppendLine();
            }
            Color c = Color.Black;
            Color v = Color.Black;
            int av = 0, k=0;
            for (int i = 0; i < greyscale.Width;i++ )
            {
                for (int j = 0; j < greyscale.Height;j++ )
                {
                    c = greyscale.GetPixel(i, j);
                    //av = (c.R + c.B + c.G) / 3;
                    v = Color.FromArgb(c.A, t[k], t[k], t[k]);
                    img.SetPixel(i, j, v);
                    k++;
                }
            }
              //  textBox1.Text = t.ToString();
            pictureBox1.Image = greyscale;
            pictureBox2.Image = img;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;*/





            //---------------Conversion to grayscale-----------//
            /*Bitmap greyscale = new Bitmap(open.FileName);
            
            int width = greyscale.Width;
            int height = greyscale.Height;
            Color color;
           for(int i =0;i<height;i++)
       {
           for (int j=0;j<width;j++)
           {
               color = greyscale.GetPixel(j, i);
               int a = color.A;
               int r = color.R;
               int g = color.G;
               int b = color.B;
               int avg = (r + g + b) / 3;

               greyscale.SetPixel(j, i, Color.FromArgb(a, avg, avg, avg));
           }
       }
       pictureBox2.Image = greyscale;*/
        }

    }
}
