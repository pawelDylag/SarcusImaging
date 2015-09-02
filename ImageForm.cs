﻿using System;
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
    public partial class ImageForm : Form
    {
        private static ImageForm openedWindow = null;

        private static readonly int heatmapGradientHeight = 512;
        private static readonly int heatmapGradientWidth = 16;

        // TODO: Get rows and columns from camera object
        private static int cameraImagingRows = 512;
        private static int cameraImagingColumns = 512;

        // Raw image data for postprocessing 
        private static ushort[] atomsRawImage;
        private static ushort[] probeBeamRawImage;
        private static ushort[] backgroundRawImage;
        private static ushort[] biasRawImage;
        private static ushort[] mainRawImage;

        // final image rotation
        private static readonly RotateFlipType IMAGE_ROTATION = RotateFlipType.Rotate90FlipNone;
        // heatmap gradient stripe rotation
        private static readonly RotateFlipType GRADIENT_STRIPE_ROTATION = RotateFlipType.Rotate180FlipNone;


        public ImageForm()
        {
            InitializeComponent();
            initCharts();
            // hook event listeners
            CameraManager.Instance.ImageReady += this.OnImageReady;
            CameraManager.Instance.IterationEnded += this.OnIterationEnded;
            boxPicture.MouseMove += BoxPicture_MouseMove;
            // init main gradient color palette for values 0-65535
            ImageProcessor.initHeatmapGradient();
            // generate gradient stripe
            Bitmap gradient = ImageProcessor.convertArrayToHeatmapBitmap(generateHeatmapGradientValues(), heatmapGradientWidth, heatmapGradientHeight);
            // rotate gradient stripe for UI
            //gradient.RotateFlip(GRADIENT_STRIPE_ROTATION);
            gradient.Save("heatmapGradientStripe.png");
            // set gradient stripe picture 
            gradientPicture.Image = gradient;
            // init comboBoxes
            radioButton1.Select();
   
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

        /// <summary>
        /// Initialize main picture charts
        /// </summary>
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
            postProcessImages();
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
            //update mean and standard deviation information:
            if (mainRawImage != null) {
                double[] meanAndStandardDeviation = ImageProcessor.meanAndStandardDeviation(mainRawImage);
                labelMeanValue.BeginInvoke(
                   new Action(() =>
                   {
                       labelMeanValue.Text = meanAndStandardDeviation[0].ToString();
                   }));
                labelStandardDeviation.BeginInvoke(
                    new Action(() =>
                    {
                        labelStandardDeviation.Text = meanAndStandardDeviation[1].ToString();
                    }));
                // update charts and pixel values
                if (mainRawImage != null)
                {
                    updateXChart(mainRawImage, 512, 512);
                    updateYChart(mainRawImage, 512, 512);
                    updatePixelValues();
                }
            }
        }

        /// <summary>
        /// Generates result image from iteration sequence
        /// </summary>
        private void postProcessImages() 
        {
            // get selected radio button
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
            updateMainImage();
            updateProbeBeamImage();
        }

        private void updatePixelValues()
        {
            RadioButton selectedImageType = getSelectedMainImageRadioButton();
            if (selectedImageType != null)
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
        /// Updates main image
        /// </summary>
        public void updateMainImage()
        {
            if (mainRawImage != null)
            {
                Bitmap image = ImageProcessor.convertArrayToHeatmapBitmap(mainRawImage, cameraImagingColumns, cameraImagingRows);
                image.RotateFlip(GRADIENT_STRIPE_ROTATION);
                boxPicture.Image = image;
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
                image.RotateFlip(GRADIENT_STRIPE_ROTATION);
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
                image.RotateFlip(GRADIENT_STRIPE_ROTATION);
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
                image.RotateFlip(GRADIENT_STRIPE_ROTATION);
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
                image.RotateFlip(GRADIENT_STRIPE_ROTATION);
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
            if (SarcusImaging.DEBUG_MODE)
            {
                mainRawImage = ImageProcessor.generateRandomUshortArray(512, 512, 4);
                updateMainImage();
                updateImageInfoViews();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}