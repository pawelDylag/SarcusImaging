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
            this.buttonExpose = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tabControlPanel = new System.Windows.Forms.TabControl();
            this.tabPageSetup = new System.Windows.Forms.TabPage();
            this.groupBoxLeds = new System.Windows.Forms.GroupBox();
            this.tabPageTemperature = new System.Windows.Forms.TabPage();
            this.tabPageSequence = new System.Windows.Forms.TabPage();
            this.comboBoxStatusLedA = new System.Windows.Forms.ComboBox();
            this.labelLedA = new System.Windows.Forms.Label();
            this.labelLedB = new System.Windows.Forms.Label();
            this.comboBoxStatusLedB = new System.Windows.Forms.ComboBox();
            this.comboBoxLedOptions = new System.Windows.Forms.ComboBox();
            this.groupBoxShutter = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBoxDigitization = new System.Windows.Forms.GroupBox();
            this.checkBoxDigitizeOverscan = new System.Windows.Forms.CheckBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.comboBoxDigitization = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gtoupBoxCameraSetup.SuspendLayout();
            this.tabControlPanel.SuspendLayout();
            this.tabPageSetup.SuspendLayout();
            this.groupBoxLeds.SuspendLayout();
            this.tabPageSequence.SuspendLayout();
            this.groupBoxShutter.SuspendLayout();
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
            // buttonExpose
            // 
            resources.ApplyResources(this.buttonExpose, "buttonExpose");
            this.buttonExpose.Name = "buttonExpose";
            this.buttonExpose.UseVisualStyleBackColor = true;
            this.buttonExpose.Click += new System.EventHandler(this.buttonExpose_Click);
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
            this.tabControlPanel.Controls.Add(this.tabPageTemperature);
            this.tabControlPanel.Controls.Add(this.tabPageSequence);
            resources.ApplyResources(this.tabControlPanel, "tabControlPanel");
            this.tabControlPanel.Name = "tabControlPanel";
            this.tabControlPanel.SelectedIndex = 0;
            // 
            // tabPageSetup
            // 
            this.tabPageSetup.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSetup.Controls.Add(this.groupBoxDigitization);
            this.tabPageSetup.Controls.Add(this.groupBoxShutter);
            this.tabPageSetup.Controls.Add(this.groupBoxLeds);
            this.tabPageSetup.Controls.Add(this.gtoupBoxCameraSetup);
            resources.ApplyResources(this.tabPageSetup, "tabPageSetup");
            this.tabPageSetup.Name = "tabPageSetup";
            this.tabPageSetup.Click += new System.EventHandler(this.tabPage1_Click);
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
            // tabPageTemperature
            // 
            resources.ApplyResources(this.tabPageTemperature, "tabPageTemperature");
            this.tabPageTemperature.Name = "tabPageTemperature";
            this.tabPageTemperature.UseVisualStyleBackColor = true;
            // 
            // tabPageSequence
            // 
            this.tabPageSequence.Controls.Add(this.buttonExpose);
            resources.ApplyResources(this.tabPageSequence, "tabPageSequence");
            this.tabPageSequence.Name = "tabPageSequence";
            this.tabPageSequence.UseVisualStyleBackColor = true;
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
            resources.GetString("comboBoxStatusLedA.Items6"),
            resources.GetString("comboBoxStatusLedA.Items7")});
            resources.ApplyResources(this.comboBoxStatusLedA, "comboBoxStatusLedA");
            this.comboBoxStatusLedA.Name = "comboBoxStatusLedA";
            this.comboBoxStatusLedA.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusLedA_SelectedIndexChanged);
            // 
            // labelLedA
            // 
            resources.ApplyResources(this.labelLedA, "labelLedA");
            this.labelLedA.Name = "labelLedA";
            this.labelLedA.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // labelLedB
            // 
            resources.ApplyResources(this.labelLedB, "labelLedB");
            this.labelLedB.Name = "labelLedB";
            this.labelLedB.Click += new System.EventHandler(this.label4_Click);
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
            resources.GetString("comboBoxStatusLedB.Items6"),
            resources.GetString("comboBoxStatusLedB.Items7")});
            resources.ApplyResources(this.comboBoxStatusLedB, "comboBoxStatusLedB");
            this.comboBoxStatusLedB.Name = "comboBoxStatusLedB";
            this.comboBoxStatusLedB.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusLedB_SelectedIndexChanged);
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
            // groupBoxShutter
            // 
            this.groupBoxShutter.Controls.Add(this.radioButton3);
            this.groupBoxShutter.Controls.Add(this.radioButton4);
            this.groupBoxShutter.Controls.Add(this.radioButton2);
            this.groupBoxShutter.Controls.Add(this.radioButton1);
            this.groupBoxShutter.Controls.Add(this.checkBox1);
            resources.ApplyResources(this.groupBoxShutter, "groupBoxShutter");
            this.groupBoxShutter.Name = "groupBoxShutter";
            this.groupBoxShutter.TabStop = false;
            this.groupBoxShutter.Enter += new System.EventHandler(this.groupBox1_Enter_2);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBoxDigitization
            // 
            this.groupBoxDigitization.Controls.Add(this.label1);
            this.groupBoxDigitization.Controls.Add(this.comboBoxDigitization);
            this.groupBoxDigitization.Controls.Add(this.checkBoxDigitizeOverscan);
            resources.ApplyResources(this.groupBoxDigitization, "groupBoxDigitization");
            this.groupBoxDigitization.Name = "groupBoxDigitization";
            this.groupBoxDigitization.TabStop = false;
            // 
            // checkBoxDigitizeOverscan
            // 
            resources.ApplyResources(this.checkBoxDigitizeOverscan, "checkBoxDigitizeOverscan");
            this.checkBoxDigitizeOverscan.Name = "checkBoxDigitizeOverscan";
            this.checkBoxDigitizeOverscan.UseVisualStyleBackColor = true;
            this.checkBoxDigitizeOverscan.CheckedChanged += new System.EventHandler(this.checkBoxDigitizeOverscan_CheckedChanged);
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged_1);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
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
            this.Load += new System.EventHandler(this.cameraStatusForm_Load);
            this.gtoupBoxCameraSetup.ResumeLayout(false);
            this.gtoupBoxCameraSetup.PerformLayout();
            this.tabControlPanel.ResumeLayout(false);
            this.tabPageSetup.ResumeLayout(false);
            this.groupBoxLeds.ResumeLayout(false);
            this.groupBoxLeds.PerformLayout();
            this.tabPageSequence.ResumeLayout(false);
            this.groupBoxShutter.ResumeLayout(false);
            this.groupBoxShutter.PerformLayout();
            this.groupBoxDigitization.ResumeLayout(false);
            this.groupBoxDigitization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gtoupBoxCameraSetup;
        private System.Windows.Forms.Button buttonExpose;
        private System.Windows.Forms.TabControl tabControlPanel;
        private System.Windows.Forms.TabPage tabPageSetup;
        private System.Windows.Forms.TabPage tabPageTemperature;
        private System.Windows.Forms.TabPage tabPageSequence;
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
        private System.Windows.Forms.GroupBox groupBoxShutter;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBoxDigitization;
        private System.Windows.Forms.CheckBox checkBoxDigitizeOverscan;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBoxDigitization;
        private System.Windows.Forms.Label label1;

    }
}