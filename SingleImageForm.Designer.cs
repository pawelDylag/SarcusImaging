namespace SarcusImaging
{
    partial class SingleImageForm
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
            this.boxPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPicture
            // 
            this.boxPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxPicture.Location = new System.Drawing.Point(0, 0);
            this.boxPicture.Name = "boxPicture";
            this.boxPicture.Size = new System.Drawing.Size(461, 454);
            this.boxPicture.TabIndex = 0;
            this.boxPicture.TabStop = false;
            // 
            // SingleImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 454);
            this.Controls.Add(this.boxPicture);
            this.Name = "SingleImageForm";
            this.Text = "Single image";
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
    }
}