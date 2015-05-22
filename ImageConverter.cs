using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    static class ImageConverter
    {

        public static Bitmap generateBitmap(byte[] pixels, long width, long height)
        {
            Bitmap bitmap = new Bitmap((int)width, (int)height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
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

        public static Bitmap convertArrayToBitmap(ushort[] array, int width, int height, ushort offset)
        {
            byte[] pixels = convertShortToByteArray(array, width, height,offset);
            return generateBitmap(pixels, width, height);

        }

        /// <summary>
        /// Converts 16 bit Greyscale image to 48bit RGB for display.
        /// </summary>
        /// <param name="inBuffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] Convert16BitGrayScaleToRgb48(byte[] inBuffer, int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("Convert16BitGrayScaleToRgb48()" );
            System.Diagnostics.Debug.WriteLine("Convert16BitGrayScaleToRgb48() -> input array lenght: " + inBuffer.Length);
            int inBytesPerPixel = 2;
            int outBytesPerPixel = 6;

            byte[] outBuffer = new byte[width * height * outBytesPerPixel];
            System.Diagnostics.Debug.WriteLine("Convert16BitGrayScaleToRgb48() -> output array lenght: " + outBuffer.Length);
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

        /// <summary>
        ///  Converts LOSELESS short[x] array to byte[2x] array.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] convertShortToByte(ushort[] pixels, long width, long height)
        {
            System.Diagnostics.Debug.WriteLine("convertShortToByte()");
            byte[] result = new byte[width * height * 2];
            System.Diagnostics.Debug.WriteLine("convertShortToByte() -> Array lenght: " + result.Length);
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

                    ushort pixel = pixels[inStep];

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

        /// <summary>
        /// LOSSY conversion of short[] to byte[]. The offset of conversion is defined with offset parameter.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static byte[] convertShortToByteArray(ushort[] original, long width, long height, ushort offset)
        {
            // get max offset value
            Byte byteMaxValue = Byte.MaxValue;
            // calculate result array size
            int size = (int)height * (int)width;
            // create result array
            byte[] result = new byte[size];
            // Step through original array
            for (int y = 0; y < size; y++)
            {
                ushort value = (ushort)(original[y] - offset);
                if (value > byteMaxValue) {
                    result[y] = byteMaxValue;
                }
                else {
                    result[y] = (byte)value;
                }
               
            }
            return result;
        }

        public static void printUshortArrayMinMax(ushort[] array)
        {
            ushort resultMin = array[0];
            ushort resultMax = array[0];
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
            System.Diagnostics.Debug.WriteLine("Image pixel min value = " + resultMin);
            System.Diagnostics.Debug.WriteLine("Image pixel max value = " + resultMax);
        }

        public static ushort getUshortMinValue(ushort[] array)
        {
            ushort resultMin = array[0];
            for (int x = 1; x < array.Length; x++)
            {
                if (array[x] < resultMin)
                {
                    resultMin = array[x];
                }
            }
            System.Diagnostics.Debug.WriteLine("getUshortMinValue() =  " + resultMin);
            return resultMin;
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
            System.Diagnostics.Debug.WriteLine("Image pixel min value = " + resultMin);
            System.Diagnostics.Debug.WriteLine("Image pixel max value = " + resultMax);
        }

        public static byte[] generateRandomImage(int x, int y)
        {
            int width = x;
            int height = y;
            System.Diagnostics.Debug.WriteLine("Getting debug camera image...");
            System.Diagnostics.Debug.WriteLine("Image size = (" + width + "*" + height + ")");
            byte[] pixels = generateRandom16BitArray(width, height);
            return pixels;
        }
    }
}
