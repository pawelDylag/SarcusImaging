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
    public partial class CameraStatusForm : Form
    {
        public CameraStatusForm()
        {
            InitializeComponent();
        }

        private void cameraStatusForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonExpose_Click(object sender, EventArgs e)
        {
            CameraManager.Instance.manualExpose(0.001, false);
            while (!CameraManager.Instance.hasNewImage()) { }
            Bitmap image = CameraManager.Instance.getImage();
            SingleImageForm singleImageForm = new SingleImageForm(image);
            singleImageForm.Show();

        }

        private void buttonGetImage_Click(object sender, EventArgs e)
        {

        }

    }
}
