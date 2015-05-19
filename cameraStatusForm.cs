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
            double exposeTime = Double.Parse(textBox1.Text);
            bool withLights = checkBox1.Checked;
            System.Diagnostics.Debug.WriteLine("Exposing with time: " + exposeTime + ", with lights: " + withLights);
            CameraManager.Instance.manualExpose(exposeTime, withLights);
            while (!CameraManager.Instance.hasNewImage()) { }
            System.Diagnostics.Debug.WriteLine("Got new image");
            Bitmap img = CameraManager.Instance.getImage();
            SingleImageForm singleImageForm = new SingleImageForm(img);
            singleImageForm.Show();

        }

        private void buttonGetImage_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
