using APOGEELib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    //
    // Camera manager class
    //
    class CameraManager
    {
        private static CameraManager instance;
        private ICamDiscover cameraFinder;
        private ICamera2 camera;

        private CameraManager()
        {
            cameraFinder = new CamDiscover();
            camera = new Camera2();
        }

        //
        // Singleton pattern instance init
        //
        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraManager();
                }
                return instance;

            }
        }

        /// <summary>
        /// Shows connect camera dialog and returns if camera was selected or not
        /// </summary>
        /// <returns></returns>
        public bool showCameraSelectionDialog()
        {
            bool result = false;
            if (cameraFinder != null)
            {
                cameraFinder.DlgCheckUsb = true;
                cameraFinder.DlgTitleBarText = "Select camera device";
                System.Diagnostics.Debug.WriteLine("Showing camera selection dialog");
                cameraFinder.ShowDialog(true);
                if (cameraFinder.ValidSelection)
                {
                    // if user selected valid camera
                    System.Diagnostics.Debug.WriteLine("Succesfully selected camera");
                    System.Diagnostics.Debug.WriteLine("SelectedInterface: " + cameraFinder.SelectedInterface.ToString());
                    System.Diagnostics.Debug.WriteLine("SelectedCamIdOne: " + cameraFinder.SelectedCamIdOne.ToString());
                    System.Diagnostics.Debug.WriteLine("SelectedCamIdTwo: " + cameraFinder.SelectedCamIdTwo.ToString());
                    camera.Init(cameraFinder.SelectedInterface, cameraFinder.SelectedCamIdOne, cameraFinder.SelectedCamIdTwo, 0);
                    System.Diagnostics.Debug.WriteLine(camera.ToString());
                    result = true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Camera not selected");
                }
            }
            return result;
        }

        public void createDummyCamera()
        {
            // TO DO
        }

        public void manualExpose(Double time, bool light)
        {
            System.Diagnostics.Debug.WriteLine("Exposing manually camera (time: " + time + ", light: " + light);
            camera.Expose(time, true);
        }

        public bool hasNewImage()
        {
            return camera.ImagingStatus == APOGEELib.Apn_Status.Apn_Status_ImageReady;
        }

        /// <summary>
        /// Gets image from camera, and returns bitmap
        /// </summary>
        /// <returns></returns>
        public ushort[] getSingleImage()
        {
            System.Diagnostics.Debug.WriteLine("GetSingleImage()");
            long imgXSize = camera.ImagingColumns;
            long imgYSize = camera.ImagingRows;
            System.Diagnostics.Debug.WriteLine("Image size = (" + imgXSize + "*" + imgYSize + ")");
            // get raw data array from camera
            ushort[] image = getImageToMemory(imgXSize, imgYSize);
            System.Diagnostics.Debug.WriteLine("Image array lenght: " + image.Length);
            return image;
        }

        /// <summary>
        /// Gets image from camera by passing ptr to allocated memory.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public unsafe ushort[] getImageToMemory(long width, long height)
        {
            // Allocating array of image size (width * height)
            // where pixel is size of unsigned int (4 BYTES)
            // possible values: 0 to 4,294,967,295 
            ushort[] pixels = new ushort[ width * height ];

            // Gets pointer to allocated array and fixes it, 
            // so that it won't be moved by Garbage Collector
            fixed (ushort* ptr = pixels)
            {
                // 32-bit platform -> int
                int ptrValue = (int)ptr;
                camera.GetImage(ptrValue);
                // 64-bit platform -> long
                // long ptrValue = (long)ptr;
                // camera.GetImage(ptrValue);
            }

            return pixels;
        }

        /// <summary>
        /// Returns number of pixels in a row
        /// </summary>
        /// <returns></returns>
        public int getImagingRows()
        {
            return (int)camera.ImagingRows;
        }

        /// <summary>
        /// Returns numer of pixels in a column
        /// </summary>
        /// <returns></returns>
        public int getImagingColumns()
        {
            return (int)camera.ImagingColumns ;
        }





    

    }
        
}
