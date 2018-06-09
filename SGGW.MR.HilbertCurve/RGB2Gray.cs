using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 
namespace SGGW.MR.Cienowanie
{
     public class RGB2GrayScale
     {
        /*
         1. Take the RGB value of the pixel.
         2. Do math.
         3. Replace the R, G and B value of the pixel with Avg.
    
        */

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

                    //algorith called 'luma' . It's less dirty then simple average
                    // human eye see differently  red green and blue colors
                    int gray = (int)((r * .3) + (g * .59) + (b * .11));

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray));

                }
            }
            return bmp;
        }

    }
}

