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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.boxPicture = new System.Windows.Forms.PictureBox();
            this.chartY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPicture
            // 
            this.boxPicture.Location = new System.Drawing.Point(247, 34);
            this.boxPicture.Name = "boxPicture";
            this.boxPicture.Size = new System.Drawing.Size(512, 512);
            this.boxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.boxPicture.TabIndex = 0;
            this.boxPicture.TabStop = false;
            this.boxPicture.Click += new System.EventHandler(this.boxPicture_Click);
            // 
            // chartY
            // 
            this.chartY.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Angle = 45;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartY.ChartAreas.Add(chartArea1);
            this.chartY.Enabled = false;
            this.chartY.Location = new System.Drawing.Point(765, -16);
            this.chartY.Name = "chartY";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "AverageY";
            series1.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartY.Series.Add(series1);
            this.chartY.Size = new System.Drawing.Size(150, 631);
            this.chartY.TabIndex = 2;
            this.chartY.Text = "chartYAxis";
            // 
            // chartX
            // 
            this.chartX.BackColor = System.Drawing.Color.Transparent;
            this.chartX.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MinorGrid.Interval = double.NaN;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartX.ChartAreas.Add(chartArea2);
            this.chartX.Location = new System.Drawing.Point(183, 547);
            this.chartX.Name = "chartX";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "AverageX";
            this.chartX.Series.Add(series2);
            this.chartX.Size = new System.Drawing.Size(605, 150);
            this.chartX.TabIndex = 3;
            this.chartX.Text = "chartXAxis";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(212, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(175, 512);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(167, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(961, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(775, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 100);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(961, 312);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(961, 594);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(256, 256);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // SingleImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 862);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chartX);
            this.Controls.Add(this.chartY);
            this.Controls.Add(this.boxPicture);
            this.Name = "SingleImageForm";
            this.Text = "Single image";
            this.Closed += new System.EventHandler(this.SingleImageForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}