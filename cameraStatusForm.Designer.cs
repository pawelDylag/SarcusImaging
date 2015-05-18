namespace SarcusImaging
{
    partial class CameraStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraStatusForm));
            this.groupBoxCameraStatus = new System.Windows.Forms.GroupBox();
            this.buttonGetImage = new System.Windows.Forms.Button();
            this.buttonExpose = new System.Windows.Forms.Button();
            this.groupBoxCameraStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCameraStatus
            // 
            this.groupBoxCameraStatus.Controls.Add(this.buttonGetImage);
            this.groupBoxCameraStatus.Controls.Add(this.buttonExpose);
            resources.ApplyResources(this.groupBoxCameraStatus, "groupBoxCameraStatus");
            this.groupBoxCameraStatus.Name = "groupBoxCameraStatus";
            this.groupBoxCameraStatus.TabStop = false;
            this.groupBoxCameraStatus.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonGetImage
            // 
            resources.ApplyResources(this.buttonGetImage, "buttonGetImage");
            this.buttonGetImage.Name = "buttonGetImage";
            this.buttonGetImage.UseVisualStyleBackColor = true;
            this.buttonGetImage.Click += new System.EventHandler(this.buttonGetImage_Click);
            // 
            // buttonExpose
            // 
            resources.ApplyResources(this.buttonExpose, "buttonExpose");
            this.buttonExpose.Name = "buttonExpose";
            this.buttonExpose.UseVisualStyleBackColor = true;
            this.buttonExpose.Click += new System.EventHandler(this.buttonExpose_Click);
            // 
            // CameraStatusForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCameraStatus);
            this.Name = "CameraStatusForm";
            this.Load += new System.EventHandler(this.cameraStatusForm_Load);
            this.groupBoxCameraStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCameraStatus;
        private System.Windows.Forms.Button buttonExpose;
        private System.Windows.Forms.Button buttonGetImage;

    }
}