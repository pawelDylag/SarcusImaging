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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundPicture = new System.Windows.Forms.PictureBox();
            this.gradientPicture = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.probeBeamPicture = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.atomsPicture = new System.Windows.Forms.PictureBox();
            this.labelCursorValue = new System.Windows.Forms.Label();
            this.labelMaxValue = new System.Windows.Forms.Label();
            this.labelMinValue = new System.Windows.Forms.Label();
            this.labelMainImageName = new System.Windows.Forms.Label();
            this.groupBoxMainImageType = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBoxFit = new System.Windows.Forms.GroupBox();
            this.labelMeanValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStandardDeviation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
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
            this.groupBoxMainImageType.SuspendLayout();
            this.groupBoxFit.SuspendLayout();
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
            this.gradientPicture.Size = new System.Drawing.Size(16, 512);
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
            // labelCursorValue
            // 
            this.labelCursorValue.AutoSize = true;
            this.labelCursorValue.BackColor = System.Drawing.Color.Transparent;
            this.labelCursorValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCursorValue.Location = new System.Drawing.Point(538, 18);
            this.labelCursorValue.Name = "labelCursorValue";
            this.labelCursorValue.Size = new System.Drawing.Size(10, 13);
            this.labelCursorValue.TabIndex = 1;
            this.labelCursorValue.Text = "-";
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
            this.labelMainImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMainImageName.Location = new System.Drawing.Point(104, 18);
            this.labelMainImageName.Name = "labelMainImageName";
            this.labelMainImageName.Size = new System.Drawing.Size(10, 13);
            this.labelMainImageName.TabIndex = 13;
            this.labelMainImageName.Text = "-";
            // 
            // groupBoxMainImageType
            // 
            this.groupBoxMainImageType.Controls.Add(this.radioButton6);
            this.groupBoxMainImageType.Controls.Add(this.radioButton5);
            this.groupBoxMainImageType.Controls.Add(this.radioButton4);
            this.groupBoxMainImageType.Controls.Add(this.radioButton3);
            this.groupBoxMainImageType.Controls.Add(this.radioButton2);
            this.groupBoxMainImageType.Controls.Add(this.radioButton1);
            this.groupBoxMainImageType.Location = new System.Drawing.Point(581, 549);
            this.groupBoxMainImageType.Name = "groupBoxMainImageType";
            this.groupBoxMainImageType.Size = new System.Drawing.Size(150, 153);
            this.groupBoxMainImageType.TabIndex = 15;
            this.groupBoxMainImageType.TabStop = false;
            this.groupBoxMainImageType.Text = "Main image";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 133);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(45, 17);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Bias";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged_1);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 111);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(83, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Background";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Probe beam";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Atoms";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Fluorescent";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Absorbtive";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBoxFit
            // 
            this.groupBoxFit.Controls.Add(this.labelMeanValue);
            this.groupBoxFit.Controls.Add(this.label4);
            this.groupBoxFit.Controls.Add(this.labelStandardDeviation);
            this.groupBoxFit.Controls.Add(this.label2);
            this.groupBoxFit.Location = new System.Drawing.Point(742, 447);
            this.groupBoxFit.Name = "groupBoxFit";
            this.groupBoxFit.Size = new System.Drawing.Size(379, 99);
            this.groupBoxFit.TabIndex = 16;
            this.groupBoxFit.TabStop = false;
            this.groupBoxFit.Text = "Main image parameters";
            this.groupBoxFit.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // labelMeanValue
            // 
            this.labelMeanValue.AutoSize = true;
            this.labelMeanValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMeanValue.Location = new System.Drawing.Point(111, 58);
            this.labelMeanValue.Name = "labelMeanValue";
            this.labelMeanValue.Size = new System.Drawing.Size(10, 13);
            this.labelMeanValue.TabIndex = 5;
            this.labelMeanValue.Text = "-";
            this.labelMeanValue.Click += new System.EventHandler(this.labelMeanValue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mean value:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelStandardDeviation
            // 
            this.labelStandardDeviation.AutoSize = true;
            this.labelStandardDeviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStandardDeviation.Location = new System.Drawing.Point(111, 34);
            this.labelStandardDeviation.Name = "labelStandardDeviation";
            this.labelStandardDeviation.Size = new System.Drawing.Size(10, 13);
            this.labelStandardDeviation.TabIndex = 3;
            this.labelStandardDeviation.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Standard deviation:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(463, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cursor value:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(60, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Name:";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(1020, 552);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(101, 23);
            this.buttonTest.TabIndex = 18;
            this.buttonTest.Text = "Load test data";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 721);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxFit);
            this.Controls.Add(this.groupBoxMainImageType);
            this.Controls.Add(this.labelMainImageName);
            this.Controls.Add(this.labelMaxValue);
            this.Controls.Add(this.labelMinValue);
            this.Controls.Add(this.labelCursorValue);
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
            this.groupBoxMainImageType.ResumeLayout(false);
            this.groupBoxMainImageType.PerformLayout();
            this.groupBoxFit.ResumeLayout(false);
            this.groupBoxFit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartX;
        private System.Windows.Forms.PictureBox biasPicture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox backgroundPicture;
        private System.Windows.Forms.PictureBox gradientPicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox probeBeamPicture;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox atomsPicture;
        private System.Windows.Forms.Label labelMaxValue;
        private System.Windows.Forms.Label labelMinValue;
        private System.Windows.Forms.Label labelCursorValue;
        private System.Windows.Forms.Label labelMainImageName;
        private System.Windows.Forms.GroupBox groupBoxMainImageType;
        private System.Windows.Forms.GroupBox groupBoxFit;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label labelStandardDeviation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMeanValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTest;
    }
}