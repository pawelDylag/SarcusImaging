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

        public ushort[] image;

        public SingleImageForm(ushort[] img)
        {
            InitializeComponent();
            this.image = img;
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            ushort offset = ImageConverter.getUshortMinValue(image);
            Bitmap bitmap = ImageConverter.convertArrayToBitmap(image, width, height, offset);
            boxPicture.Image = bitmap;
            Form settingsForm = new ImageSettings(this);
            settingsForm.Show();
        }

        public void showBitmap(Bitmap bitmap)
        {

            boxPicture.Image = bitmap;
        }

        private void boxPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
