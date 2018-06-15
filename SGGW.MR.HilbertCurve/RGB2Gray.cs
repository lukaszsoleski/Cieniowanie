using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 
namespace SGGW.MR.Cieniowanie
{
     public class RGB2GrayScale
     {

        public Bitmap BitmapImage { get; set; }


        public RGB2GrayScale()
        {
            this.BitmapImage = null;
        }
        public RGB2GrayScale(Bitmap bitmap)
        {
            this.BitmapImage = new Bitmap(bitmap);
        }
        public RGB2GrayScale(String path)
        {
            this.BitmapImage = new Bitmap(path);
        }


        public void ConvertToGrayScale()
        {
            Luma(BitmapImage);
        }

        public static Bitmap Luma(String path) => Luma(new Bitmap(path));

        public static Bitmap Luma(Bitmap image)
        {
            //read image
            Bitmap bmp = image;

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

                    //algorithm called 'luma' is less dirty then simple average
                    int gray = (int)((r * .3) + (g * .59) + (b * .11));

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));

                }
            }
            return bmp;
        }

    }
}

