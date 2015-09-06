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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.boxPicture = new System.Windows.Forms.PictureBox();
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
            this.groupBoxFit = new System.Windows.Forms.GroupBox();
            this.buttonFitParameters = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelParams2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelParams1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelParams3 = new System.Windows.Forms.Label();
            this.labelParams4 = new System.Windows.Forms.Label();
            this.labelParams7 = new System.Windows.Forms.Label();
            this.labelParams6 = new System.Windows.Forms.Label();
            this.labelParams5 = new System.Windows.Forms.Label();
            this.labelParams8 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxDisableFit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBoxMainImageType = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chartY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).BeginInit();
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
            this.groupBoxFit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxMainImageType.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPicture
            // 
            this.boxPicture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.boxPicture.Location = new System.Drawing.Point(63, 34);
            this.boxPicture.Name = "boxPicture";
            this.boxPicture.Size = new System.Drawing.Size(512, 512);
            this.boxPicture.TabIndex = 0;
            this.boxPicture.TabStop = false;
            // 
            // chartX
            // 
            this.chartX.BackColor = System.Drawing.Color.Transparent;
            this.chartX.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MinorGrid.Interval = double.NaN;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartX.ChartAreas.Add(chartArea1);
            this.chartX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartX.Enabled = false;
            this.chartX.Location = new System.Drawing.Point(63, 552);
            this.chartX.Name = "chartX";
            this.chartX.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "AverageX";
            this.chartX.Series.Add(series1);
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
            this.labelCursorValue.Location = new System.Drawing.Point(49, 23);
            this.labelCursorValue.Name = "labelCursorValue";
            this.labelCursorValue.Size = new System.Drawing.Size(10, 13);
            this.labelCursorValue.TabIndex = 1;
            this.labelCursorValue.Text = "-";
            this.labelCursorValue.Click += new System.EventHandler(this.labelCursorValue_Click);
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
            // groupBoxFit
            // 
            this.groupBoxFit.Controls.Add(this.richTextBox1);
            this.groupBoxFit.Controls.Add(this.buttonFitParameters);
            this.groupBoxFit.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxFit.Controls.Add(this.checkBoxDisableFit);
            this.groupBoxFit.Location = new System.Drawing.Point(742, 446);
            this.groupBoxFit.Name = "groupBoxFit";
            this.groupBoxFit.Size = new System.Drawing.Size(388, 256);
            this.groupBoxFit.TabIndex = 16;
            this.groupBoxFit.TabStop = false;
            this.groupBoxFit.Text = "Fit parameters";
            this.groupBoxFit.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // buttonFitParameters
            // 
            this.buttonFitParameters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFitParameters.Location = new System.Drawing.Point(288, 220);
            this.buttonFitParameters.Name = "buttonFitParameters";
            this.buttonFitParameters.Size = new System.Drawing.Size(94, 23);
            this.buttonFitParameters.TabIndex = 10;
            this.buttonFitParameters.Text = "Parameters";
            this.buttonFitParameters.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.11828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.44086F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.44086F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelParams2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelParams1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelParams3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelParams4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelParams7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelParams6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelParams5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelParams8, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 120);
            this.tableLayoutPanel1.TabIndex = 8;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amplitude";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelParams2
            // 
            this.labelParams2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams2.AutoSize = true;
            this.labelParams2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams2.Location = new System.Drawing.Point(90, 51);
            this.labelParams2.Name = "labelParams2";
            this.labelParams2.Size = new System.Drawing.Size(10, 13);
            this.labelParams2.TabIndex = 5;
            this.labelParams2.Text = "-";
            this.labelParams2.Click += new System.EventHandler(this.labelMeanValue_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(4, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Background";
            // 
            // labelParams1
            // 
            this.labelParams1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams1.AutoSize = true;
            this.labelParams1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams1.Location = new System.Drawing.Point(90, 28);
            this.labelParams1.Name = "labelParams1";
            this.labelParams1.Size = new System.Drawing.Size(10, 13);
            this.labelParams1.TabIndex = 3;
            this.labelParams1.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Center";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(4, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Width";
            // 
            // labelParams3
            // 
            this.labelParams3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams3.AutoSize = true;
            this.labelParams3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams3.Location = new System.Drawing.Point(90, 74);
            this.labelParams3.Name = "labelParams3";
            this.labelParams3.Size = new System.Drawing.Size(10, 13);
            this.labelParams3.TabIndex = 8;
            this.labelParams3.Text = "-";
            // 
            // labelParams4
            // 
            this.labelParams4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams4.AutoSize = true;
            this.labelParams4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams4.Location = new System.Drawing.Point(90, 99);
            this.labelParams4.Name = "labelParams4";
            this.labelParams4.Size = new System.Drawing.Size(10, 13);
            this.labelParams4.TabIndex = 9;
            this.labelParams4.Text = "-";
            // 
            // labelParams7
            // 
            this.labelParams7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams7.AutoSize = true;
            this.labelParams7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams7.Location = new System.Drawing.Point(232, 74);
            this.labelParams7.Name = "labelParams7";
            this.labelParams7.Size = new System.Drawing.Size(10, 13);
            this.labelParams7.TabIndex = 12;
            this.labelParams7.Text = "-";
            // 
            // labelParams6
            // 
            this.labelParams6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams6.AutoSize = true;
            this.labelParams6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams6.Location = new System.Drawing.Point(232, 51);
            this.labelParams6.Name = "labelParams6";
            this.labelParams6.Size = new System.Drawing.Size(10, 13);
            this.labelParams6.TabIndex = 11;
            this.labelParams6.Text = "-";
            // 
            // labelParams5
            // 
            this.labelParams5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams5.AutoSize = true;
            this.labelParams5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams5.Location = new System.Drawing.Point(232, 28);
            this.labelParams5.Name = "labelParams5";
            this.labelParams5.Size = new System.Drawing.Size(10, 13);
            this.labelParams5.TabIndex = 10;
            this.labelParams5.Text = "-";
            // 
            // labelParams8
            // 
            this.labelParams8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParams8.AutoSize = true;
            this.labelParams8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParams8.Location = new System.Drawing.Point(232, 99);
            this.labelParams8.Name = "labelParams8";
            this.labelParams8.Size = new System.Drawing.Size(10, 13);
            this.labelParams8.TabIndex = 13;
            this.labelParams8.Text = "-";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(293, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Y";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(150, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "X";
            // 
            // checkBoxDisableFit
            // 
            this.checkBoxDisableFit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxDisableFit.AutoSize = true;
            this.checkBoxDisableFit.Location = new System.Drawing.Point(9, 224);
            this.checkBoxDisableFit.Name = "checkBoxDisableFit";
            this.checkBoxDisableFit.Size = new System.Drawing.Size(67, 17);
            this.checkBoxDisableFit.TabIndex = 10;
            this.checkBoxDisableFit.Text = "Disabled";
            this.checkBoxDisableFit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Value:";
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
            this.buttonTest.Location = new System.Drawing.Point(1011, 8);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(101, 23);
            this.buttonTest.TabIndex = 18;
            this.buttonTest.Text = "Load test data";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
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
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
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
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Normal";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBoxMainImageType
            // 
            this.groupBoxMainImageType.Controls.Add(this.radioButton3);
            this.groupBoxMainImageType.Controls.Add(this.radioButton2);
            this.groupBoxMainImageType.Controls.Add(this.radioButton1);
            this.groupBoxMainImageType.Location = new System.Drawing.Point(581, 549);
            this.groupBoxMainImageType.Name = "groupBoxMainImageType";
            this.groupBoxMainImageType.Size = new System.Drawing.Size(150, 90);
            this.groupBoxMainImageType.TabIndex = 15;
            this.groupBoxMainImageType.TabStop = false;
            this.groupBoxMainImageType.Text = "Main image";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.labelCursorValue);
            this.groupBox5.Location = new System.Drawing.Point(581, 643);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 59);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cursor";
            // 
            // chartY
            // 
            this.chartY.BackColor = System.Drawing.Color.Transparent;
            this.chartY.BorderlineColor = System.Drawing.Color.Transparent;
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
            this.chartY.ChartAreas.Add(chartArea2);
            this.chartY.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartY.Enabled = false;
            this.chartY.Location = new System.Drawing.Point(581, 34);
            this.chartY.Name = "chartY";
            this.chartY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "AverageY";
            this.chartY.Series.Add(series2);
            this.chartY.Size = new System.Drawing.Size(150, 512);
            this.chartY.TabIndex = 20;
            this.chartY.Text = "chartY";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 147);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(373, 67);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 721);
            this.Controls.Add(this.chartY);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxFit);
            this.Controls.Add(this.groupBoxMainImageType);
            this.Controls.Add(this.labelMainImageName);
            this.Controls.Add(this.labelMaxValue);
            this.Controls.Add(this.labelMinValue);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gradientPicture);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartX);
            this.Controls.Add(this.boxPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImageForm";
            this.ShowIcon = false;
            this.Text = "Image view";
            this.Closed += new System.EventHandler(this.SingleImageForm_FormClosed);
            this.Load += new System.EventHandler(this.SingleImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxPicture)).EndInit();
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
            this.groupBoxFit.ResumeLayout(false);
            this.groupBoxFit.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxMainImageType.ResumeLayout(false);
            this.groupBoxMainImageType.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPicture;
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
        private System.Windows.Forms.GroupBox groupBoxFit;
        private System.Windows.Forms.Label labelParams1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelParams2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelParams3;
        private System.Windows.Forms.Label labelParams4;
        private System.Windows.Forms.Label labelParams7;
        private System.Windows.Forms.Label labelParams6;
        private System.Windows.Forms.Label labelParams5;
        private System.Windows.Forms.Label labelParams8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonFitParameters;
        private System.Windows.Forms.CheckBox checkBoxDisableFit;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBoxMainImageType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartY;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}