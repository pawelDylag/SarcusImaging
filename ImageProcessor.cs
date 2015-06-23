using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;


namespace SarcusImaging
{
    /// <summary>
    /// Simple static class for image processing operations, conversions e.t.c
    /// </summary>
    static class ImageProcessor
    {

        /// <summary>
        /// Generates bitmap from 8bpp array
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap generateBitmap(byte[] pixels, long width, long height)
        {
            Bitmap bitmap = new Bitmap((int)width, (int)height, PixelFormat.Format32bppRgb);
            //byte[] image = Convert16BitGrayScaleToRgb32(pixels, (int)width, (int)height);
            changeBitmapToGreyscale(bitmap);
            Rectangle dimension = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData picData = bitmap.LockBits(dimension, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pixelStartAddress = picData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, pixelStartAddress, pixels.Length);
            bitmap.UnlockBits(picData);
            return bitmap;
        }

        /// <summary>
        /// Generates random byte[] array.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] generateRandom16BitArray(int width, int height)
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

        public static Bitmap convertArrayToBitmap(ushort[] array, int width, int height)
        {
            byte[] pixels = convertShortToByteArray(array, width, height);
            return generateBitmap(pixels, width, height);

        }

        /// <summary>
        /// Converts 16 bit Greyscale image to 48bit RGB for display.
        /// </summary>
        /// <param name="inBuffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] ConvertArrayToRgb24Heatmap(ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("ConvertArrayToRgb24Heatmap()");
            Debug.WriteLine("ConvertArrayToRgb24Heatmap() : input array length: " + pixels.Length);
            byte[] outBuffer = new byte[width * height * 3];
            ushort[] minMax = getUshortMinMaxValues(pixels);
            // Setup conversion constants
            double range = minMax[1] - minMax[0];
            double mid = (minMax[1] + minMax[1]) / 2.0;
            Debug.WriteLine("ConvertArrayToRgb24Heatmap() : input array MIN =  " + minMax[0] + ", MAX = " + minMax[1] + ", RANGE = " + range + ", MID = " + mid);
            Debug.WriteLine("ConvertArrayToRgb24Heatmap() : output array length: " + outBuffer.Length);
            // Step through the image by row  
            for (int y = 0; y < height; y++)
            {
                // Step through the image by column  
                for (int x = 0; x < width; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int inIndex = (y * width) + x;
                    int outIndex = (y * width * 3) + (x * 3);
                    
                    
                    // color value conversion here

                    //R
                    outBuffer[outIndex] = 0;

                    //G
                    outBuffer[outIndex + 1] = 0;

                    //B
                    outBuffer[outIndex + 2] = 0;

                }
            }
            return outBuffer;
        }


        /// <summary>
        ///  Converts LOSELESS short[x] array to byte[2x] array.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] convertShortToByte(ushort[] pixels, long width, long height)
        {
            Debug.WriteLine("convertShortToByte()");
            byte[] result = new byte[width * height * 2];
            Debug.WriteLine("convertShortToByte() -> Array lenght: " + result.Length);
            int inBytesPerPixel = 2;
            int outBytesPerPixel = 1;

            int inStep = (int)width * inBytesPerPixel;
            int outStep = (int)width * outBytesPerPixel;

            // Step through the image by row  
            for (int y = 0; y < height; y++)
            {
                // Step through the image by column  
                for (int x = 0; x < width; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int inIndex = (y * inStep) + (x * inBytesPerPixel);
                    int outIndex = (y * outStep) + (x * outBytesPerPixel);

                    ushort pixel = pixels[inIndex];

                    byte lobyte = (byte)pixel;
                    byte hibyte = (byte)(pixel >> 8);
                        
                    result[outIndex] = hibyte;
                    result[outIndex + 1] = lobyte;
                }
            }
            return result;
        }

