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
            this.buttonExpose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCameraStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCameraStatus
            // 
            this.groupBoxCameraStatus.Controls.Add(this.label1);
            this.groupBoxCameraStatus.Controls.Add(this.checkBox1);
            this.groupBoxCameraStatus.Controls.Add(this.textBox1);
            this.groupBoxCameraStatus.Controls.Add(this.buttonExpose);
            resources.ApplyResources(this.groupBoxCameraStatus, "groupBoxCameraStatus");
            this.groupBoxCameraStatus.Name = "groupBoxCameraStatus";
            this.groupBoxCameraStatus.TabStop = false;
            this.groupBoxCameraStatus.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonExpose
            // 
            resources.ApplyResources(this.buttonExpose, "buttonExpose");
            this.buttonExpose.Name = "buttonExpose";
            this.buttonExpose.UseVisualStyleBackColor = true;
            this.buttonExpose.Click += new System.EventHandler(this.buttonExpose_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // CameraStatusForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCameraStatus);
            this.Name = "CameraStatusForm";
            this.Load += new System.EventHandler(this.cameraStatusForm_Load);
            this.groupBoxCameraStatus.ResumeLayout(false);
            this.groupBoxCameraStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCameraStatus;
        private System.Windows.Forms.Button buttonExpose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;

    }
}