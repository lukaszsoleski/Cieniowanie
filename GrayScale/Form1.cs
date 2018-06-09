using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GrayScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { //read image

            Bitmap bmp = new Bitmap(@"C:\Users\Luckz\Downloads\adorable-animal.png");

            //load original image in picturebox1
            pictureBox1.Image = Image.FromFile(@"C:\Users\Luckz\Downloads\adorable-animal.png");

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //algorith called 'luma' 
                    int gray = (int)((r * .3) + (g * .59) + (b * .11));

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));

                }
            }

            //load grayscale image in picturebox2
            pictureBox2.Image = bmp;

            //write the grayscale image
          //  bmp.Save("D:\\Image\\Grayscale.png");


        }
    }
}