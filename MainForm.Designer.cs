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
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCameraLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCameraOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCameraStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuItemCamera});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "New";
            // 
            // menuItemCamera
            // 
            this.menuItemCamera.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCameraLoad,
            this.menuCameraOptions,
            this.menuCameraStatus});
            this.menuItemCamera.Name = "menuItemCamera";
            this.menuItemCamera.Size = new System.Drawing.Size(60, 20);
            this.menuItemCamera.Text = "Camera";
            this.menuItemCamera.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // menuCameraLoad
            // 
            this.menuCameraLoad.Name = "menuCameraLoad";
            this.menuCameraLoad.Size = new System.Drawing.Size(152, 22);
            this.menuCameraLoad.Text = "Load";
            this.menuCameraLoad.Click += new System.EventHandler(this.loadCameraToolStripMenuItem_Click);
            // 
            // menuCameraOptions
            // 
            this.menuCameraOptions.Enabled = false;
            this.menuCameraOptions.Name = "menuCameraOptions";
            this.menuCameraOptions.Size = new System.Drawing.Size(152, 22);
            this.menuCameraOptions.Text = "Options";
            // 
            // menuCameraStatus
            // 
            this.menuCameraStatus.Enabled = false;
            this.menuCameraStatus.Name = "menuCameraStatus";
            this.menuCameraStatus.Size = new System.Drawing.Size(152, 22);
            this.menuCameraStatus.Text = "Status";
            this.menuCameraStatus.Click += new System.EventHandler(this.showStatusToolStripMenuItem_Click);
            // 
            // SarcusImaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 667);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SarcusImaging";
            this.Text = "Sarcus Imaging";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemCamera;
        private System.Windows.Forms.ToolStripMenuItem menuCameraLoad;
        private System.Windows.Forms.ToolStripMenuItem menuCameraOptions;
        private System.Windows.Forms.ToolStripMenuItem menuCameraStatus;
    }
}

