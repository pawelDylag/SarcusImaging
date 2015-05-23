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
    public partial class CameraControlPanel : Form
    {

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
        /// Locks tabs when camera is not selected
        /// </summary>
        /// <param name="locked"></param>
        private void lockTabs(bool locked){
            TabPage temperaturePage = tabControlPanel.TabPages[1];
            TabPage sequencePage = tabControlPanel.TabPages[2];
            if (locked)
            {
                temperaturePage.Enabled = false;
                sequencePage.Enabled = false;
                groupBoxLeds.Enabled = false;
                groupBoxShutter.Enabled = false;
                groupBoxDigitization.Enabled = false;
            }
            else
            {
                temperaturePage.Enabled = true;
                sequencePage.Enabled = true;
                groupBoxLeds.Enabled = true;
                groupBoxShutter.Enabled = true;
                groupBoxDigitization.Enabled = true;
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
            //double exposeTime = Double.Parse(textBox1.Text);
            //bool withLights = checkBox1.Checked;
            //System.Diagnostics.Debug.WriteLine("Exposing with time: " + exposeTime + ", with lights: " + withLights);
            //CameraManager.Instance.manualExpose(exposeTime, withLights);
            //while (!CameraManager.Instance.hasNewImage()) { }
            //System.Diagnostics.Debug.WriteLine("Got new image");
            //ushort[] img = CameraManager.Instance.getSingleImage();
            //SingleImageForm singleImageForm = new SingleImageForm(img);
            //singleImageForm.Show();
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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CameraManager.Instance.setCameraMode(APOGEELib.Apn_CameraMode.Apn_CameraMode_Normal);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CameraManager.Instance.setCameraMode(APOGEELib.Apn_CameraMode.Apn_CameraMode_ExternalTrigger);
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

    }
}
