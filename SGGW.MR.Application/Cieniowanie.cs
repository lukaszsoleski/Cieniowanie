using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using SGGW.MR.Cieniowanie;
using System.Diagnostics;
using MetroFramework.Controls;
using System.IO;

namespace SGGW.MR.Application

{
    public partial class Cieniowanie : MetroFramework.Forms.MetroForm
    {
        #region Constructor. Sets initial values.
        public Cieniowanie()
        {
            InitializeComponent();
            //Fixed size window
            this.Resizable = false;
            this.MaximizeBox = false;
           
            // Allow drop at picture box 
            ((Control)ShadingDragAndDropIB).AllowDrop = true;

            // set default value to ComboBox
            FileExtentionCB.Text = ".bmp";
            AppController.SelectedFileExtCB = ".bmp";

            // Add initial directory to text box that contains save as path
            CustomLocationTB.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           
            // Add initial logic to radio buttons. Use the same directory from wich image was inserted. 
            CustomPathControlsEnable(false);

            SameLocationRB.Select();

            ImageHeightTB.Enabled = false;
            ImageWidthTB.Enabled = false;

            // Auto save check box is checked
            AutoSaveCheckBox.Checked = true;

        }


        #endregion

#region Turn off or turn on the controls, depending on user choice. Binds to App Controller IsCustomLocation property. 
        /// <summary>
        /// Turn off or turn on the controls, depending on user choice. 
        /// Binds to App Controller IsCustomLocation property. 
        /// </summary>
        /// <param name="isCustomLocation">True if directory is custom or false if the same as given image.</param>

        private void CustomPathControlsEnable(bool isCustomLocation)
        {
            if (isCustomLocation)
            {
                AppController.IsCustomLocation = true;
                //Enable the CustomLocation TextBox 
                CustomLocationTB.Enabled = true;
                //Enable the  Save as button
                SaveAsButton.Enabled = true;
            } else
            {
                AppController.IsCustomLocation = false;
                //Disable the CustomLocation TextBox 
                CustomLocationTB.Enabled = false;
                //Disable the  Save as button
                SaveAsButton.Enabled = false;
            }

        }
        private void MetroSameLocationRB_CheckedChanged(object sender, EventArgs e)
        {
            if (SameLocationRB.Checked)
            {
                CustomPathControlsEnable(false);

            }
        }

