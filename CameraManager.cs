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
        public Bitmap getSingleImage()
        {
            System.Diagnostics.Debug.WriteLine("Getting camera image...");
            long imgXSize = camera.ImagingColumns;
            long imgYSize = camera.ImagingRows;
            System.Diagnostics.Debug.WriteLine("Image size = (" + imgXSize + "*" + imgYSize + ")");
            // get raw data array from camera
            ushort[] pixels = getImageToMemory(imgXSize, imgYSize);
            System.Diagnostics.Debug.WriteLine("Image array lenght: " + pixels.Length);
            byte[] pixelsByte = convertShortToByte(pixels, imgXSize, imgYSize);
            Bitmap bitmap = generateBitmap(pixelsByte, imgXSize, imgYSize);
            return bitmap;
        }

        public Bitmap getDebugImage(int x, int y)
        {
            int width = x;
            int height = y;
            System.Diagnostics.Debug.WriteLine("Getting debug camera image...");
            System.Diagnostics.Debug.WriteLine("Image size = (" + width + "*" + height + ")");
            byte[] pixels = generateRandom16BitArray(width, height);
            byte[] pixelsForDisplay = Convert16BitGrayScaleToRgb48(pixels, width, height);
            return generateBitmap(pixelsForDisplay, width, height);
        }

        private Bitmap generateBitmap(byte[] pixels, long width, long height)
        {
            Bitmap bitmap = new Bitmap((int)width, (int)height, System.Drawing.Imaging.PixelFormat.Format48bppRgb);
            Rectangle dimension = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData picData = bitmap.LockBits(dimension, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pixelStartAddress = picData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, pixelStartAddress, pixels.Length);
            bitmap.UnlockBits(picData);
            return bitmap;
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
        /// Generates random byte[] array.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public byte[] generateRandom16BitArray(int width, int height)
        {
            Random r = new Random();
            byte[] pixels = new byte[width * height * 2];
            for (int i = 0; i < pixels.Length; ++i)
            {
                byte value = (byte)r.Next(0, 256);
                pixels[i] = value;
            }
            return pixels; 
        }

        /// <summary>
        /// Converts 16 bit Greyscale image to 48bit RGB for display.
        /// </summary>
        /// <param name="inBuffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static byte[] Convert16BitGrayScaleToRgb48(byte[] inBuffer, int width, int height)
        {
            int inBytesPerPixel = 2;
            int outBytesPerPixel = 6;

            byte[] outBuffer = new byte[width * height * outBytesPerPixel];
            int inStep = width * inBytesPerPixel;
            int outStep = width * outBytesPerPixel;

            // Step through the image by row  
            for (int y = 0; y < height; y++)
            {
                // Step through the image by column  
                for (int x = 0; x < width; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int inIndex = (y * inStep) + (x * inBytesPerPixel);
                    int outIndex = (y * outStep) + (x * outBytesPerPixel);

                    byte hibyte = inBuffer[inIndex + 1];
                    byte lobyte = inBuffer[inIndex];

                    //R
                    outBuffer[outIndex] = lobyte;
                    outBuffer[outIndex + 1] = hibyte;

                    //G
                    outBuffer[outIndex + 2] = lobyte;
                    outBuffer[outIndex + 3] = hibyte;

                    //B
                    outBuffer[outIndex + 4] = lobyte;
                    outBuffer[outIndex + 5] = hibyte;
                }
            }
            return outBuffer;
        }

        private static byte[] convertShortToByte(ushort[] pixels, long width, long height)
        {
            byte[] result = new byte[width * height * 2];
            return result;
        }

    }
        
}
