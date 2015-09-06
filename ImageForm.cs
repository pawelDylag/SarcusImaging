using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SarcusImaging
{
    /// <summary>
    /// Form class for displaying images with info in UI
    /// </summary>
    public partial class ImageForm : Form
    {
        private static ImageForm openedWindow = null;

        private static readonly int heatmapGradientHeight = 512;
        private static readonly int heatmapGradientWidth = 16;

        // Camera imaging rows and columns
        private static int cameraImagingRows = 512;
        private static int cameraImagingColumns = 512;

        // Raw image data for postprocessing 
        private static ushort[] atomsRawImage;
        private static ushort[] probeBeamRawImage;
        private static ushort[] backgroundRawImage;
        private static ushort[] biasRawImage;
        private static ushort[] mainRawImage;

        // Main image bitmap object for drawing fit rectangles on it
        private static Bitmap mainImageBitmap;

        // User fit settings from fit params dialog and fit results 
        private FitParams fitParams;
        private FitResults fitResults;

        // final image rotation
        private static readonly RotateFlipType IMAGE_ROTATION = RotateFlipType.RotateNoneFlipY;
        // heatmap gradient stripe rotation
        private static readonly RotateFlipType GRADIENT_STRIPE_ROTATION = RotateFlipType.Rotate180FlipNone;


        /// <summary>
        /// Class constructor. 
        /// Handles object initialization and gradient computing
        /// </summary>
        public ImageForm()
        {
            InitializeComponent();
            initCharts();
            // hook event listeners
            CameraManager.Instance.ImageReady += this.OnImageReady;
            CameraManager.Instance.IterationEnded += this.OnIterationEnded;
            // init main gradient color palette for values 0-65535
            ImageProcessor.initHeatmapGradient();
            // generate gradient stripe
            Bitmap gradient = ImageProcessor.convertArrayToHeatmapBitmap(generateHeatmapGradientValues(), heatmapGradientWidth, heatmapGradientHeight);
            // rotate gradient stripe for UI
            gradient.RotateFlip(GRADIENT_STRIPE_ROTATION);
            gradient.Save("heatmapGradientStripe.png");
            // set gradient stripe picture 
            gradientPicture.Image = gradient;
            // init comboBoxes
            radioButton1.Select();
   
        }


        /// <summary>
        /// Initialize main picture charts
        /// </summary>
        public void initCharts()
        {
            chartX.ChartAreas[0].AxisX.Maximum = 512;
            chartX.ChartAreas[0].AxisX.Minimum = 0;

            chartY.ChartAreas[0].AxisY.Maximum = 512;
            chartY.ChartAreas[0].AxisY.Minimum = 0;

        }

        /// <summary>
        /// This method ensures that only one dialog is opened at given time
        /// </summary>
        public static void ShowForm(SarcusImaging parentForm)
        {
            if (openedWindow != null)
            {
                openedWindow.BringToFront();
            }
            else
            {
                openedWindow = new ImageForm();
                openedWindow.MdiParent = parentForm;
                openedWindow.Show();
                openedWindow.Location = new Point(250, 250);

            }
        }

        /// <summary>
        /// Shows bitmap inside pictureBox
        /// </summary>
        /// <param name="bitmap"></param>
        public void showBitmap(Bitmap bitmap)
        {
            boxPicture.Image = bitmap;
        }
        
        /// <summary>
        /// Event handling method for getting new image and refreshing pictureBox view.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="a"></param>
        public void OnImageReady(object source, ImageReadyArgs a)
        {
            Debug.WriteLine("OnImageReady(): Image form");
            switch (a.imageType)
            {
                case SequenceItem.types.TYPE_BIAS:
                    Debug.WriteLine("OnImageReady(): decoded type = bias");
                    biasRawImage = a.pixels;
                    updateBiasImage();
                    break;
                case SequenceItem.types.TYPE_BACKGROUND:
                    Debug.WriteLine("OnImageReady(): decoded type = background");
                    backgroundRawImage = a.pixels;
                    updateBackgroundImage();
                    break;
                case SequenceItem.types.TYPE_PROBE:
                    Debug.WriteLine("OnImageReady(): decoded type = probe beam");
                    probeBeamRawImage = a.pixels;
                    updateProbeBeamImage();
                    break;
                case SequenceItem.types.TYPE_SEQUENCE:
                    Debug.WriteLine("OnImageReady(): decoded type = atoms");
                    atomsRawImage = a.pixels;
                    updateAtomsImage();
                    break;
                default:
                    Debug.WriteLine("OnImageReady(): decoded type = default");
                    break;
            }

        }

        /// <summary>
        /// Event handling method - starts postprocessing and images display
        /// </summary>
        /// <param name="source"></param>
        /// <param name="a"></param>
        public void OnIterationEnded(object source, EventArgs a)
        {
            Debug.WriteLine("OnIterationEnded(): received event");
            postProcessMainImage();
            generateNewImageName();
            saveMainRawImageToMemory();
            updateAllImages();
            updateImageInfoViews();
        }

        /// <summary>
        /// Returns selected radio button for mainImage groupBox
        /// </summary>
        /// <returns></returns>
        private RadioButton getSelectedMainImageRadioButton()
        {
            RadioButton result = null;
            foreach(RadioButton r in groupBoxMainImageType.Controls)
            {
                if (r.Checked) result = r;
            }
            return result;
        }

        /// <summary>
        /// Creates raw image file name
        /// </summary>
        private void generateNewImageName()
        {
            RadioButton selectedImageType = getSelectedMainImageRadioButton();
            if (selectedImageType != null)
            {
                String name = string.Format(selectedImageType.Text.ToLower() + "-{0:dd-MM-yyyy_H-mm-ss}.txt", DateTime.Now);
                labelMainImageName.BeginInvoke(
                new Action(() =>
                  {
                       labelMainImageName.Text = name;
                  }));
            }
        }

        /// <summary>
        /// Updates image info labels and UI views
        /// </summary>
        private void updateImageInfoViews()
        {
            if (mainRawImage != null) {
                updateXChart(mainRawImage, 512, 512);
                updateYChart(mainRawImage, 512, 512);
                // update charts and pixel values
                if (!checkBoxDisableFit.Checked)
                {
                    updatePixelValues();


                }
            }
        }

        /// <summary>
        /// Generates result image from iteration sequence
        /// </summary>
        private void postProcessMainImage() 
        {
            // get selected image postprocess type via button
            RadioButton selectedImageType = getSelectedMainImageRadioButton();
            if (selectedImageType != null)
            {
                switch (selectedImageType.Name)
                {
                    case "Absorptive":
                        if (atomsRawImage != null && biasRawImage != null)
                        {
                            mainRawImage = new ushort[cameraImagingColumns * cameraImagingRows];
                            for (int i = 0; i < mainRawImage.Length; i++)
                            {
                                int value = atomsRawImage[i] - biasRawImage[i];
                                if (value < 0) value = 0;
                                mainRawImage[i] = (ushort)value;

                            }
                        }
                        break;
                    case "Fluorescent":
                        if (atomsRawImage != null && biasRawImage != null && probeBeamRawImage != null && backgroundRawImage != null)
                        {
                            mainRawImage = new ushort[cameraImagingColumns * cameraImagingRows];
                            for (int i = 0; i < mainRawImage.Length; i++)
                            {
                                int value = atomsRawImage[i] - biasRawImage[i];
                                if (value < 0) value = 0;
                                mainRawImage[i] = (ushort)value;
                            }
                        }
                        break;
                    default:
                        mainRawImage = atomsRawImage;
                        break;
                }
            }
            // run fitting algorithms, get fitResults in return
            fitResults = generateAndDisplayFitData();
            // convert raw data to bitmap 
            mainImageBitmap = ImageProcessor.convertArrayToHeatmapBitmap(mainRawImage, cameraImagingColumns, cameraImagingRows);
            // draw fit result rectangle on image bitmap
            drawFitRectangle(mainImageBitmap, fitResults);
            // rotate image bitmap to match user coords
            mainImageBitmap.RotateFlip(IMAGE_ROTATION);
            mainImageBitmap.Save("bitmapColor.png");
        }

        /// <summary>
        /// Saves computed main image to computer memory
        /// </summary>
        private void saveMainRawImageToMemory()
        {
            if (mainRawImage != null)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Dinnaug\Documents\Visual Studio 2015\Debug\data.txt"))
                {
                    foreach (ushort b in mainRawImage)
                    {
                        file.Write(b);
                        file.Write(' ');
                    }
                }
            }
        }

        /// <summary>
        /// Save bitmap image to memory. This is the final heatmap image, not raw camera data.
        /// </summary>
        /// <param name="image"></param>
        private void saveBitmapImageToMemory(Bitmap image, String filename)
        {
            if (image != null)
            {
                image.Save(filename);
            }
        }

        /// <summary>
        /// Updates all images
        /// </summary>
        public void updateAllImages()
        {
            updateAtomsImage();
            updateBackgroundImage();
            updateBiasImage();
            updateProbeBeamImage();
            updateMainImage();
        }

        /// <summary>
        /// Update
        /// </summary>
        private void updatePixelValues()
        {
            if (mainRawImage != null)
            {
                labelMinValue.BeginInvoke(
                new Action(() =>
                {
                    labelMinValue.Text = "" + ImageProcessor.getUshortMinMaxValues(mainRawImage)[0];
                }));

                labelMaxValue.BeginInvoke(
                new Action(() =>
                {
                    labelMaxValue.Text = "" + ImageProcessor.getUshortMinMaxValues(mainRawImage)[1];
                }));
            }
        }


        /// <summary>
        /// Updates main image with bitmap object
        /// </summary>
        public void updateMainImage()
        {
            if (mainImageBitmap != null)
            {
                boxPicture.Image = mainImageBitmap;
            }
        }

        /// <summary>
        /// Updates bias image
        /// </summary>
        public void updateBiasImage()
        {
            if (biasRawImage != null)
            {
                Bitmap image = ImageProcessor.convertArrayToHeatmapBitmap(biasRawImage, cameraImagingColumns, cameraImagingRows);
                image.RotateFlip(IMAGE_ROTATION);
                biasPicture.Image = image;
            }
        }

        /// <summary>
        /// Updates background image
        /// </summary>
        public void updateBackgroundImage()
        {
            if (backgroundRawImage != null)
            {
                Bitmap image = ImageProcessor.convertArrayToHeatmapBitmap(backgroundRawImage, cameraImagingColumns, cameraImagingRows);
                image.RotateFlip(IMAGE_ROTATION);
                backgroundPicture.Image = image;
            }
        }

        /// <summary>
        /// Updates probe image
        /// </summary>
        public void updateProbeBeamImage()
        {
            if (probeBeamRawImage != null)
            {
                Bitmap image = ImageProcessor.convertArrayToHeatmapBitmap(probeBeamRawImage, cameraImagingColumns, cameraImagingRows);
                image.RotateFlip(IMAGE_ROTATION);
                probeBeamPicture.Image = image;
            }
        }

        /// <summary>
        /// Updates atoms image
        /// </summary>
        public void updateAtomsImage()
        {
            if (atomsRawImage != null)
            {
                Bitmap image = ImageProcessor.convertArrayToHeatmapBitmap(atomsRawImage, cameraImagingColumns, cameraImagingRows);
                image.RotateFlip(IMAGE_ROTATION);
                atomsPicture.Image = image;
            }
        }

        public void updateXChart (ushort[] data, int width, int height)
        {
            chartX.BeginInvoke(
               new Action(() =>
               {

                   ushort[] averageX = ImageProcessor.getImageXAveragePixelValue(data, width, height);
                   chartX.Series["AverageX"].Points.Clear();
                   for (int i = 0; i < width; i++)
                   {
                       DataPoint dp = new DataPoint();
                       dp.SetValueXY(i, averageX[i]);
                       chartX.Series["AverageX"].Points.Add(dp);
                   }
               }));
        }

        public void updateYChart(ushort[] data, int width, int height)
        {
            chartY.BeginInvoke(
               new Action(() =>
               {
                   ushort[] averageY = ImageProcessor.getImageYAveragePixelValue(data, width, height);
                   chartY.Series["AverageY"].Points.Clear();
                   for (int i = 0; i < height; i++)
                   {
                       DataPoint dp = new DataPoint();
                       dp.SetValueXY(averageY[i], i);
                       chartY.Series["AverageY"].Points.Add(dp);
                   }
               }));
        }

        /// <summary>
        /// Generates heatmap gradient for display
        /// </summary>
        /// <returns></returns>
        private ushort[] generateHeatmapGradientValues()
        {
            ushort[] pixels = new ushort[heatmapGradientHeight * heatmapGradientWidth];
            // Step through the image by row
            for (int y = 0; y < heatmapGradientHeight; y++)
            {
                // Step through the image by column  
                for (int x = 0; x < heatmapGradientWidth; x++)
                {
                    // compute index of input array
                    int inIndex = (y * heatmapGradientWidth) + x;
                    ushort step =   (ushort) Math.Floor((double)(ushort.MaxValue / heatmapGradientHeight)); // = 127
                    ushort colorValue = (ushort) (step * y);
                    pixels[inIndex] = colorValue;
                }
            }
            return pixels;
        }

        /// <summary>
        /// Debug method for loading test camera data for mean and standard deviation tests
        /// </summary>
        private void loadTestDataOnClick()
        {
            int width = 512;
            int height = 512;
            int index = 0;
            ushort[] rawData = new ushort[width * height];
            StreamReader sr = new StreamReader("danetestowe2.txt");
            // Step through the image by row
            for (int x = 0; x < width; x++)
            { 
                // Step through the image by column  
                for (int y = 0; y < height; y++)
                {
                    // compute index of input array
                    String line = sr.ReadLine();
                    ushort value;
                    if (ushort.TryParse(line, out value))
                    rawData[index++] = value; 
                }
            }
            generateNewImageName();
            atomsRawImage = rawData;
            updateAtomsImage();
            mainRawImage = rawData;
            postProcessMainImage();
            updateMainImage();
            updateImageInfoViews();
            biasRawImage = ImageProcessor.generateRandomUshortArray(512, 512, 0);
            updateBiasImage();
            probeBeamRawImage = rawData;
            updateProbeBeamImage();
            backgroundRawImage = ImageProcessor.generateRandomUshortArray(512, 512, 0); ;
            updateBackgroundImage();


        }

        /// <summary>
        /// Launch fitting operation and display results on screen
        /// </summary>
        private FitResults generateAndDisplayFitData ()
        {
            FitResults result = new FitResults();
            if (mainRawImage != null)
            {
                fitParams = new FitParams();
                fitParams.amplitude = 0.3 * 32000;
                fitParams.center = 215;
                fitParams.width = 148;
                fitParams.background = 0.2 * 32000;
                fitParams.epsF = 0;
                fitParams.epsX = 0;
                fitParams.maxIterations = 0;
                fitParams.diffStep = 0.00001;
                // main fitting procedure
                result = ImageProcessor.fitData(mainRawImage, 512, 512, fitParams);
                // display results on screen
                updateFitDataViews(result);
            }
            return result;
        }

        /// <summary>
        /// Draws rectangle with fit width, height and central point
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="fit"></param>
        /// <returns></returns>
        private Bitmap drawFitRectangle(Bitmap bitmap, FitResults fit)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                int centerY = (int)fit.centerY - ((int)fit.widthY)/2;
                int centerX = (int)fit.centerX - ((int)fit.widthX) / 2;
                g.DrawRectangle(new Pen(Color.Black), centerY , centerX, (int)fit.widthY, (int)fit.widthX);
            }
            return bitmap;
        }

        /// <summary>
        /// Update text views with fit result data
        /// </summary>
        /// <param name="fitResults"></param>
        private void updateFitDataViews(FitResults fitResults)
        {
            labelParams1.BeginInvoke(
               new Action(() =>
               {
                   labelParams1.Text = fitResults.amplitudeX.ToString();
               }));
            labelParams2.BeginInvoke(
               new Action(() =>
               {
                   labelParams2.Text = fitResults.centerX.ToString();
               }));
            labelParams3.BeginInvoke(
               new Action(() =>
               {
                   labelParams3.Text = fitResults.widthX.ToString();
               }));
            labelParams4.BeginInvoke(
               new Action(() =>
               {
                   labelParams4.Text = fitResults.backgroundX.ToString();
               }));
            labelParams5.BeginInvoke(
               new Action(() =>
               {
                   labelParams5.Text = fitResults.amplitudeY.ToString();
               }));
            labelParams6.BeginInvoke(
               new Action(() =>
               {
                   labelParams6.Text = fitResults.centerY.ToString();
               }));
            labelParams7.BeginInvoke(
               new Action(() =>
               {
                   labelParams7.Text = fitResults.widthY.ToString();
               }));
            labelParams8.BeginInvoke(
               new Action(() =>
               {
                   labelParams8.Text = fitResults.backgroundY.ToString();
               }));
        }


        private void SingleImageForm_FormClosed(object sender, EventArgs e)
        {
            // unsubscribe from image events
            CameraManager.Instance.ImageReady -= this.OnImageReady;
            CameraManager.Instance.IterationEnded -= this.OnIterationEnded;
            openedWindow = null;
        }


        private void SingleImageForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelMeanValue_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (SarcusImaging.DEBUG_MODE)
            {
                loadTestDataOnClick();
            }
            buttonTest.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartY_Click(object sender, EventArgs e)
        {

        }

        private void labelCursorValue_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
