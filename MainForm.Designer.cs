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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SarcusImaging));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCameraOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.sequenceSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCamera,
            this.aboutToolStripMenuItem});
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
            this.sequenceSetupToolStripMenuItem,
            this.imageViewToolStripMenuItem});
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 735);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1172, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel2.Text = "Camera status:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabel3.Text = "Imaging progress:";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.AutoSize = false;
            this.toolStripProgressBar.AutoToolTip = true;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar.ToolTipText = "Imaging progress";
            // 
            // sequenceSetupToolStripMenuItem
            // 
            this.sequenceSetupToolStripMenuItem.Name = "sequenceSetupToolStripMenuItem";
            this.sequenceSetupToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.sequenceSetupToolStripMenuItem.Text = "Sequence setup";
            this.sequenceSetupToolStripMenuItem.Click += new System.EventHandler(this.sequenceSetupToolStripMenuItem_Click_1);
            // 
            // imageViewToolStripMenuItem
            // 
            this.imageViewToolStripMenuItem.Name = "imageViewToolStripMenuItem";
            this.imageViewToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.imageViewToolStripMenuItem.Text = "Image view";
            this.imageViewToolStripMenuItem.Click += new System.EventHandler(this.imageViewToolStripMenuItem_Click);
            // 
            // SarcusImaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 757);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SarcusImaging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sarcus Imaging";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.SarcusImaging_Closed);
            this.Load += new System.EventHandler(this.SarcusImaging_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCamera;
        private System.Windows.Forms.ToolStripMenuItem menuCameraOptions;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewToolStripMenuItem;
    }
}

