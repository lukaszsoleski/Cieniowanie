using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SGGW.MR.Cienowanie
{
    public class Shader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">Assumption: the picture is in grayscale, square, where the side is 2 ^ n</param>
        /// <returns></returns>
        public static Bitmap BlackAndWhiteShading(Bitmap bitmap)
        {
            Bitmap img = new Bitmap( bitmap.Width, bitmap.Height);
            Color c;
            int depth = (int)Math.Log(bitmap.Height,2.0);
            Curve curve = Hilbert.Discretization(depth);

            double [,] pixels_intensity = IntensityOfPixelsA(bitmap);
            int pixel;
            double E = 0;
            int x, y;
            for (int i = 0; i < curve.Length; i++)
            {
                x = (int)curve.X[i];
                y = (int)curve.Y[i];

                if (pixels_intensity[x,y] + E <= 0.5)
                {
                    pixel = 0;
                }else
                {
                    pixel = 1;
                }
                E = pixels_intensity[x, y] - pixel + E;
                pixel *= 255;
                c = (pixel == 1) ? Color.White : Color.Black;
                img.SetPixel(x, y, c);
            }
            return img;
        }


        public static double [,] IntensityOfPixelsA(Bitmap bitmap)
        {
            int w = bitmap.Width, h = bitmap.Height;
            double[,] I = new double[h, w];
            Color c; 

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = bitmap.GetPixel(x, y);
                    I[x, y] = c.A / 255;
                }
            }
            return I;
        }

    }
}
