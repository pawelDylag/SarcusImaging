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

        public SingleImageForm()
        {
            InitializeComponent();
            initCharts();
            CameraManager.Instance.ImageReady += this.OnImageReady;
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

        public SingleImageForm(ushort[] image)
        {
            InitializeComponent();
            // subscribe to image event list
            CameraManager.Instance.ImageReady += this.OnImageReady;
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            Bitmap bitmap = ImageProcessor.convertArrayToBitmap(image, width, height);
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
            var watch = Stopwatch.StartNew();
            int width = CameraManager.Instance.getImagingRows();
            int height = CameraManager.Instance.getImagingColumns();
            // Here we decide to use greyscale or heatmap
            Bitmap bitmap = ImageProcessor.convertArrayToBitmap(a.pixels, width, height);
            boxPicture3.Image = boxPicture2.Image;
            boxPicture2.Image = boxPicture.Image;
            boxPicture.Image = bitmap;
            updateXChart(a.pixels, width, height);
            updateYChart(a.pixels, width, height);
            Debug.WriteLine("OnImageReady() : image conversion time = " + watch.ElapsedMilliseconds + "ms");
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

        private void boxPicture_Click(object sender, EventArgs e)
        {

        }

        private void SingleImageForm_FormClosed(object sender, EventArgs e)
        {
            // unsubscribe from image events
            CameraManager.Instance.ImageReady -= this.OnImageReady;
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
    }
}
