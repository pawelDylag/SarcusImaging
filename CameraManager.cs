using APOGEELib;
using System;
using System.Collections.Generic;
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
          

    }
}
