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

        // debug switch
        public static readonly bool DEBUG_MODE = false;

        Thread updateCameraStatus = null;

        public SarcusImaging()
        {
            InitializeComponent();
            startCameraStatusUpdates();
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
            CameraControlPanel.ShowForm(this);
            if (DEBUG_MODE)
            {
                ImageForm.ShowForm((SarcusImaging)this);
                SequenceForm.ShowForm((SarcusImaging)this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void startCameraStatusUpdates() {
            this.updateCameraStatus = new Thread(
            new ThreadStart(() =>
            {
                while (true)
                {
                    String status = CameraManager.Instance.getCameraImagingStatusString();
                    updateCameraStatusTextBox(status);
                    Thread.Sleep(1000);
                }
            }
            ));
            updateCameraStatus.Start();
        }

        private void stopCameraStatusUpdates()
        {
            if (this.updateCameraStatus != null)
            {
                updateCameraStatus.Abort();
            }
        }

        protected void updateCameraStatusTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(updateCameraStatusTextBox), new object[] { value });
                return;
            }
            toolStripStatusLabel1.Text = value;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void SarcusImaging_Load(object sender, EventArgs e)
        {

        }
        private void SarcusImaging_Closed(object sender, EventArgs e)
        {
            stopCameraStatusUpdates();
        }

        private void sequenceSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SequenceForm.ShowForm(this);
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
