using APOGEELib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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

        public static readonly String STATUS_NOT_CONNECTED = "Not connected";
        public static readonly String STATUS_CONNECTED = "Connected";

        public static readonly int LED_A = 0;
        public static readonly int LED_B = 1;

        public static readonly int DIGITIZATION_NORMAL = 0;
        public static readonly int DIGITIZATION_FAST = 1;

        public delegate void ImageReadyEventHandler(object source, ImageReadyArgs args);
        public event ImageReadyEventHandler ImageReady;

        public delegate void SequenceEndedEventHandler(object source, EventArgs args);
        public event SequenceEndedEventHandler SequenceEnded;

        public delegate void IterationEndedEventHandler(object source, EventArgs args);
        public event IterationEndedEventHandler IterationEnded;

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
        public void startExposure(Double time, bool light)
        {
            System.Diagnostics.Debug.WriteLine("Exposing manually camera (time: " + time + ", light: " + light);
            camera.Expose(time, light);
        }

        /// <summary>
        /// Stops exposure if possible
        /// </summary>
        public void stopExposure()
        {
            if (camera != null && isCameraConnected())
            {
                camera.StopExposure(false);
            }
        }

        /// <summary>
        /// Checks if camera has new Image to upload
        /// </summary>
        /// <returns></returns>
        public bool hasNewImage()
        {
            return camera.ImagingStatus == Apn_Status.Apn_Status_ImageReady;
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
            if (isCameraConnected())
            {
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
            Debug.WriteLine("GetSingleImage()");
            long imgXSize = camera.ImagingColumns;
            long imgYSize = camera.ImagingRows;
            Debug.WriteLine("Image size = (" + imgXSize + "*" + imgYSize + ")");
            // get raw data array from camera
            ushort[] image = getImageToMemory(imgXSize, imgYSize);
            //System.Diagnostics.Debug.WriteLine("Image array lenght: " + image.Length);
            return image;
        }

        /// <summary>
        /// Executes step by step given SequencePlan
        /// </summary>
        /// <param name="plan"></param>
        public void executeSequencePlan(SequencePlan plan)
        {

            Debug.WriteLine("=============================");
            Debug.WriteLine("executeSequencePlan() : start" + Environment.NewLine);
            long imgXSize = camera.ImagingColumns;
            long imgYSize = camera.ImagingRows;
            if (camera != null && isCameraConnected())
            {
                // loop all iterations
                for (int k = 0; k < plan.iterations; k++)
                {
                    // loop all sequence items
                    for (int j = 0; j < plan.size(); j++)
                    {
                        Debug.WriteLine("executeSequencePlan() : ITERATION " + k + " STEP " + (j + 1) + "/" + plan.size());
                        // get next step from SequencePlan
                        SequenceItem sequenceItem = plan.getItem(j);
                        // set camera image count
                        camera.ImageCount = sequenceItem.imageCount;
                        // set camera trigger
                        setCameraTrigger(sequenceItem.triggerType);
                        // camera turn off bulk sequence
                        camera.SequenceBulkDownload = false;
                        // check if image is bias
                        Boolean bias = (sequenceItem.type != (int)SequenceItem.types.TYPE_BIAS) ? true : false;
                        // setup time counter for item
                        ImagingTimer timer = new ImagingTimer();
                        timer.start();
                        // get raw data array from camera
                        camera.Expose(sequenceItem.exposureTime, bias);
                        timer.timestamp("Exposure");
                        // loop all images in item
                        for (int i = 1; i <= sequenceItem.imageCount; i++)
                        {
                            // while new image isn't ready
                            while (camera.SequenceCounter != i)
                            {
                                // waiting for new image
                            }
                            // if new image is ready
                            timer.timestamp("Got image " + i + "/" + sequenceItem.imageCount);
                            OnImageReady(getImageToMemory(imgXSize, imgYSize), sequenceItem.type);
                            timer.timestamp("OnImageReady() for image " + i + "/" + sequenceItem.imageCount);
                        }
                        timer.timestamp("Sequence end");
                        timer.stop();
                        Debug.WriteLine(timer.listTimes());
                    }

                }
                Debug.WriteLine("executeSequencePlan() : stop");
                Debug.WriteLine("=============================");
                // notify about sequence end
                OnSequenceEnd();
                // reset camera to default 
                camera.ImageCount = 1;
                camera.SequenceBulkDownload = true;
            }
            else
            {
                Debug.WriteLine("executeSequencePlan() : Error starting sequence. No camera object or camera is not connected.");
                Debug.WriteLine("=============================");
            }
        }

        /// <summary>
        /// This is simply debug method for testing camera imaging speed
        /// Only used in debug mode, not in final app
        /// </summary>
        public void measureImagingTimes()
        {
            Debug.WriteLine("=============================");
            Debug.WriteLine("measureImagingTimes() : start" + Environment.NewLine);
            Debug.WriteLine("measureImagingTimes() : ADs number = " + camera.NumAds);
            Debug.WriteLine("measureImagingTimes() : ADs channels = " + camera.NumAdChannels);
            Debug.WriteLine("measureImagingTimes() : Shutter close delay = " + camera.ShutterCloseDelay);
            long imgXSize = camera.ImagingColumns;
            long imgYSize = camera.ImagingRows;
            if (camera != null && isCameraConnected())
            {
                // SETUP VARIABLES
                int imageCount = 2;
                double exposeTime = 1;
                camera.ImageCount = imageCount;
                // set camera trigger
                setCameraTrigger((int) SequenceItem.triggerTypes.TRIGGER_NONE);
                // camera turn off bulk sequence
                camera.SequenceBulkDownload = false;
                // turn off bias image option
                Boolean bias = true;
                // === TEST STRAEM MODE WITH GETTING IMAGE TO MEMORY ===
                Debug.WriteLine(Environment.NewLine);
                Debug.WriteLine("measureImagingTimes() : MEASURING STREAM MODE WITH THREADS");
                Debug.WriteLine("measureImagingTimes() : Image count = " + imageCount);
                Debug.WriteLine("measureImagingTimes() : Sequence delay = " + camera.SequenceDelay + " VariableSequenceDelay = " + camera.VariableSequenceDelay);
       
                // setup time counter for item
                ImagingTimer timer = new ImagingTimer();
                // start new timer
                timer.start();
                // get raw data array from 
                camera.Expose(exposeTime, bias);
                timer.timestamp("camera.Expose(" + exposeTime * 1000 + "ms)");
                // loop all images in item
                for (int i = 1; i <= imageCount; i++)
                {
                    while (camera.SequenceCounter != i)
                    {
                        // waiting for new image
                    }
                  
                    // if new image is ready
                    timer.timestamp("New image ready " + i + "/" + imageCount);
                    OnImageReady(getImageToMemory(imgXSize, imgYSize), 0);

                    timer.timestamp("Got image in memory " + i + "/" + imageCount);
                    //timer.timestamp("Got image " + i + "/" + imageCount + " to memory");
                }
                timer.timestamp("Got all images");
                timer.stop();
                // write results
                Debug.WriteLine(timer.listTimes());
                // clear camera
                camera.StopExposure(false);

                // === TEST BULK MODE ===
                Debug.WriteLine(Environment.NewLine);
                Debug.WriteLine("measureImagingTimes() : MEASURING BULK MODE");
                Debug.WriteLine("measureImagingTimes() : Image count = " + imageCount);
                // camera turn on bulk sequence
                camera.SequenceBulkDownload = true;
                // reset timer
                timer.reset();
                // start new timer
                timer.start();

                camera.Expose(exposeTime, bias);
                timer.timestamp("camera.Expose(" + exposeTime * 1000 + "ms)");
                // wait for new image 

                    while (!hasNewImage())
                    {
                        // waiting for new image
                    }
                // if new image is ready
                timer.timestamp("Bulk images are ready");
                //OnImageReady(getImageToMemory(imgXSize, imgYSize));
                ushort[] pixels = getBulkImageToMemory(imgXSize, imgYSize, imageCount);

                timer.timestamp("Got bulk images to memory");
                // stop timer
                timer.stop();
                // write results
                Debug.WriteLine(timer.listTimes());
                // clear camera
                camera.StopExposure(false);

                // notify about sequence end
                OnSequenceEnd();
                // reset camera to default 
                camera.ImageCount = 1;
                camera.SequenceBulkDownload = true;
                Debug.WriteLine("measureImagingTimes() : Image count = " + imageCount);
                Debug.WriteLine("measureImagingTimes() : Sequence counter = " + camera.SequenceCounter);
                Debug.WriteLine("measureImagingTimes() : Camera status = " + camera.ImagingStatus);

                Debug.WriteLine(Environment.NewLine);
                Debug.WriteLine("measureImagingTimes() : stop" );
                Debug.WriteLine("=============================");
            }
            else
            {
                Debug.WriteLine("measureImagingTimes() : Error starting sequence. No camera object or camera is not connected.");
                Debug.WriteLine("=============================");
            }

        }

        /// <summary>
        /// Event handling method witch gets pixels array, and postprocess it.
        /// </summary>
        /// <param name="pixels"></param>
        protected virtual void OnImageReady(ushort[] pixels, int imageType)
        {
            if (ImageReady != null)
            {
                ImageReady(this, new ImageReadyArgs(pixels, imageType));
            }
        }

        /// <summary>
        /// Event handling method witch gets pixels array, and postprocess it.
        /// </summary>
        /// <param name="pixels"></param>
        protected virtual void OnSequenceEnd()
        {
            if (SequenceEnded != null)
            {
                SequenceEnded(this, new EventArgs());
            }
        }

        /// <summary>
        /// Event handling method witch gets pixels array, and postprocess it.
        /// </summary>
        /// <param name="pixels"></param>
        protected virtual void OnIterationEnded()
        {
            if (IterationEnded != null)
            {
                IterationEnded(this, new EventArgs());
            }
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
            ushort[] pixels = new ushort[width * height];

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
        /// Gets bulk image from camera by passing ptr to allocated memory.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private unsafe ushort[] getBulkImageToMemory(long width, long height, int imageCount)
        {
            // Allocating array of image size (width * height)
            // where pixel is size of unsigned int (4 BYTES)
            // possible values: 0 to 4,294,967,295 
            ushort[] pixels = new ushort[width * height * imageCount];

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
            return (int)camera.ImagingColumns;
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
        /// <param name="each">if trigger is enabled</param>
        /// <param name="group">if enabled, then select group/singel image</param>
        public void setCameraTrigger(bool each, bool group)
        {
            if (camera != null && isCameraConnected())
            {
                // if turned on
                if (each)
                {
                    if (group)
                    {
                        // sets trigger to start whole sequence
                        camera.TriggerNormalEach = true;
                        camera.TriggerNormalGroup = false;
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
                    if (group)
                    {
                        // sets trigger to start whole sequence
                        camera.TriggerNormalEach = false;
                        camera.TriggerNormalGroup = true;
                    }
                    else
                    {
                        // sets trigger off
                        camera.TriggerNormalEach = false;
                        camera.TriggerNormalGroup = false;
                    }
                }
            }
            Debug.WriteLine("Camera trigger set to: " + camera.TriggerNormalEach + " , " + camera.TriggerNormalGroup);
        }

        /// <summary>
        /// Sets camera trigger dependent on trigger type from SequenceItem
        /// </summary>
        /// <param name="triggerType"></param>
        public void setCameraTrigger(int triggerType)
        {
            switch (triggerType)
            {
                case (int)SequenceItem.triggerTypes.TRIGGER_NONE:
                    setCameraTrigger(false, false);
                    break;
                case (int)SequenceItem.triggerTypes.TRIGGER_EACH:
                    setCameraTrigger(true, true);
                    break;
                case (int)SequenceItem.triggerTypes.TRIGGER_WHOLE:
                    setCameraTrigger(false, true);
                    break;
                case (int)SequenceItem.triggerTypes.TRIGGER_ALL_WITHOUT_FIRST:
                    setCameraTrigger(true, false);
                    break;
            }
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

        /// <summary>
        /// Returns current image count value
        /// </summary>
        /// <returns></returns>
        public int getImageCount()
        {
            int result = 1;
            if (camera != null && isCameraConnected())
            {
                result = camera.ImageCount;
            }
            return result;


        }

    }       
}
