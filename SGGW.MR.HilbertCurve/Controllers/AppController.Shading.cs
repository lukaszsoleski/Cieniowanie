using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SGGW.MR.Application
{

    public class ShadingController
    {
        private Bitmap _rawImage;
        public Bitmap RawImage {
            get { return _rawImage; }
            set
            {
                Bitmap b = value;
                int h, w;
                h = b.Height;
                w = b.Width;

                ImageIsSquare = (h == w) ? true : false;
                DimsOfTheImgAreThePowerOfTwo =
               (Math.Ceiling(Math.Log(h, 2)) % 2 == 0 &&
                    Math.Ceiling(Math.Log(w, 2)) % 2 == 0) ?
                        true : false;

                // Create new object so previews references won't be affected while shading
                _rawImage = new Bitmap(b);
            }

        }
        public bool ImageIsSquare { get; private set; }
        public bool DimsOfTheImgAreThePowerOfTwo { get; private set; }

        public Bitmap ShadedImage { get; set; }
        public string SavePath { get; set; }


        public async void ShadeImage()
        {
            //Saturday 09/06 |To DO: 
            //1. Async Shading
            //2. Async Hilbert Drawing if depth is greater then 8. 
            //3. Drawing Hilbert Lines
            // Pretty much done with project. 
            // Additional milestones: 
            // Shading in rgb. Give user possibility to pick colors palette. 
        }

    }
}
