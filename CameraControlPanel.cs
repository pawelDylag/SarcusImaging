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
        public static void ShowForm( SarcusImaging parentForm)
        {
             if (openedWindow != null)
            {
                openedWindow.BringToFront();
            }
            else
            {
            openedWindow = new CameraControlPanel();
            openedWindow.MdiParent = parentForm;
            openedWindow.Show();
            }
        }

        /// <summary>
        /// Locks tabs when camera is not selected
        /// </summary>
        /// <param name="locked"></param>
        private void lockTabs(bool locked){
            TabPage imagePage = tabControlPanel.TabPages[1];
            if (locked)
            {
                imagePage.Enabled = false;
                groupBoxLeds.Enabled = false;
                groupBoxTemperature.Enabled = false;
                groupBoxMode.Enabled = false;
            }
            else
            {
                imagePage.Enabled = true;
                groupBoxLeds.Enabled = true;
                groupBoxTemperature.Enabled = true;
                groupBoxMode.Enabled = true;
                comboBoxDigitization.SelectedIndex = 1;
                comboBoxLedOptions.SelectedIndex = 0;
                comboBoxStatusLedA.SelectedIndex = 0;
                comboBoxStatusLedB.SelectedIndex = 0;
                ((SarcusImaging)MdiParent).lockTabs(false);
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

        private void showImageFormWithImage(ushort[] image)
        {
            openedWindow.Invoke((MethodInvoker)delegate()
            {
                ImageForm.ShowForm((SarcusImaging)this.MdiParent);
            });
        }

        private void showImageForm(Boolean show)
        {
            if (show) {
                openedWindow.Invoke((MethodInvoker)delegate ()
                {
                    ImageForm.ShowForm((SarcusImaging)this.MdiParent);
                });
            } else
            {
                openedWindow.Invoke((MethodInvoker)delegate ()
                {
                    ImageForm.hideForm();
                });
            }
        }

        private void showSequenceForm(Boolean show)
        {
            if (show)
            {
                openedWindow.Invoke((MethodInvoker)delegate ()
                {
                    SequenceForm.ShowForm((SarcusImaging)this.MdiParent);
                });
            } else
            {
                openedWindow.Invoke((MethodInvoker)delegate ()
                {
                    SequenceForm.hideForm();
                });
            }
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

        /// <summary>
        /// This method is called when user selects new camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindNewCamera_Click(object sender, EventArgs e)
        {
            CameraManager cameraManager = CameraManager.Instance;
            if (!cameraManager.isCameraConnected())
            {
                bool isSelected = cameraManager.showCameraSelectionDialog();
                if (isSelected)
                {
                    lockTabs(false);
                    showImageForm(true);
                    showSequenceForm(true);
                    changeConnectButtonState(false);
                    updateTextBoxModel();
                    updateTextBoxCameraConnectionStatus();
                    ((SarcusImaging)MdiParent).startCameraStatusUpdates();
                }
            } else
            {
                ((SarcusImaging)MdiParent).stopCameraStatusUpdates();
                showImageForm(false);
                showSequenceForm(false);
                cameraManager.disconnectCamera();
                changeConnectButtonState(true);
                lockTabs(true);
            }
        }
        
        /// <summary>
        /// Changes connect button text depending on camera connection status
        /// </summary>
        /// <param name="boolean"></param>
        private void changeConnectButtonState(Boolean boolean)
        {
            if (boolean)
                buttonFindNewCamera.Text = "Connect";
            else
                buttonFindNewCamera.Text = "Disconnect";
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
                    comboBoxStatusLedA.Enabled = false;
                    comboBoxStatusLedB.Enabled = false;
                    break;
                case 1:
                    setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_DisableWhileExpose);
                    comboBoxStatusLedA.Enabled = true;
                    comboBoxStatusLedB.Enabled = true;
                    break;
                case 2:
                    setLedMode(APOGEELib.Apn_LedMode.Apn_LedMode_EnableAll);
                    comboBoxStatusLedA.Enabled = true;
                    comboBoxStatusLedB.Enabled = true;
                    break;
            }
        }

        private void setLedStatus(int ledId, int status) {
            switch (status)
            {
                case 0:
                    CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_AtTemp);
                break;
                case 1:
                    CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_Expose);
                break;
                case 2:
                    CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_Flushing);
                break;
                case 3:
                    CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_ExtStartReadout);
                break;
                case 4:
                CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_ExtShutterInput);
                break;
                case 5:
                CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_ExtTriggerReceived);
                break;
                case 6:
                CameraManager.Instance.setLedState(ledId, APOGEELib.Apn_LedState.Apn_LedState_ExtTriggerWaiting);
                break;

            }
        }

        private void comboBoxStatusLedA_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLedStatus(CameraManager.LED_A, comboBoxStatusLedA.SelectedIndex);
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxStatusLedB_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLedStatus(CameraManager.LED_B, comboBoxStatusLedB.SelectedIndex);
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
            CameraManager.Instance.setCameraTrigger(true, true);
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
            CameraManager.Instance.setCameraTrigger(true, true);
        }

        private void radioButtonTrigger2_CheckedChanged(object sender, EventArgs e)
        {
            CameraManager.Instance.setCameraTrigger(false, true);
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

        private void progressBarExposure_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxTrigger_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDownImageCount_ValueChanged(object sender, EventArgs e)
        {
            int value = (int) numericUpDownImageCount.Value;
            // if value is out of range / camera is not initiallized
            if (!CameraManager.Instance.setImageCount(value))
            {
                MessageBox.Show("Value must be between 1 - 65535");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void buttonStartSequence_Click(object sender, EventArgs e)
        {

            showImageForm(true);
            // start imaging sequence
            SequencePlan plan = new SequencePlan();
            plan.addItem(new SequenceItem(0, SequenceItem.types.TYPE_SEQUENCE, (double) numericUpDownTimeSequence.Value, (int) numericUpDownImageCount.Value, 0, "debug"));
            plan.iterations = 1;
            CameraManager.Instance.executeSequencePlan(plan);
            // lock again stop button
            buttonStopSequence.BeginInvoke(
            new Action(() =>
            {
                buttonStopSequence.Enabled = false;
            }));

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CameraManager.Instance.stopExposure();
        }

        private void progressBarSequence_Click(object sender, EventArgs e)
        {

        }
    }
}
