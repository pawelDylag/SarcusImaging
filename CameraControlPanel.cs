﻿using System;
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
            TabPage imagePage = tabControlPanel.TabPages[1];
            TabPage exposePage = tabControlPanel.TabPages[2];
            if (locked)
            {
                imagePage.Enabled = false;
                groupBoxLeds.Enabled = false;
                exposePage.Enabled = false;
                groupBoxTemperature.Enabled = false;
                groupBoxMode.Enabled = false;
            }
            else
            {
                imagePage.Enabled = true;
                groupBoxLeds.Enabled = true;
                exposePage.Enabled = true;
                groupBoxTemperature.Enabled = true;
                groupBoxMode.Enabled = true;
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
            // remember last image count
            int lastImageCount = CameraManager.Instance.getImageCount();
            // set camera image count to 
            CameraManager.Instance.setImageCount(1);
            // turn on stop button
            buttonStop.Enabled = true;
            Thread backgroundThread = new Thread(
            new ThreadStart(() =>                       
            {
                CameraManager.Instance.manualExpose(exposeTime, light);
                progressBarExposure.BeginInvoke( new Action(() =>
                {
                    progressBarExposure.Style = ProgressBarStyle.Marquee;
                    progressBarExposure.MarqueeAnimationSpeed = 30;
                }));
                while (!CameraManager.Instance.hasNewImage())
                {
                }
                 progressBarExposure.BeginInvoke(
                        new Action(() =>
                        {
                            progressBarExposure.Style = ProgressBarStyle.Continuous;
                        }
                    ));
                System.Diagnostics.Debug.WriteLine("Got new image");
                ushort[] img = CameraManager.Instance.getSingleImage();
                CameraManager.Instance.setImageCount(lastImageCount);
                showImageForm(img);
                // unlock stop button
                buttonStop.BeginInvoke(
                new Action(() =>
                {
                    buttonStop.Enabled = false;
                }));
            }
            ));
            backgroundThread.Start();

        }

        private void showImageForm(ushort[] image)
        {
            SingleImageForm singleImageForm = new SingleImageForm(image);
            openedWindow.Invoke((MethodInvoker)delegate()
            {
                singleImageForm.Show();
            });
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
                lockTabs(false);
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
            int imageCount = (int) numericUpDownImageCount.Value;
            double exposeTime = (double) numericUpDownTimeSequence.Value;
            System.Diagnostics.Debug.WriteLine("Exposing sequence of " + imageCount + " images, with time: " + exposeTime );
            // set camera image count to last one
            CameraManager.Instance.setImageCount(imageCount);
            // unlock "stop" button
            buttonStopSequence.Enabled = true;
            // start imaging bg thread
            Thread backgroundThread = new Thread(
            new ThreadStart(() =>
            {
                CameraManager.Instance.manualExpose(exposeTime, true);
                progressBarSequence.BeginInvoke(
                new Action(() =>
                {
                    progressBarSequence.Style = ProgressBarStyle.Marquee;
                    progressBarSequence.MarqueeAnimationSpeed = 60;
                }
                 ));
                for (int i = 0; i <= imageCount; i++)
                {
                    while (!CameraManager.Instance.hasNewImage())
                    { }
                    System.Diagnostics.Debug.WriteLine("Got new image with number " + i);
                    ushort[] img = CameraManager.Instance.getSingleImage();
                    showImageForm(img);
                }
                progressBarExposure.BeginInvoke(
                new Action(() =>
                {
                    progressBarSequence.Style = ProgressBarStyle.Continuous;
                }
                ));
                // lock again stop button
                buttonStopSequence.BeginInvoke(
                new Action(() =>
                {
                    buttonStopSequence.Enabled = false;
                }));
            }
            ));
            backgroundThread.Start();

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CameraManager.Instance.stopExposure();
        }
    }
}