        private void MetroCustomLocationRB_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomLocationRB.Checked)
            {
                CustomPathControlsEnable(true);
            }

        }
        #endregion


        #region Drag & drop image and click at image box events. Binds raw image data to app controller and UI. 

        private void SetAppControllerRawImageInfo(string path)
        {
            AppController.RawImageDirectory = System.IO.Path.GetDirectoryName(path);
            AppController.RawImageFileName = System.IO.Path.GetFileNameWithoutExtension(path);
            AppController.RawImageExtention = System.IO.Path.GetExtension(path); 
            AppController.RawImage = new Bitmap(Image.FromFile(path));

        }
        /// <summary>
        /// Enables text boxes and sets initial values. 
        /// </summary>
        /// <param name="h">Height of the image</param>
        /// <param name="w">Width of the image</param>
        private void SetImageResolusionTextBoxes(int h, int w)
        {
            ImageWidthTB.Enabled = true;
            ImageHeightTB.Enabled = true;
            ImageWidthTB.Text = w.ToString();
            ImageHeightTB.Text = h.ToString();
        }

        private void Cieniowanie_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// Gets a dropped image and binds it to AppController.RawImage and also sets path info. 
        /// Sets initial image resolution on text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cieniowanie_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //Binds image data to appcontroller. 
            SetAppControllerRawImageInfo(files[0]);
            // Sets ImageBox at UI 
            ShadingDragAndDropIB.Image = AppController.RawImage;
            // Insert resolution data into textboxes.
            SetImageResolusionTextBoxes(AppController.RawImage.Width, AppController.RawImage.Height);
        }


        /// <summary>
        /// Opens the file dialog at click on the image box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShadingDragAndDropImageBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Bitmap (*.bmp)|*.bmp|JPG|*.jpg|PNG|*.png|All files|*.*",
                FilterIndex = FileExtentionCB.SelectedIndex + 1
            };
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SetAppControllerRawImageInfo(ofd.FileName);
                    ShadingDragAndDropIB.Image = AppController.RawImage;
                    SetImageResolusionTextBoxes(AppController.RawImage.Width, AppController.RawImage.Height);

                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        #endregion 


        /// <summary>
        /// Bind the custom location AppController. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Bitmap (*.bmp)|*.bmp|JPG|*.jpg|PNG|*.png|All files|*.*"
            };
            sfd.InitialDirectory = CustomLocationTB.Text;

            sfd.FilterIndex = FileExtentionCB.SelectedIndex + 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CustomLocationTB.Text = sfd.FileName;
                // Binds to custom location AppController
                AppController.CustomSaveLocation = sfd.FileName;
            }


        }

        #region Pick Color Events. Validation and Binding to AppController 


        /// <summary>
        /// Binds to color properties in app controller and text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorTile_Click(object sender, EventArgs e)
        {
            MetroTile root = (MetroTile)sender;
            Color newColor = OpenColorDialog(root.ForeColor);

            if (root.Name == Color1Tile.Name) Color1TB.Text = newColor.ToHexString();
            else if (root.Name == Color2Tile.Name) Color2TB.Text = newColor.ToHexString();
            SetTileColor(root, newColor);

            if (root.Name == Color1Tile.Name) AppController.Color1 = newColor;
            else if (root.Name == Color2Tile.Name) AppController.Color2 = newColor;
     
        }

        /// <summary>
        /// Opens color dialog. If 'Ok' was clicked returns new color else previous color. 
        /// </summary>
        /// <param name="prevColor"></param>
        /// <returns></returns>
        private Color OpenColorDialog(Color prevColor)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                // Keeps the user from selecting a custom color.
                AllowFullOpen = true,
                // Allows the user to get help. (The default is false.)
                ShowHelp = true,
                // Sets the initial color select to the current text color.
                Color = prevColor
            };
            Color c = prevColor; 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                c = MyDialog.Color;

            }
            return c;
        }
        /// <summary>
        /// Sets tile backgoround color and also text color accordingly to background brightness. 
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="c"></param>
        private static void SetTileColor(MetroTile mt, Color c)
        {
            mt.BackColor = c;
            if (c.GetBrightness() > 0.4) mt.ForeColor = Color.Black;
            else mt.ForeColor = Color.White;
        }


        /// <summary>
        /// Validates text box if it lost focus. Prompts user if inserted text is not a valid 'html' color. 
        /// Binds to ColorTile. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorTB_Leave(object sender, EventArgs e)
        {
            MetroTextBox root;
            if (sender is MetroTextBox)
            {
                //get root object
                root = (MetroTextBox)sender;


                string text = ((MetroTextBox)sender).Text;
                Color c = root.BackColor;
                //Validate text box 
                bool isValid = CheckValidFormatHtmlColor(text);

                if (isValid)
                {
                    // Color is valid so we can convert it to Color structure.
                    c = text.FromHTMLToColor();

                    // Bind value to properties.
                    if (root.Name == Color1TB.Name)
                    {
                        SetTileColor(Color1Tile, c);
                        AppController.Color1 = c;
                    }
                    if (root.Name == Color2TB.Name)
                    {
                        SetTileColor(Color2Tile, c);
                        AppController.Color2 = c; 
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, $"Cannot convert { text } to a valid color.", "Notice");
                }
            }
            else MetroMessageBox.Show(this, $"Cannot convert this object.", "Notice");

        }
        protected static bool CheckValidFormatHtmlColor(string inputColor)
        {
            //regex from http://stackoverflow.com/a/1636354/2343
            if (System.Text.RegularExpressions.Regex.Match(inputColor, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
                return true;

            var result = System.Drawing.Color.FromName(inputColor);
            return result.IsKnownColor;
        }


        private void ColorTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ColorTB_Leave(sender, e);

                //Stop the 'Ding' when pressing Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion




        #region Validate image resolusion text boxes and bind them to app controller.
        /// <summary>
        /// Binds to AppController width of the output image. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateDimensionTB(object sender, EventArgs e)
        {
            MetroTextBox root = (MetroTextBox)sender;

            int num;
            int.TryParse(root.Text, out num);
            if (num > 0)
            {
                if (root.Name == ImageWidthTB.Name) AppController.NewWidthOfTheOutputImage = num;
                if (root.Name == ImageHeightTB.Name) AppController.NewHeightOfTheOutputImage = num;

            }
            else
            {
                MetroMessageBox.Show(this, $"Cannot convert {root.Text} to number", "Notice");
            }

        }


        private void ImageScale_OnEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidateDimensionTB(sender, e);
                //Stop the 'Ding' when pressing Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        #endregion



        #region Bind Selected index ComboBox and user custom location save path
        private void FileExtentionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppController.SelectedFileExtCB = (string)FileExtentionCB.SelectedItem;
        }

        private void CustomLocationTB_Leave(object sender, EventArgs e)
        {
            string userPath = CustomLocationTB.Text;
            if (ValidatePath(userPath))
            {
                AppController.CustomSaveLocation = userPath;
            }
  
            AppController.CustomSaveLocation = CustomLocationTB.Text;
        }
        private void CustomLocationTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustomLocationTB_Leave(sender, e);
                //Stop the 'Ding' when pressing Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private bool ValidatePath(string userPath)
        {
            if (Directory.Exists(Path.GetDirectoryName(userPath)))
            {
                if (File.Exists(userPath))
                {
                    MetroMessageBox.Show(this, "This file already exist. Please change destination path.", "Notice");
                    return false;
                }
                // path is correct
                return true;

            }
            else
            {
                MetroMessageBox.Show(this, "This directory haven't been created yet. Please select existing folder.", "Notice");
                return false;
            }

        }

        /// <summary>
        /// Save output file to selected directory. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(AppController.OutputImage != null)
            {
                string path = AppController.CombineSavePath();
                DialogResult result = DialogResult.No;
              
                if (File.Exists(path))
                {
                    result = MetroMessageBox.Show(this, "File already exists, do you want to override it ? ", "Notice", MessageBoxButtons.YesNo);
        
                }else
                {
                    Bitmap s = new Bitmap(AppController.OutputImage);
                    s.Save(path);
                    s.Dispose();
                }
                
                if (DialogResult.Yes == result)
                {
                    Bitmap s = new Bitmap(AppController.OutputImage);
                    s.Save(path);
                    s.Dispose();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "File haven't been converted yet. Please select image and press start.", "Notice"); 
            }
        }
         
        #endregion


        private void StartTile_Click(object sender, EventArgs e)
        {
         
            if (AppController.RawImage != null)
            {
                Bitmap result = null;
                if (AppController.ToNewResolution)
                {
                    result = AppController.ResizeImage(                        
                        AppController.RawImage, AppController.NewWidthOfTheOutputImage, AppController.NewHeightOfTheOutputImage);
                }
                
                result = AppController.ShadeImage(AppController.RawImage, AppController.Color1, AppController.Color2);
                
                AppController.OutputImage = new Bitmap(result);
                ShadingPreviewIB.Image = AppController.OutputImage;
                
                if (AppController.AutoSave)
                {
                    SaveBtn_Click(null, null); 
                }
                result.Dispose();
                MetroMessageBox.Show(this, "Done", "Notice");

            }
            else
            {
                MetroMessageBox.Show(this, "Please insert the image file you want to convert.", "Notice");
            }

        }

        private void AutoSave_CheckedChanged(object sender, EventArgs e)
        {
            AppController.AutoSave = AutoSaveCheckBox.Checked;
        }



    }



    #region ColorTranslator extension methods
    /// <summary>
    /// Extension methods must be defined in non-generic, non-nested and static class.
    /// </summary>
    public static class ExtensionMethods {
        /// <summary>
        /// An extension method for converting a color structure to a hexadecimal representation string.
        /// </summary>
        /// <param name="c">This Color structure</param>
        /// <returns>A string containing a hexadecimal value</returns>
        public static string ToHexString(this Color c) => ColorTranslator.ToHtml(c);
        /// <summary>
        /// An extension method for translating a HTML color to Color structure.
        /// </summary>
        /// <param name="HexColor">Value of this string</param>
        /// <returns></returns>
        public static Color FromHTMLToColor(this string HexColor) => ColorTranslator.FromHtml(HexColor);
    }
    #endregion
}
