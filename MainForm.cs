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

namespace SarcusImaging
{
    public partial class SarcusImaging : Form
    {
        public SarcusImaging()
        {
            InitializeComponent();
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
            CameraManager cameraManager = CameraManager.Instance;
            if (cameraManager.showCameraSelectionDialog())
            {
                menuCameraOptions.Enabled = true;
                menuCameraStatus.Enabled = true;
            }
        }

        private void showStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
