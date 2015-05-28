using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarcusImaging
{
    public partial class SingleImageForm : Form
    {


        public SingleImageForm()
        {
            CameraManager.Instance.ImageReady += this.OnImageReady;
        }

        public SingleImageForm(ushort[] image)
        {
            InitializeComponent();
            CameraManager.Instance.ImageReady += this.OnImageReady;
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            ushort offset = ImageProcessor.getUshortMinValue(image);
            Bitmap bitmap = ImageProcessor.convertArrayToBitmap(image, width, height, offset);
            boxPicture.Image = bitmap;
            //Form settingsForm = new ImageSettings(this);
            //settingsForm.Show();
        }

        public void showBitmap(Bitmap bitmap)
        {
            boxPicture.Image = bitmap;
        }

        public void OnImageReady(object source, ImageReadyArgs a)
        {
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            ushort offset = ImageProcessor.getUshortMinValue(a.pixels);
            Bitmap bitmap = ImageProcessor.convertArrayToBitmap(a.pixels, width, height, offset);
            boxPicture.Image = bitmap;
        }

        private void boxPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
