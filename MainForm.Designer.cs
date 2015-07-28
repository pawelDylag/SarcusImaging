namespace SarcusImaging
{
    partial class SarcusImaging
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCameraOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxStatus = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCamera,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuItemCamera
            // 
            this.menuItemCamera.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCameraOptions,
            this.sequenceSetupToolStripMenuItem});
            this.menuItemCamera.Name = "menuItemCamera";
            this.menuItemCamera.Size = new System.Drawing.Size(60, 20);
            this.menuItemCamera.Text = "Camera";
            this.menuItemCamera.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // menuCameraOptions
            // 
            this.menuCameraOptions.Name = "menuCameraOptions";
            this.menuCameraOptions.Size = new System.Drawing.Size(157, 22);
            this.menuCameraOptions.Text = "Control Panel";
            this.menuCameraOptions.Click += new System.EventHandler(this.menuCameraOptions_Click);
            // 
            // sequenceSetupToolStripMenuItem
            // 
            this.sequenceSetupToolStripMenuItem.Name = "sequenceSetupToolStripMenuItem";
            this.sequenceSetupToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sequenceSetupToolStripMenuItem.Text = "Sequence setup";
            this.sequenceSetupToolStripMenuItem.Click += new System.EventHandler(this.sequenceSetupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBoxStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1172, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel1.Text = "Camera status:";
            // 
            // toolStripTextBoxStatus
            // 
            this.toolStripTextBoxStatus.Name = "toolStripTextBoxStatus";
            this.toolStripTextBoxStatus.ReadOnly = true;
            this.toolStripTextBoxStatus.Size = new System.Drawing.Size(140, 25);
            this.toolStripTextBoxStatus.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBoxStatus.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // SarcusImaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 757);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SarcusImaging";
            this.Text = "Sarcus Imaging";
            this.Closed += new System.EventHandler(this.SarcusImaging_Closed);
            this.Load += new System.EventHandler(this.SarcusImaging_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCamera;
        private System.Windows.Forms.ToolStripMenuItem menuCameraOptions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxStatus;
        private System.Windows.Forms.ToolStripMenuItem sequenceSetupToolStripMenuItem;
    }
}

