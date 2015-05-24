using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SarcusImaging
{
    public partial class CameraControlPanel : Form
    {

        public static CameraControlPanel openedWindow = null;

        public CameraControlPanel()
        {
            InitializeComponent();
            // lock control tabs while camera is not selected
            if (!CameraManager.Instance.isCameraConnected())
            {
                lockTabs(true);
            }
            setDefaultConfiguration();
        }

        /// <summary>
        /// This method ensures that only one dialog is opened at given time
        /// </summary>
        public void ShowForm()
        {
             if (openedWindow != null)
            {
                openedWindow.BringToFront();
            }
            else
            {
            openedWindow = new CameraControlPanel();
            openedWindow.Show();
            }
        }

        /// <summary>
        /// Locks tabs when camera is not selected
        /// </summary>
        /// <param name="locked"></param>
        private void lockTabs(bool locked){
            TabPage shutterPage = tabControlPanel.TabPages[1];
            TabPage imagePage = tabControlPanel.TabPages[2];
            TabPage exposePage = tabControlPanel.TabPages[3];
            if (locked)
            {
                shutterPage.Enabled = false;
                imagePage.Enabled = false;
                groupBoxLeds.Enabled = false;
                exposePage.Enabled = false;
                groupBoxTemperature.Enabled = false;
            }
            else
            {
                shutterPage.Enabled = true;
                imagePage.Enabled = true;
                groupBoxLeds.Enabled = true;
                exposePage.Enabled = true;
                groupBoxTemperature.Enabled = true;
              
            }
        }

        /// <summary>
        /// If camera was selected, it sets all controls and camera settings to default values.
        /// </summary>
        public void setDefaultConfiguration()
        {
            updateTextBoxModel();
            updateTextBoxCameraConnectionStatus();
        }

        private void setLedMode(APOGEELib.Apn_LedMode mode)
        {
            if (mode == APOGEELib.Apn_LedMode.Apn_LedMode_DisableAll)
            {
                CameraManager.Instance.setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_DisableAll);
                comboBoxStatusLedA.Enabled = false;
                comboBoxStatusLedB.Enabled = false;
                labelLedA.Enabled = false;
                labelLedB.Enabled = false;
            }
            else
            {
                CameraManager.Instance.setLedMode(mode);
                comboBoxStatusLedA.Enabled = true;
                comboBoxStatusLedB.Enabled = true;
                labelLedA.Enabled = true;
                labelLedB.Enabled = true;
            }
        }

        /// <summary>
        /// updates texBox with model data
        /// </summary>
        private void updateTextBoxModel()
        {
            String model = CameraManager.Instance.getCameraModelInfo();
            textBoxModel.Text = model;
        }

        /// <summary>
        /// Updates textBox with connection status
        /// </summary>
        private void updateTextBoxCameraConnectionStatus()
        {
            String status = CameraManager.Instance.getCameraConnectionStatus();
            textBoxStatus.Text = status;
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
            bool light = false;
            if (radioButtonLight.Checked)
            {
                light = true;
            }
            double exposeTime = (double)numericUpDownTime.Value;
            System.Diagnostics.Debug.WriteLine("Exposing with time: " + exposeTime + ", with lights: " + light);
            Thread backgroundThread = new Thread(
            new ThreadStart(() =>
            {
                CameraManager.Instance.manualExpose(exposeTime, light);
                while (!CameraManager.Instance.hasNewImage())
                {
                    progressBarExposure.BeginInvoke(
                        new Action(() =>
                        {
                            progressBarExposure.Style = ProgressBarStyle.Marquee;
                            progressBarExposure.MarqueeAnimationSpeed = 30;
                        }
                    ));
                }
                 progressBarExposure.BeginInvoke(
                        new Action(() =>
                        {
                            progressBarExposure.Style = ProgressBarStyle.Continuous;
                        }
                    ));
                System.Diagnostics.Debug.WriteLine("Got new image");
                ushort[] img = CameraManager.Instance.getSingleImage();
                SingleImageForm singleImageForm = new SingleImageForm(img);
                singleImageForm.Show();
            }
            ));
            backgroundThread.Start();

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBoxModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFindNewCamera_Click(object sender, EventArgs e)
        {
            CameraManager cameraManager = CameraManager.Instance;
            bool isSelected = cameraManager.showCameraSelectionDialog();
            if (isSelected)
            {
                // WHEN CAMERA SELECTED
            }
            updateTextBoxModel();
            updateTextBoxCameraConnectionStatus();

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxLedOptions.SelectedIndex)
            {
                case 0:
                    setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_DisableAll);
                    break;
                case 1:
                    setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_DisableWhileExpose);
                    break;
                case 2:
                    setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_EnableAll);
                    break;
            }
        }

        private void comboBoxStatusLedA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxStatusLedB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_2(object sender, EventArgs e)
        {

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CameraManager cm = CameraManager.Instance;
            cm.setCameraMode(APOGEELib.Apn_CameraMode.Apn_CameraMode_Normal);
            cm.setCameraTrigger(false, false);
            groupBoxTrigger.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CameraManager.Instance.setCameraTrigger(true, false);
            groupBoxTrigger.Enabled = true;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxDigitization.SelectedIndex)
            {
                case 0:
                    CameraManager.Instance.setDigitizationSpeed(CameraManager.DIGITIZATION_FAST);
                    break;
                case 1:
                    CameraManager.Instance.setDigitizationSpeed(CameraManager.DIGITIZATION_NORMAL);
                    break;
              
            }
        }

        private void checkBoxDigitizeOverscan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonTrgger1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonTemperature_Click(object sender, EventArgs e)
        {
            CameraManager.Instance.getCamera().ShowTempDialog();
        }

        private void CameraControlPanel_FormClosed(object sender, EventArgs e)
        {
            openedWindow = null;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
