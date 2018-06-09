using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGGW.MR.Cienowanie;
namespace SGGW.MR.Application
{
    public partial class Cieniowanie : Form
    {

        private ShadingController ShadingController;
        private HilbertController HilbertController;

        public Cieniowanie()
        {
            InitializeComponent();
            ShadingController = new ShadingController();
            HilbertController = new HilbertController(); 

        }

        #region Cieniowanie_DragDrop
        private void Cieniowanie_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Cieniowanie_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;

            int y = this.PointToClient(new Point(e.X, e.Y)).Y;

            if (x >= ShadingDragAndDropImageBox.Location.X && x <= ShadingDragAndDropImageBox.Location.X + ShadingDragAndDropImageBox.Width && y >= ShadingDragAndDropImageBox.Location.Y && y <= ShadingDragAndDropImageBox.Location.Y + ShadingDragAndDropImageBox.Height)

            {

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Bitmap img = new Bitmap(Image.FromFile(files[0]));
                

                //Check image dimensions
                if (img.Height != img.Width)
                {
                  DialogResult dialog =  MessageBox.Show("Dimentions of the picture do not form a square. Do you want to scale the picture?","Wrong dimentions of the photo.",MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        ShadingDragAndDropImageBox.Image = img;

                    }
                    else 
               
                    {
                        ShadingDragAndDropImageBox.Image = img;
                    }
                }
                else ShadingDragAndDropImageBox.Image = img;

                //Set controller's raw image
                ShadingController.RawImage = img;

            }
        }


        #endregion
        #region ShadingStartButtonClick
        private void ShadingStartButton_Click(object sender, EventArgs e)
        {

        }

        #endregion ShadingStartButtonClick

    }
}
