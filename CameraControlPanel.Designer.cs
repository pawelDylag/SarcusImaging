namespace SarcusImaging
{
    partial class CameraControlPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraControlPanel));
            this.gtoupBoxCameraSetup = new System.Windows.Forms.GroupBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFindNewCamera = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tabControlPanel = new System.Windows.Forms.TabControl();
            this.tabPageSetup = new System.Windows.Forms.TabPage();
            this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
            this.buttonTemperature = new System.Windows.Forms.Button();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxLeds = new System.Windows.Forms.GroupBox();
            this.comboBoxLedOptions = new System.Windows.Forms.ComboBox();
            this.labelLedB = new System.Windows.Forms.Label();
            this.comboBoxStatusLedA = new System.Windows.Forms.ComboBox();
            this.comboBoxStatusLedB = new System.Windows.Forms.ComboBox();
            this.labelLedA = new System.Windows.Forms.Label();
            this.tabPageSequence = new System.Windows.Forms.TabPage();
            this.groupBoxTrigger = new System.Windows.Forms.GroupBox();
            this.radioButtonTrigger2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTrgger1 = new System.Windows.Forms.RadioButton();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownTimeSequence = new System.Windows.Forms.NumericUpDown();
            this.progressBarSequence = new System.Windows.Forms.ProgressBar();
            this.buttonStartSequence = new System.Windows.Forms.Button();
            this.buttonStopSequence = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownImageCount = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDigitization = new System.Windows.Forms.GroupBox();
            this.comboBoxDigitization = new System.Windows.Forms.ComboBox();
            this.checkBoxDigitizeOverscan = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gtoupBoxCameraSetup.SuspendLayout();
            this.tabControlPanel.SuspendLayout();
            this.tabPageSetup.SuspendLayout();
            this.groupBoxTemperature.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxLeds.SuspendLayout();
            this.tabPageSequence.SuspendLayout();
            this.groupBoxTrigger.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageCount)).BeginInit();
            this.groupBoxDigitization.SuspendLayout();
            this.SuspendLayout();
            // 
            // gtoupBoxCameraSetup
            // 
            this.gtoupBoxCameraSetup.Controls.Add(this.textBoxModel);
            this.gtoupBoxCameraSetup.Controls.Add(this.textBoxStatus);
            this.gtoupBoxCameraSetup.Controls.Add(this.label3);
            this.gtoupBoxCameraSetup.Controls.Add(this.buttonFindNewCamera);
            this.gtoupBoxCameraSetup.Controls.Add(this.label2);
            resources.ApplyResources(this.gtoupBoxCameraSetup, "gtoupBoxCameraSetup");
            this.gtoupBoxCameraSetup.Name = "gtoupBoxCameraSetup";
            this.gtoupBoxCameraSetup.TabStop = false;
            this.gtoupBoxCameraSetup.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxModel
            // 
            resources.ApplyResources(this.textBoxModel, "textBoxModel");
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.ReadOnly = true;
            this.textBoxModel.TextChanged += new System.EventHandler(this.textBoxModel_TextChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.textBoxStatus, "textBoxStatus");
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonFindNewCamera
            // 
            resources.ApplyResources(this.buttonFindNewCamera, "buttonFindNewCamera");
            this.buttonFindNewCamera.Name = "buttonFindNewCamera";
            this.buttonFindNewCamera.UseVisualStyleBackColor = true;
            this.buttonFindNewCamera.Click += new System.EventHandler(this.buttonFindNewCamera_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BottomToolStripPanel
            // 
            resources.ApplyResources(this.BottomToolStripPanel, "BottomToolStripPanel");
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // TopToolStripPanel
            // 
            resources.ApplyResources(this.TopToolStripPanel, "TopToolStripPanel");
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // RightToolStripPanel
            // 
            resources.ApplyResources(this.RightToolStripPanel, "RightToolStripPanel");
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // LeftToolStripPanel
            // 
            resources.ApplyResources(this.LeftToolStripPanel, "LeftToolStripPanel");
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // tabControlPanel
            // 
            this.tabControlPanel.Controls.Add(this.tabPageSetup);
            this.tabControlPanel.Controls.Add(this.tabPageSequence);
            resources.ApplyResources(this.tabControlPanel, "tabControlPanel");
            this.tabControlPanel.Name = "tabControlPanel";
            this.tabControlPanel.SelectedIndex = 0;
            // 
            // tabPageSetup
            // 
            this.tabPageSetup.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSetup.Controls.Add(this.groupBoxTemperature);
            this.tabPageSetup.Controls.Add(this.groupBoxMode);
            this.tabPageSetup.Controls.Add(this.groupBoxLeds);
            this.tabPageSetup.Controls.Add(this.gtoupBoxCameraSetup);
            resources.ApplyResources(this.tabPageSetup, "tabPageSetup");
            this.tabPageSetup.Name = "tabPageSetup";
            this.tabPageSetup.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBoxTemperature
            // 
            this.groupBoxTemperature.Controls.Add(this.buttonTemperature);
            resources.ApplyResources(this.groupBoxTemperature, "groupBoxTemperature");
            this.groupBoxTemperature.Name = "groupBoxTemperature";
            this.groupBoxTemperature.TabStop = false;
            // 
            // buttonTemperature
            // 
            resources.ApplyResources(this.buttonTemperature, "buttonTemperature");
            this.buttonTemperature.Name = "buttonTemperature";
            this.buttonTemperature.UseVisualStyleBackColor = true;
            this.buttonTemperature.Click += new System.EventHandler(this.buttonTemperature_Click);
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButton3);
            this.groupBoxMode.Controls.Add(this.radioButton4);
            this.groupBoxMode.Controls.Add(this.radioButton2);
            this.groupBoxMode.Controls.Add(this.radioButton1);
            this.groupBoxMode.Controls.Add(this.checkBox1);
            resources.ApplyResources(this.groupBoxMode, "groupBoxMode");
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Enter += new System.EventHandler(this.groupBox1_Enter_2);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged_1);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBoxLeds
            // 
            this.groupBoxLeds.Controls.Add(this.comboBoxLedOptions);
            this.groupBoxLeds.Controls.Add(this.labelLedB);
            this.groupBoxLeds.Controls.Add(this.comboBoxStatusLedA);
            this.groupBoxLeds.Controls.Add(this.comboBoxStatusLedB);
            this.groupBoxLeds.Controls.Add(this.labelLedA);
            resources.ApplyResources(this.groupBoxLeds, "groupBoxLeds");
            this.groupBoxLeds.Name = "groupBoxLeds";
            this.groupBoxLeds.TabStop = false;
            this.groupBoxLeds.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // comboBoxLedOptions
            // 
            this.comboBoxLedOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLedOptions.FormattingEnabled = true;
            this.comboBoxLedOptions.Items.AddRange(new object[] {
            resources.GetString("comboBoxLedOptions.Items"),
            resources.GetString("comboBoxLedOptions.Items1"),
            resources.GetString("comboBoxLedOptions.Items2")});
            resources.ApplyResources(this.comboBoxLedOptions, "comboBoxLedOptions");
            this.comboBoxLedOptions.Name = "comboBoxLedOptions";
            this.comboBoxLedOptions.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelLedB
            // 
            resources.ApplyResources(this.labelLedB, "labelLedB");
            this.labelLedB.Name = "labelLedB";
            this.labelLedB.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBoxStatusLedA
            // 
            this.comboBoxStatusLedA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusLedA.FormattingEnabled = true;
            this.comboBoxStatusLedA.Items.AddRange(new object[] {
            resources.GetString("comboBoxStatusLedA.Items"),
            resources.GetString("comboBoxStatusLedA.Items1"),
            resources.GetString("comboBoxStatusLedA.Items2"),
            resources.GetString("comboBoxStatusLedA.Items3"),
            resources.GetString("comboBoxStatusLedA.Items4"),
            resources.GetString("comboBoxStatusLedA.Items5"),
            resources.GetString("comboBoxStatusLedA.Items6")});
            resources.ApplyResources(this.comboBoxStatusLedA, "comboBoxStatusLedA");
            this.comboBoxStatusLedA.Name = "comboBoxStatusLedA";
            this.comboBoxStatusLedA.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusLedA_SelectedIndexChanged);
            // 
            // comboBoxStatusLedB
            // 
            this.comboBoxStatusLedB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusLedB.FormattingEnabled = true;
            this.comboBoxStatusLedB.Items.AddRange(new object[] {
            resources.GetString("comboBoxStatusLedB.Items"),
            resources.GetString("comboBoxStatusLedB.Items1"),
            resources.GetString("comboBoxStatusLedB.Items2"),
            resources.GetString("comboBoxStatusLedB.Items3"),
            resources.GetString("comboBoxStatusLedB.Items4"),
            resources.GetString("comboBoxStatusLedB.Items5"),
            resources.GetString("comboBoxStatusLedB.Items6")});
            resources.ApplyResources(this.comboBoxStatusLedB, "comboBoxStatusLedB");
            this.comboBoxStatusLedB.Name = "comboBoxStatusLedB";
            this.comboBoxStatusLedB.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusLedB_SelectedIndexChanged);
            // 
            // labelLedA
            // 
            resources.ApplyResources(this.labelLedA, "labelLedA");
            this.labelLedA.Name = "labelLedA";
            this.labelLedA.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // tabPageSequence
            // 
            this.tabPageSequence.Controls.Add(this.groupBoxTrigger);
            this.tabPageSequence.Controls.Add(this.groupBoxImage);
            this.tabPageSequence.Controls.Add(this.groupBoxDigitization);
            resources.ApplyResources(this.tabPageSequence, "tabPageSequence");
            this.tabPageSequence.Name = "tabPageSequence";
            // 
            // groupBoxTrigger
            // 
            this.groupBoxTrigger.Controls.Add(this.radioButtonTrigger2);
            this.groupBoxTrigger.Controls.Add(this.radioButtonTrgger1);
            resources.ApplyResources(this.groupBoxTrigger, "groupBoxTrigger");
            this.groupBoxTrigger.Name = "groupBoxTrigger";
            this.groupBoxTrigger.TabStop = false;
            this.groupBoxTrigger.Enter += new System.EventHandler(this.groupBoxTrigger_Enter);
            // 
            // radioButtonTrigger2
            // 
            resources.ApplyResources(this.radioButtonTrigger2, "radioButtonTrigger2");
            this.radioButtonTrigger2.Checked = true;
            this.radioButtonTrigger2.Name = "radioButtonTrigger2";
            this.radioButtonTrigger2.TabStop = true;
            this.radioButtonTrigger2.UseVisualStyleBackColor = true;
            this.radioButtonTrigger2.CheckedChanged += new System.EventHandler(this.radioButtonTrigger2_CheckedChanged);
            // 
            // radioButtonTrgger1
            // 
            resources.ApplyResources(this.radioButtonTrgger1, "radioButtonTrgger1");
            this.radioButtonTrgger1.Name = "radioButtonTrgger1";
            this.radioButtonTrgger1.TabStop = true;
            this.radioButtonTrgger1.UseVisualStyleBackColor = true;
            this.radioButtonTrgger1.CheckedChanged += new System.EventHandler(this.radioButtonTrgger1_CheckedChanged);
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.label8);
            this.groupBoxImage.Controls.Add(this.numericUpDownTimeSequence);
            this.groupBoxImage.Controls.Add(this.progressBarSequence);
            this.groupBoxImage.Controls.Add(this.buttonStartSequence);
            this.groupBoxImage.Controls.Add(this.buttonStopSequence);
            this.groupBoxImage.Controls.Add(this.textBox1);
            this.groupBoxImage.Controls.Add(this.label7);
            this.groupBoxImage.Controls.Add(this.label5);
            this.groupBoxImage.Controls.Add(this.numericUpDownImageCount);
            resources.ApplyResources(this.groupBoxImage, "groupBoxImage");
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numericUpDownTimeSequence
            // 
            this.numericUpDownTimeSequence.DecimalPlaces = 3;
            this.numericUpDownTimeSequence.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            resources.ApplyResources(this.numericUpDownTimeSequence, "numericUpDownTimeSequence");
            this.numericUpDownTimeSequence.Name = "numericUpDownTimeSequence";
            this.numericUpDownTimeSequence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // progressBarSequence
            // 
            resources.ApplyResources(this.progressBarSequence, "progressBarSequence");
            this.progressBarSequence.Name = "progressBarSequence";
            // 
            // buttonStartSequence
            // 
            resources.ApplyResources(this.buttonStartSequence, "buttonStartSequence");
            this.buttonStartSequence.Name = "buttonStartSequence";
            this.buttonStartSequence.UseVisualStyleBackColor = true;
            this.buttonStartSequence.Click += new System.EventHandler(this.buttonStartSequence_Click);
            // 
            // buttonStopSequence
            // 
            resources.ApplyResources(this.buttonStopSequence, "buttonStopSequence");
            this.buttonStopSequence.Name = "buttonStopSequence";
            this.buttonStopSequence.UseVisualStyleBackColor = true;
            this.buttonStopSequence.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numericUpDownImageCount
            // 
            resources.ApplyResources(this.numericUpDownImageCount, "numericUpDownImageCount");
            this.numericUpDownImageCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownImageCount.Name = "numericUpDownImageCount";
            this.numericUpDownImageCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownImageCount.ValueChanged += new System.EventHandler(this.numericUpDownImageCount_ValueChanged);
            // 
            // groupBoxDigitization
            // 
            this.groupBoxDigitization.Controls.Add(this.comboBoxDigitization);
            this.groupBoxDigitization.Controls.Add(this.checkBoxDigitizeOverscan);
            this.groupBoxDigitization.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBoxDigitization, "groupBoxDigitization");
            this.groupBoxDigitization.Name = "groupBoxDigitization";
            this.groupBoxDigitization.TabStop = false;
            // 
            // comboBoxDigitization
            // 
            this.comboBoxDigitization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDigitization.FormattingEnabled = true;
            this.comboBoxDigitization.Items.AddRange(new object[] {
            resources.GetString("comboBoxDigitization.Items"),
            resources.GetString("comboBoxDigitization.Items1")});
            resources.ApplyResources(this.comboBoxDigitization, "comboBoxDigitization");
            this.comboBoxDigitization.Name = "comboBoxDigitization";
            this.comboBoxDigitization.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // checkBoxDigitizeOverscan
            // 
            resources.ApplyResources(this.checkBoxDigitizeOverscan, "checkBoxDigitizeOverscan");
            this.checkBoxDigitizeOverscan.Name = "checkBoxDigitizeOverscan";
            this.checkBoxDigitizeOverscan.UseVisualStyleBackColor = true;
            this.checkBoxDigitizeOverscan.CheckedChanged += new System.EventHandler(this.checkBoxDigitizeOverscan_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CameraControlPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPanel);
            this.Name = "CameraControlPanel";
            this.Closed += new System.EventHandler(this.CameraControlPanel_FormClosed);
            this.gtoupBoxCameraSetup.ResumeLayout(false);
            this.gtoupBoxCameraSetup.PerformLayout();
            this.tabControlPanel.ResumeLayout(false);
            this.tabPageSetup.ResumeLayout(false);
            this.groupBoxTemperature.ResumeLayout(false);
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxLeds.ResumeLayout(false);
            this.groupBoxLeds.PerformLayout();
            this.tabPageSequence.ResumeLayout(false);
            this.groupBoxTrigger.ResumeLayout(false);
            this.groupBoxTrigger.PerformLayout();
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageCount)).EndInit();
            this.groupBoxDigitization.ResumeLayout(false);
            this.groupBoxDigitization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gtoupBoxCameraSetup;
        private System.Windows.Forms.TabControl tabControlPanel;
        private System.Windows.Forms.TabPage tabPageSetup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFindNewCamera;
        private System.Windows.Forms.GroupBox groupBoxLeds;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label labelLedB;
        private System.Windows.Forms.ComboBox comboBoxStatusLedB;
        private System.Windows.Forms.Label labelLedA;
        private System.Windows.Forms.ComboBox comboBoxStatusLedA;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ComboBox comboBoxLedOptions;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBoxTemperature;
        private System.Windows.Forms.Button buttonTemperature;
        private System.Windows.Forms.TabPage tabPageSequence;
        private System.Windows.Forms.GroupBox groupBoxTrigger;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.GroupBox groupBoxDigitization;
        private System.Windows.Forms.CheckBox checkBoxDigitizeOverscan;
        private System.Windows.Forms.ComboBox comboBoxDigitization;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownImageCount;
        private System.Windows.Forms.RadioButton radioButtonTrgger1;
        private System.Windows.Forms.RadioButton radioButtonTrigger2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonStartSequence;
        private System.Windows.Forms.Button buttonStopSequence;
        private System.Windows.Forms.ProgressBar progressBarSequence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeSequence;

    }
}