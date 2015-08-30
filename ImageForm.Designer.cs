namespace SarcusImaging
{
    partial class ImageForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.boxPicture = new System.Windows.Forms.PictureBox();
            this.chartY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.biasPicture = new System.Windows.Forms.PictureBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundPicture = new System.Windows.Forms.PictureBox();
            this.gradientPicture = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.probeBeamPicture = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.atomsPicture = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelCursorValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMaxValue = new System.Windows.Forms.Label();
            this.labelMinValue = new System.Windows.Forms.Label();
            this.labelMainImageName = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probeBeamPicture)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atomsPicture)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxPicture
            // 
            this.boxPicture.Location = new System.Drawing.Point(63, 34);
            this.boxPicture.Name = "boxPicture";
            this.boxPicture.Size = new System.Drawing.Size(512, 512);
            this.boxPicture.TabIndex = 0;
            this.boxPicture.TabStop = false;
            // 
            // chartY
            // 
            this.chartY.BackColor = System.Drawing.Color.Transparent;
            this.chartY.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea3.AxisX2.IsLabelAutoFit = false;
            chartArea3.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea3.AxisX2.LabelStyle.Angle = -45;
            chartArea3.AxisX2.LabelStyle.Enabled = false;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX2.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Interval = 0D;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.AxisY2.IsLabelAutoFit = false;
            chartArea3.AxisY2.LabelStyle.Angle = 45;
            chartArea3.AxisY2.LabelStyle.Enabled = false;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 100F;
            chartArea3.InnerPlotPosition.Width = 100F;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 100F;
            chartArea3.Position.Width = 100F;
            this.chartY.ChartAreas.Add(chartArea3);
            this.chartY.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartY.Enabled = false;
            this.chartY.Location = new System.Drawing.Point(581, 34);
            this.chartY.Name = "chartY";
            this.chartY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Name = "AverageY";
            series3.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartY.Series.Add(series3);
            this.chartY.Size = new System.Drawing.Size(150, 512);
            this.chartY.TabIndex = 2;
            this.chartY.Text = "chartYAxis";
            // 
            // chartX
            // 
            this.chartX.BackColor = System.Drawing.Color.Transparent;
            this.chartX.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea4.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MinorGrid.Interval = double.NaN;
            chartArea4.AxisX.MinorTickMark.Enabled = true;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.BorderColor = System.Drawing.Color.Transparent;
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 100F;
            chartArea4.InnerPlotPosition.Width = 100F;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 100F;
            chartArea4.Position.Width = 100F;
            this.chartX.ChartAreas.Add(chartArea4);
            this.chartX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartX.Enabled = false;
            this.chartX.Location = new System.Drawing.Point(63, 552);
            this.chartX.Name = "chartX";
            this.chartX.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "AverageX";
            this.chartX.Series.Add(series4);
            this.chartX.Size = new System.Drawing.Size(512, 150);
            this.chartX.TabIndex = 3;
            this.chartX.Text = "chartXAxis";
            // 
            // biasPicture
            // 
            this.biasPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.biasPicture.Location = new System.Drawing.Point(6, 19);
            this.biasPicture.Name = "biasPicture";
            this.biasPicture.Size = new System.Drawing.Size(170, 170);
            this.biasPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.biasPicture.TabIndex = 5;
            this.biasPicture.TabStop = false;
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Absorptive",
            "Fluorescent",
            "Atoms ",
            "Probe beam",
            "Background",
            "Bias"});
            this.comboBoxMode.Location = new System.Drawing.Point(9, 20);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(135, 21);
            this.comboBoxMode.TabIndex = 0;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.biasPicture);
            this.groupBox1.Location = new System.Drawing.Point(936, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 200);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bias";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.backgroundPicture);
            this.groupBox3.Location = new System.Drawing.Point(742, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 200);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Background";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // backgroundPicture
            // 
            this.backgroundPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundPicture.Location = new System.Drawing.Point(6, 19);
            this.backgroundPicture.Name = "backgroundPicture";
            this.backgroundPicture.Size = new System.Drawing.Size(170, 170);
            this.backgroundPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backgroundPicture.TabIndex = 5;
            this.backgroundPicture.TabStop = false;
            this.backgroundPicture.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // gradientPicture
            // 
            this.gradientPicture.Location = new System.Drawing.Point(25, 34);
            this.gradientPicture.Name = "gradientPicture";
            this.gradientPicture.Size = new System.Drawing.Size(32, 512);
            this.gradientPicture.TabIndex = 11;
            this.gradientPicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.probeBeamPicture);
            this.groupBox2.Location = new System.Drawing.Point(936, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 200);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Probe beam";
            // 
            // probeBeamPicture
            // 
            this.probeBeamPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probeBeamPicture.Location = new System.Drawing.Point(6, 19);
            this.probeBeamPicture.Name = "probeBeamPicture";
            this.probeBeamPicture.Size = new System.Drawing.Size(170, 170);
            this.probeBeamPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.probeBeamPicture.TabIndex = 5;
            this.probeBeamPicture.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.atomsPicture);
            this.groupBox4.Location = new System.Drawing.Point(742, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 200);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Atoms";
            // 
            // atomsPicture
            // 
            this.atomsPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.atomsPicture.Location = new System.Drawing.Point(6, 19);
            this.atomsPicture.Name = "atomsPicture";
            this.atomsPicture.Size = new System.Drawing.Size(170, 170);
            this.atomsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.atomsPicture.TabIndex = 5;
            this.atomsPicture.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelCursorValue);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(581, 613);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 55);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Image info";
            // 
            // labelCursorValue
            // 
            this.labelCursorValue.AutoSize = true;
            this.labelCursorValue.Location = new System.Drawing.Point(81, 20);
            this.labelCursorValue.Name = "labelCursorValue";
            this.labelCursorValue.Size = new System.Drawing.Size(37, 13);
            this.labelCursorValue.TabIndex = 1;
            this.labelCursorValue.Text = "65535";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cursor value:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelMaxValue
            // 
            this.labelMaxValue.AutoSize = true;
            this.labelMaxValue.BackColor = System.Drawing.Color.Transparent;
            this.labelMaxValue.Location = new System.Drawing.Point(22, 18);
            this.labelMaxValue.Name = "labelMaxValue";
            this.labelMaxValue.Size = new System.Drawing.Size(37, 13);
            this.labelMaxValue.TabIndex = 3;
            this.labelMaxValue.Text = "65535";
            this.labelMaxValue.Click += new System.EventHandler(this.label6_Click);
            // 
            // labelMinValue
            // 
            this.labelMinValue.AutoSize = true;
            this.labelMinValue.BackColor = System.Drawing.Color.Transparent;
            this.labelMinValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMinValue.Location = new System.Drawing.Point(22, 549);
            this.labelMinValue.Name = "labelMinValue";
            this.labelMinValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelMinValue.Size = new System.Drawing.Size(13, 13);
            this.labelMinValue.TabIndex = 4;
            this.labelMinValue.Text = "0";
            // 
            // labelMainImageName
            // 
            this.labelMainImageName.AutoSize = true;
            this.labelMainImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMainImageName.Location = new System.Drawing.Point(65, 9);
            this.labelMainImageName.Name = "labelMainImageName";
            this.labelMainImageName.Size = new System.Drawing.Size(0, 20);
            this.labelMainImageName.TabIndex = 13;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxMode);
            this.groupBox6.Location = new System.Drawing.Point(581, 552);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 55);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Image mode:";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 721);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.labelMainImageName);
            this.Controls.Add(this.labelMaxValue);
            this.Controls.Add(this.labelMinValue);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gradientPicture);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartX);
            this.Controls.Add(this.chartY);
            this.Controls.Add(this.boxPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImageForm";
            this.ShowIcon = false;
            this.Text = "Image view";
            this.Closed += new System.EventHandler(this.SingleImageForm_FormClosed);
            this.Load += new System.EventHandler(this.SingleImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.probeBeamPicture)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.atomsPicture)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.PictureBox biasPicture;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox backgroundPicture;
        private System.Windows.Forms.PictureBox gradientPicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox probeBeamPicture;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox atomsPicture;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMaxValue;
        private System.Windows.Forms.Label labelMinValue;
        private System.Windows.Forms.Label labelCursorValue;
        private System.Windows.Forms.Label labelMainImageName;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}