        public static void changeBitmapToGreyscale(Bitmap bitmap)
        {
            ColorPalette palette = bitmap.Palette;
            Color[] colors = palette.Entries;
            for(int i = 0; i<256; i++){
                Color grayShade = new Color();
                grayShade = Color.FromArgb((byte)i, (byte)i, (byte)i);
                colors[i] = grayShade;
            }
            bitmap.Palette = palette;
        }

        public static void changeBitmapToHeatmap(Bitmap bitmap)
        {
            ColorPalette palette = bitmap.Palette;
            Color[] colors = palette.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color grayShade = new Color();
                grayShade = Color.FromArgb((byte)i, (byte)i, (byte)i);
                colors[i] = grayShade;
            }
            bitmap.Palette = palette;
        }

        /// <summary>
        /// LOSSY conversion of short[] to byte[]. The offset of conversion is defined with offset parameter.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] convertShortToByteArray(ushort[] original, long width, long height)
        {
            Debug.WriteLine("convertShortToByteArray()");
            // calculate result array size
            int size = (int)height * (int)width;
            // create scale and offset func
            ushort[] minMax = getUshortMinMaxValues(original);
            float maxByteSize = (float)Byte.MaxValue;
            // CO JESLI MIN = MAX ??
            float scale = maxByteSize / (minMax[1] - minMax[0]);
            Debug.WriteLine("convertShortToByteArray() : min = " + minMax[0] + ", max = " + minMax[1] + ", scale = " + scale);
            // create result array
            byte[] result = new byte[size];
            // Step through original array
            for (int i = 0; i < size; i++)
            {
                float value = (original[i] - minMax[0]) * scale;
                result[i] = (byte)value;       
            }
            return result;
        }

        /// <summary>
        /// Returns array with average pixel datas from X Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ushort[] getImageXAveragePixelValue (ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageXAveragePixelValue()");
            ushort[] result = new ushort[width];
          
            // Step through the image by colum  
            for (int y = 0; y < width; y++)
            {
                // Step through the image by width
                ulong average = 0;  
                for (int x = 0; x < height; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int index = y + (width * x);
                    average += pixels[index];
                }
                // calculate average value of colum
                result[y] = (ushort) (average / (uint) width);
            }
            return result;
        }

        /// <summary>
        /// Returns array with average pixel data from Y Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ushort[] getImageYAveragePixelValue(ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageYAveragePixelValue()");
            ushort[] result = new ushort[width];

            // Step through the image by colum  
            for (int y = 0; y < height; y++)
            {
                // Step through the image by width
                ulong average = 0;
                for (int x = 0; x < width; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int index = x + (width * y);
                    average += pixels[index];
                }
                // calculate average value of colum
                result[height - y - 1] = (ushort)(average / (uint)width);
            }
            return result;
        }


        /// <summary>
        /// Returns array with two values MIN and MAX
        /// minMax[0] = minimum, minMax[1] = maximum
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static ushort[] getUshortMinMaxValues(ushort[] array)
        {
            ushort[] minMax = new ushort[2];

            minMax[0] = array[0];
            minMax[0] = array[0];
            for (int x = 1; x < array.Length; x++)
            {
                if (array[x] > minMax[1])
                {
                    minMax[1] = array[x];
                }
                if (array[x] < minMax[0])
                {
                    minMax[0] = array[x];
                }
            }
            return minMax;
        }

        public static void printByteArrayMinMax(byte[] array)
        {
            byte resultMin = array[0];
            byte resultMax = array[0];
            for (int x = 1; x < array.Length; x++)
            {
                if (array[x] > resultMax)
                {
                    resultMax = array[x];
                }
                if (array[x] < resultMin)
                {
                    resultMin = array[x];
                }
            }
            Debug.WriteLine("Image pixel min value = " + resultMin);
            Debug.WriteLine("Image pixel max value = " + resultMax);
        }

        public static byte[] generateRandomImage(int x, int y)
        {
            int width = x;
            int height = y;
            Debug.WriteLine("Getting debug camera image...");
            Debug.WriteLine("Image size = (" + width + "*" + height + ")");
            byte[] pixels = generateRandom16BitArray(width, height);
            return pixels;
        }
    }
}
