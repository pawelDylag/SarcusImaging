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
    public partial class ImageSettings : Form
    {
        private SingleImageForm imageForm;


        public ImageSettings(SingleImageForm imageForm)
        {
            this.imageForm = imageForm;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBarOffset_Scroll(object sender, EventArgs e)
        {
            ushort offsetValue = (ushort) trackBarOffset.Value;
            ushort[] image = imageForm.image;
            image = CameraManager.Instance.getSingleImage();
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            Bitmap bitmap = ImageProcessor.convertArrayToBitmap(image, width, height, offsetValue);
            imageForm.showBitmap(bitmap);
        }
    }
}
