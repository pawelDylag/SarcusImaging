using APOGEELib;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                    instance =  new CameraManager();
                }
                return instance;

            }
        }

        /// <summary>
        /// Shows connect camera dialog and returns if camera was selected or not
        /// </summary>
        /// <returns></returns>
        public bool showCameraSelectionDialog() {
            bool result = false;
            if (cameraFinder != null)
            {
                cameraFinder.DlgCheckEthernet = true;
                cameraFinder.DlgCheckUsb = true;
                cameraFinder.DlgTitleBarText = "Select camera device";
                System.Diagnostics.Debug.WriteLine("Showing camera selection dialog");
                cameraFinder.ShowDialog(true);
                if (cameraFinder.ValidSelection)
                {
                    // if user selected valid camera
                    System.Diagnostics.Debug.WriteLine("Succesfully selected camera");
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
            System.Diagnostics.Debug.WriteLine( "Exposing manually camera (time: " + time + ", light: " + light);
            camera.Expose(time, light);
        }

        public bool hasNewImage()
        {
            return camera.ImagingStatus == APOGEELib.Apn_Status.Apn_Status_ImageReady;
        }

        /// <summary>
        /// Gets image from camera, and returns bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap getImage()
        {
            System.Diagnostics.Debug.WriteLine("Getting camera image...");
            int imgXSize = camera.ImagingColumns;
            int imgYSize = camera.ImagingRows;
            byte[] buffer = new byte[imgXSize * imgYSize];
            System.Diagnostics.Debug.WriteLine("Image size = (" + imgXSize + "*" + imgYSize + ")" );
            buffer = camera.Image;
            MemoryStream stream = new MemoryStream(buffer);
            Bitmap bitmap = new Bitmap(stream);
            return bitmap;
        }

    }
}
