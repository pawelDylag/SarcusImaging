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
            this.boxPicture2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boxPicture3 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.boxPicture4 = new System.Windows.Forms.PictureBox();
            this.buttonLoadBackground = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture4)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPicture
            // 
            this.boxPicture.Location = new System.Drawing.Point(63, 12);
            this.boxPicture.Name = "boxPicture";
            this.boxPicture.Size = new System.Drawing.Size(512, 512);
            this.boxPicture.TabIndex = 0;
            this.boxPicture.TabStop = false;
            this.boxPicture.Click += new System.EventHandler(this.boxPicture_Click);
            // 
            // chartY
            // 
            this.chartY.BackColor = System.Drawing.Color.Transparent;
            this.chartY.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX2.LabelStyle.Angle = -45;
            chartArea1.AxisX2.LabelStyle.Enabled = false;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Angle = 45;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartY.ChartAreas.Add(chartArea1);
            this.chartY.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartY.Enabled = false;
            this.chartY.Location = new System.Drawing.Point(581, 12);
            this.chartY.Name = "chartY";
            this.chartY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "AverageY";
            series1.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartY.Series.Add(series1);
            this.chartY.Size = new System.Drawing.Size(150, 512);
            this.chartY.TabIndex = 2;
            this.chartY.Text = "chartYAxis";
            // 
            // chartX
            // 
            this.chartX.BackColor = System.Drawing.Color.Transparent;
            this.chartX.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MinorGrid.Interval = double.NaN;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 100F;
            chartArea2.InnerPlotPosition.Width = 100F;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartX.ChartAreas.Add(chartArea2);
            this.chartX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartX.Enabled = false;
            this.chartX.Location = new System.Drawing.Point(63, 530);
            this.chartX.Name = "chartX";
            this.chartX.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "AverageX";
            this.chartX.Series.Add(series2);
            this.chartX.Size = new System.Drawing.Size(512, 150);
            this.chartX.TabIndex = 3;
            this.chartX.Text = "chartXAxis";
            // 
            // boxPicture2
            // 
            this.boxPicture2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPicture2.Location = new System.Drawing.Point(6, 49);
            this.boxPicture2.Name = "boxPicture2";
            this.boxPicture2.Size = new System.Drawing.Size(170, 170);
            this.boxPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.boxPicture2.TabIndex = 5;
            this.boxPicture2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(581, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Average row value"});
            this.comboBox1.Location = new System.Drawing.Point(2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.buttonLoadBackground);
            this.groupBox1.Controls.Add(this.boxPicture2);
            this.groupBox1.Location = new System.Drawing.Point(737, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 225);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxPicture3);
            this.groupBox2.Location = new System.Drawing.Point(737, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 225);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bias";
            // 
            // boxPicture3
            // 
            this.boxPicture3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPicture3.Location = new System.Drawing.Point(6, 49);
            this.boxPicture3.Name = "boxPicture3";
            this.boxPicture3.Size = new System.Drawing.Size(170, 170);
            this.boxPicture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.boxPicture3.TabIndex = 5;
            this.boxPicture3.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.boxPicture4);
            this.groupBox3.Location = new System.Drawing.Point(737, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 225);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Probe beam";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // boxPicture4
            // 
            this.boxPicture4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPicture4.Location = new System.Drawing.Point(6, 49);
            this.boxPicture4.Name = "boxPicture4";
            this.boxPicture4.Size = new System.Drawing.Size(170, 170);
            this.boxPicture4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.boxPicture4.TabIndex = 5;
            this.boxPicture4.TabStop = false;
            this.boxPicture4.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // buttonLoadBackground
            // 
            this.buttonLoadBackground.Location = new System.Drawing.Point(7, 20);
            this.buttonLoadBackground.Name = "buttonLoadBackground";
            this.buttonLoadBackground.Size = new System.Drawing.Size(50, 23);
            this.buttonLoadBackground.TabIndex = 6;
            this.buttonLoadBackground.Text = "Load";
            this.buttonLoadBackground.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SingleImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 721);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartX);
            this.Controls.Add(this.chartY);
            this.Controls.Add(this.boxPicture);
            this.Name = "SingleImageForm";
            this.Text = "Single image";
            this.Closed += new System.EventHandler(this.SingleImageForm_FormClosed);
            this.Load += new System.EventHandler(this.SingleImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.PictureBox boxPicture2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox boxPicture3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox boxPicture4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonLoadBackground;
    }
}