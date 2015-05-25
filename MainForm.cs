using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APOGEELib;
using System.Threading;

namespace SarcusImaging
{
    public partial class SarcusImaging : Form
    {

        public SarcusImaging()
        {
            InitializeComponent();
            runCameraStatusUpdates();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void loadCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void showStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuCameraOptions_Click(object sender, EventArgs e)
        {
            CameraControlPanel cameraStatusForm = new CameraControlPanel();
            cameraStatusForm.MdiParent = this;
            cameraStatusForm.ShowForm();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void runCameraStatusUpdates()
        {
            CameraManager cm = CameraManager.Instance;
            while (true)
            {
                toolStripTextBoxStatus.Text = cm.getCameraImagingStatusString();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
