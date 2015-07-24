using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SarcusImaging
{
    public partial class SingleImageForm : Form
    {

        private static SingleImageForm openedWindow = null;

        private static Bitmap heatmapGradient;

        private static readonly int heatmapGradientHeight = 512;
        private static readonly int heatmapGradientWidth = 32;

        // TODO: Get rows and columns from camera object
        private static int cameraImagingRows = 512;
        private static int cameraImagingColumns = 512;

        /// <summary>
        /// Raw image data for postprocessing 
        /// </summary>
        private static ushort[] atomsRawImage;
        private static ushort[] probeBeamRawImage;
        private static ushort[] backgroundRawImage;
        private static ushort[] biasRawImage;
        private static ushort[] mainRawImage;

        public SingleImageForm()
        {
            InitializeComponent();
            initCharts();
            CameraManager.Instance.ImageReady += this.OnImageReady;
            CameraManager.Instance.IterationEnded += this.OnIterationEnded;
            // init main gradient stripe
            ImageProcessor.interpolateColors(ImageProcessor.interpolationStepColors, ushort.MaxValue + 1);
            heatmapGradient = ImageProcessor.convertArrayToHeatmapBitmap(generateHeatmapGradient(), heatmapGradientWidth, heatmapGradientHeight);
            heatmapGradient.RotateFlip(RotateFlipType.Rotate180FlipNone);
            gradientPicture.Image = heatmapGradient;
            boxPicture.MouseMove += BoxPicture_MouseMove;

        }

        /// <summary>
        /// Show pixel value under the cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (mainRawImage != null)
            {
                int index = (e.Y * cameraImagingColumns + e.X);
                labelCursorValue.Text = "" + mainRawImage[index];
            }
        }

        public void initCharts()
        {
            chartX.ChartAreas[0].AxisX.Maximum = 512;
            chartX.ChartAreas[0].AxisX.Minimum = 0;

            chartY.ChartAreas[0].AxisY2.Maximum = 512;
            chartY.ChartAreas[0].AxisY2.Minimum = 0;

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
                openedWindow = new SingleImageForm();
                openedWindow.MdiParent = parentForm;
                openedWindow.Show();
            }
        }

        public SingleImageForm(int value)
        {
            InitializeComponent();
            // subscribe to image event list
            CameraManager.Instance.ImageReady += this.OnImageReady;
            ushort[] pixels = ImageProcessor.generateRandomUshortArray(512, 512, 0);
            Bitmap bitmap = ImageProcessor.convertArrayToHeatmapBitmap(pixels, 512, 512);
            boxPicture.Image = bitmap;
            //Form settingsForm = new ImageSettings(this);
            //settingsForm.Show();
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
                    break;
                case SequenceItem.types.TYPE_BACKGROUND:
                    Debug.WriteLine("OnImageReady(): decoded type = background");
                    backgroundRawImage = a.pixels;
                    break;
                case SequenceItem.types.TYPE_PROBE:
                    Debug.WriteLine("OnImageReady(): decoded type = probe beam");
                    probeBeamRawImage = a.pixels;
                    break;
                case SequenceItem.types.TYPE_SEQUENCE:
                    Debug.WriteLine("OnImageReady(): decoded type = atoms");
                    atomsRawImage = a.pixels;
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
            postProcessImages();
            updateAll();
        }

        /// <summary>
        /// Generates result image from iteration sequence
        /// </summary>
        private void postProcessImages() 
        {
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
        }

        /// <summary>
        /// Updates all images
        /// </summary>
        public void updateAll()
        {
            updateAtomsImage();
            updateBackgroundImage();
            updateBiasImage();
            updateMainImage();
            updateProbeBeamImage();
            if (mainRawImage != null)
            {
                updateXChart(mainRawImage, 512, 512);
                updateYChart(mainRawImage, 512, 512);
                updatePixelValues();
            }

        }

        private void updatePixelValues()
        {
            labelMinValue.Text = "" + ImageProcessor.getUshortMinMaxValues(mainRawImage)[0];
            labelMaxValue.Text = "" + ImageProcessor.getUshortMinMaxValues(mainRawImage)[1];
        }

        /// <summary>
        /// Updates main image
        /// </summary>
        public void updateMainImage()
        {
            if (mainRawImage != null)
                boxPicture.Image = ImageProcessor.convertArrayToHeatmapBitmap(mainRawImage, cameraImagingColumns, cameraImagingRows);
        }

        /// <summary>
        /// Updates bias image
        /// </summary>
        public void updateBiasImage()
        {
            if (biasRawImage != null)
            biasPicture.Image = ImageProcessor.convertArrayToHeatmapBitmap(biasRawImage, cameraImagingColumns, cameraImagingRows);
        }

        /// <summary>
        /// Updates background image
        /// </summary>
        public void updateBackgroundImage()
        {
            if (backgroundRawImage != null)
            backgroundPicture.Image = ImageProcessor.convertArrayToHeatmapBitmap(backgroundRawImage, cameraImagingColumns, cameraImagingRows);
        }

        /// <summary>
        /// Updates probe image
        /// </summary>
        public void updateProbeBeamImage()
        {
            if (probeBeamRawImage != null)
            probeBeamPicture.Image = ImageProcessor.convertArrayToHeatmapBitmap(probeBeamRawImage, cameraImagingColumns, cameraImagingRows);
        }

        /// <summary>
        /// Updates atoms image
        /// </summary>
        public void updateAtomsImage()
        {
            if (atomsRawImage != null)
            atomsPicture.Image = ImageProcessor.convertArrayToHeatmapBitmap(atomsRawImage, cameraImagingColumns, cameraImagingRows);
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
        private ushort[] generateHeatmapGradient()
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
                    ushort step = (ushort)(ushort.MaxValue / heatmapGradientHeight); // = 127
                    ushort colorValue = (ushort) (step * y);
                    pixels[inIndex] = colorValue;
                }
            }
            return pixels;
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
    }
}
