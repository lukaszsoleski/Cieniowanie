using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SGGW.MR.Cieniowanie
{
    public class Shader
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">Image to shade</param>
        /// <param name="c1">The lighter color used for shading. White by default.</param>
        /// <param name="c2">The darker color used for shading. Black by default</param>
        /// <returns></returns>
        public static Bitmap TwoColoredShading(Bitmap bitmap,Color? c1 = null, Color? c2 = null)
        {
            Color c;
            // assign default values
            Color color1 = (c1 == null) ? Color.White : (Color)c1;
            Color color2 = (c2 == null) ? Color.Black : (Color)c2;
            //Convert to gray scale
            Bitmap img = RGB2GrayScale.Luma(bitmap);
            
            // longer side of the image
            int longerSide = (bitmap.Height > bitmap.Width) ? bitmap.Height : bitmap.Width;
            // depth of hilber curve
            int depth = (int)Math.Ceiling(Math.Log(longerSide,2.0));
            // Represents hilbert curve coordinates
            Curve curve = Hilbert.Discretization(depth);
            
            float [,] pixel_brihgtness = GetPixelsBrightness(bitmap);

            byte pixel;

            double E = 0;

            int x, y;

            for (int i = 0; i < curve.Length; i++)
            {
                x = (int)curve.X[i];
                y = (int)curve.Y[i];

                if( y < img.Height && x < img.Width)
                {
                  if (pixel_brihgtness[y,x] + E <= 0.5)
                  {
                      pixel = 0;
                  }else
                  {
                      pixel = 1;
                  }
                  E = pixel_brihgtness[y, x] - pixel + E;
              
                  c = (pixel > 0) ? color1 : color2;
                  img.SetPixel(x, y, c);
                }
            }
            return img;
        }


        public static float [,] GetPixelsBrightness(Bitmap bitmap)
        {
            int w = bitmap.Width, h = bitmap.Height;
            float[,] I = new float[h, w];
            Color c; 

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = bitmap.GetPixel(x, y);
           
                    I[y,x] = c.GetBrightness();
              //  float a = c.R/ 255.0f;
                  

                }
            }
            return I;
        }

    }
}
