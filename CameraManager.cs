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
    // github test
    class CameraManager
    {
        private static CameraManager instance;
        private ICamDiscover cameraFinder;
        private ICamera2 camera;

        public static readonly String STATUS_NOT_CONNECTED = "Not connected";
        public static readonly String STATUS_CONNECTED = "Connected";
        
        public static readonly int LED_A = 0;
        public static readonly int LED_B = 1;

        public static readonly int DIGITIZATION_NORMAL = 0;
        public static readonly int DIGITIZATION_FAST = 1;


        /// <summary>
        /// Private constructor to avoid creating copies of this class
        /// </summary>
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
        /// Getter of camera object
        /// </summary>
        /// <returns></returns>
        public ICamera2 getCamera()
        {
            return this.camera;
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
                System.Diagnostics.Debug.WriteLine("Showing camera selection dialog");
                cameraFinder.ShowDialog(true);
                if (cameraFinder.ValidSelection)
                {
                    // if user selected valid camera
                    System.Diagnostics.Debug.WriteLine("Succesfully selected camera");
                    System.Diagnostics.Debug.WriteLine("SelectedInterface: " + cameraFinder.SelectedInterface.ToString());
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

        /// <summary>
        /// Manually exposes camera for time and in LIGHT or DARK mode
        /// </summary>
        /// <param name="time"></param>
        /// <param name="light"></param>
        public void manualExpose(Double time, bool light)
        {
            System.Diagnostics.Debug.WriteLine("Exposing manually camera (time: " + time + ", light: " + light);
            camera.Expose(time, light);
        }

        /// <summary>
        /// Checks if camera has new Image to upload
        /// </summary>
        /// <returns></returns>
        public bool hasNewImage()
        {
            return camera.ImagingStatus == APOGEELib.Apn_Status.Apn_Status_ImageReady;
        }

        /// <summary>
        /// Returns camera imaging status
        /// </summary>
        /// <returns></returns>
        public Apn_Status getCameraImagingStatus()
        {
            return camera.ImagingStatus;
        }

        /// <summary>
        /// Returns camera imaging status string for UI.
        /// </summary>
        /// <returns></returns>
        public String getCameraImagingStatusString()
        {
            String result = "No camera connected";
            if (isCameraConnected()) {
                Apn_Status status = getCameraImagingStatus();
                switch (status)
                {
                    case Apn_Status.Apn_Status_ConnectionError:
                        result = "Connection error";
                        break;
                    case Apn_Status.Apn_Status_DataError:
                        result = "Data error";
                        break;
                    case Apn_Status.Apn_Status_Exposing:
                        result = "Exposing";
                        break;
                    case Apn_Status.Apn_Status_Flushing:
                        result = "Flushing";
                        break;
                    case Apn_Status.Apn_Status_Idle:
                        result = "Idle";
                        break;
                    case Apn_Status.Apn_Status_ImageReady:
                        result = "Image ready";
                        break;
                    case Apn_Status.Apn_Status_ImagingActive:
                        result = "Imaging active";
                        break;
                    case Apn_Status.Apn_Status_PatternError:
                        result = "Pattern error";
                        break;
                    case Apn_Status.Apn_Status_WaitingOnTrigger:
                        result = "Waiting for trigger";
                        break;
                }
            }
            return result;
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
        private unsafe ushort[] getImageToMemory(long width, long height)
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

        /// <summary>
        /// Returns camera model String fromc camera Discover.
        /// If no camera is selected, method returns "no model"
        /// </summary>
        /// <returns></returns>
        public String getCameraModelInfo()
        {
            String result = "";
            if (cameraFinder != null)
            {
                result = cameraFinder.SelectedModel;
                if (result == null || result == "")
                {
                    result = "No Model";
                }
            }
            return result;
        }

        /// <summary>
        /// Returns camera connection status string.
        /// </summary>
        /// <returns></returns>
        public String getCameraConnectionStatus()
        {
            String result = STATUS_NOT_CONNECTED;
            if (isCameraConnected())
            {
                result = STATUS_CONNECTED;
            }
            return result;
        }

        /// <summary>
        /// Returns camera connection status string.
        /// </summary>
        /// <returns></returns>
        public bool isCameraConnected()
        {
            bool result = false;
            if (cameraFinder != null && cameraFinder.ValidSelection)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Sets LED mode of camera
        /// </summary>
        /// <param name="ledMode"></param>
        public void setLedMode(Apn_LedMode ledMode)
        {
            if (camera != null && isCameraConnected())
            {
                camera.LedMode = ledMode;
            }
        }

        /// <summary>
        /// Sets given led to state. Id is selected from CameraManager.LED_A  or LED_B
        /// </summary>
        /// <param name="ledId"></param>
        /// <param name="state"></param>
        public void setLedState(int ledId, Apn_LedState state)
        {
            if (ledId == LED_A)
            {
                camera.LedA = state;
            }
            else camera.LedB = state;
        }

        /// <summary>
        /// Sets camera mode for one from Apn_CameraMode
        /// </summary>
        /// <param name="mode"></param>
        public void setCameraMode(Apn_CameraMode mode)
        {
            if (camera != null && isCameraConnected())
            {
                camera.CameraMode = mode;
            }
        }
        
        /// <summary>
        /// Sets camera trigger options.
        /// </summary>
        /// <param name="state">if trigger is enabled</param>
        /// <param name="group">if enabled, then select group/singel image</param>
        public void setCameraTrigger(bool state, bool group)
        {
            if (camera != null && isCameraConnected())
            {
                // if turned on
                if (state)
                {
                    if (group)
                    {
                        // sets trigger to start whole sequence
                        camera.TriggerNormalEach = true;
                        camera.TriggerNormalGroup = true;
                    }
                    else
                    {
                        // sets trigger to start each image
                        camera.TriggerNormalEach = true;
                        camera.TriggerNormalGroup = true;
                    }
                } 
                else
                {
                    camera.TriggerNormalEach = false;
                    camera.TriggerNormalGroup = false;
                }
            }
            System.Diagnostics.Debug.WriteLine("Camera trigger set to: " + camera.TriggerNormalEach + " , " + camera.TriggerNormalGroup);
        }

        /// <summary>
        /// Sets digitization speed CameraManager.DIGITIZATION_NORMAL or FAST
        /// </summary>
        /// <param name="value"></param>
        public void setDigitizationSpeed(int value)
        {
            if (camera != null && isCameraConnected())
            {
                if (value == DIGITIZATION_FAST || value == DIGITIZATION_NORMAL)
                camera.DigitizationSpeed = value;
            }
        }


        public Boolean setImageCount(int value)
        {
            Boolean result = false;
            if (camera != null && isCameraConnected())
            {
                // check if value is between 0 - 65535 
                if (value >= 0 && value < 65535)
                {
                    camera.ImageCount = value;
                    result = true;
                }
                else
                {
                    camera.ImageCount = 1;
                }
            }
            return result;
        }

        public int getImageCount()
        {
            int result = 1;
            if (camera != null && isCameraConnected())
            {
                result = camera.ImageCount;
            }
            return result;
        }

        public void stopExposure()
        {
            if (camera != null && isCameraConnected())
            {
                camera.StopExposure(true);
            }
        }

    }
        
}
