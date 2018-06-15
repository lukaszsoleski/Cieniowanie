using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SGGW.MR.Cieniowanie
{
    static public class AppController
    {

        #region Raw image properties
        private static Bitmap _rawImage;
        public static Bitmap RawImage {
            get { return _rawImage; }
            set {
                _rawImage = value;
                RawImageHeight = _rawImage.Height;
                RawImageWidth = _rawImage.Width;
            } }
        /// <summary>
        /// Auto set property. Binds to RawImage property. 
        /// </summary>
        public static int RawImageHeight { get; private set; }
        /// <summary>
        /// Auto set property. Binds to RawImage property. 
        /// </summary>
        public static int RawImageWidth { get; private set; }
        /// <summary>
        /// Format: .*
        /// </summary>
        public static string RawImageExtention { get; set; }
        public static string RawImageDirectory { get; set; }
        /// <summary>
        /// File name without extension.
        /// </summary>
        public static string RawImageFileName { get; set; }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        public static string CustomSaveLocation { get; set; }
        /// <summary>
        /// By default it's same location as inserted image.
        /// </summary>

        /// <summary>
        /// Binds to selected ComboBox control with file extensions.
        /// </summary>

        public static string SelectedFileExtCB { get; set; }


        public static bool IsCustomLocation { get; set; }

        /// <summary>
        /// Represent new height of image. Binds to scale heigth text box. 
        /// </summary>
        public static int NewHeightOfTheOutputImage { get { return _nh; }
            set { _nh = value;
                if (_nh != RawImageHeight) ToNewResolution = true;
            } }
        private static int _nh = 0;

        /// <summary>
        /// Represent new width of image. Binds to scale width text box.
        /// </summary>
        public static int NewWidthOfTheOutputImage { get { return _nw; }
            set {
                _nw = value;
                if (_nw != RawImageWidth) ToNewResolution = true;
            } } 
        private static int _nw = 0;
        /// <summary>
        // Indicates whether resolution has changed.
        /// </summary>
        public static bool ToNewResolution { get; private set; } = false;

        /// <summary>
        /// Lighter color for shading.
        /// </summary>
        public static Color Color1 { get; set; } = Color.White;
        /// <summary>
        /// Darker color for shading
        /// </summary>
        public static Color Color2 { get; set; } = Color.Black;


        /// <summary>
        /// Auto save file to specified location after clicking start button.
        /// </summary>
        public static bool AutoSave { get; set; } = true;
        private static Bitmap _outputImage;
        public static Bitmap OutputImage
        {
            get { return _outputImage; }
            set
            {
                _outputImage = value;
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image">Image to shade</param>
        /// <param name="c1">Brighter color</param>
        /// <param name="c2">Darker color</param>
        /// <returns>Bitmap image shaded in two given colors</returns>
        public static Bitmap ShadeImage(Bitmap image, Color c1, Color c2)
        {
            
            if (image != null)
            {
              return (Shader.TwoColoredShading(new Bitmap(image),c1,c2));
            }
            else throw new ArgumentNullException("Cannot shade null referece object");


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image in gray scale</returns>
        private static Bitmap ConvertToGrayScale(Bitmap image)
        {
            if(image != null)
            return RGB2GrayScale.Luma(image);
            else throw new ArgumentNullException("Cannot convert to gray scale null reference object");

        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width , int height)
        {
            
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static string CombineSavePath()
        {
      
            if (IsCustomLocation)
            {
                return CustomSaveLocation;
            }
            else
            {
                return System.IO.Path.Combine(RawImageDirectory,RawImageFileName + SelectedFileExtCB);
            }
        }
    }
}
