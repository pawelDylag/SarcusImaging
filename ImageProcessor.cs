using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Drawing.Drawing2D;


namespace SarcusImaging
{
    /// <summary>
    /// Simple static class for image processing operations, conversions e.t.c
    /// </summary>
    static class ImageProcessor
    {
        public static List<Color> interpolationStepColors = new List<Color> { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.White };
        public static List<Color> colorPalette;

        /// <summary>
        /// Generates bitmap from 8bpp array
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap generateBitmap(byte[] pixels, long width, long height, PixelFormat pixelFormat)
        {
            Bitmap bitmap = new Bitmap((int)width, (int)height, pixelFormat);
            Rectangle dimension = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData picData = bitmap.LockBits(dimension, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pixelStartAddress = picData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, pixelStartAddress, pixels.Length);
            bitmap.UnlockBits(picData);
            return bitmap;
        }

        /// <summary>
        /// Generates heatmap bitmap from given array of camera ushort data.
        /// </summary>
        /// <param name="array">Pixels data from camera</param>
        /// <param name="width">Bitmap width</param>
        /// <param name="height">Bitmap height</param>
        /// <returns>Bitmapa</returns>
        public static Bitmap convertArrayToHeatmapBitmap(ushort[] array, int width, int height)
        {
            // get boundary values for pixels
            ushort[] minMax = getUshortMinMaxValues(array);
            // setup pixel data range
            ushort range = (ushort) (minMax[1] - minMax[0] + 1);
            // generate color palette
            List<Color> heatmapColors = ImageProcessor.interpolateColorScheme(ImageProcessor.interpolationStepColors, range);
            // create new RGB array
            byte[] pixels = new byte[width * height * 3];
            // Step through the image by row
            for (int y = 0; y < height; y++)
            {
                // Step through the image by column  
                for (int x = 0; x < width; x++)
                {
                    // compute index of input array
                    int inIndex = (y * width) + x;
                    // compute index of output array
                    int outIndex = (y * width * 3) + (x * 3);
                    // copy colors for each value 
                    ushort index = array[inIndex];
                    // substract min value from index value
                    index -= minMax[0];
                    // colors
                    Color color = heatmapColors[index];
                    // R
                    pixels[outIndex] = color.R;
                    // G
                    pixels[outIndex + 1] = color.G;
                    // B
                    pixels[outIndex + 2] = color.B;
                }
            }
            // return generated Bitmap in 24bpp RGB format
            return generateBitmap(pixels, width, height, PixelFormat.Format24bppRgb);
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

        /// <summary>
        /// Changes bitmap color palette to greyscale
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
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
        /// Interpolate given color scheme into gradient list
        /// </summary>
        /// <param name="colorScheme"> List with color scheme</param>
        /// <param name="size">Number of interpolated colors</param>
        /// <returns></returns>
        public static List<Color> interpolateColorScheme(List<Color> colorScheme, int size)
        {
            // create sorted dictionary for quick color peek. Populate it with data.
            SortedDictionary<float, Color> gradient = new SortedDictionary<float, Color>();
            for (int i = 0; i < colorScheme.Count; i++)
                gradient.Add(1f * i / (colorScheme.Count - 1), colorScheme[i]);
            // create result list with for interpolated colors
            List<Color> colorList = new List<Color>();
            // setup interpolation timer for development purposes
            ImagingTimer timer = new ImagingTimer();
            timer.start();
            // use Bitmap and Graphics from bitmap
            using (Bitmap bmp = new Bitmap(size, 1))
            using (Graphics G = Graphics.FromImage(bmp))
            {
                // cretae timer timestamp
                timer.timestamp("interpolateColors() : start ");
                // create empty rectangle canvas
                Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
                // use LinearGradientBrush class for gradient computation
                LinearGradientBrush brush = new LinearGradientBrush
                                        (rect, Color.Empty, Color.Empty, 0, false);
                // setup ColorBlend object
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = new float[gradient.Count];
                // enumarete through gradient step colors
                SortedDictionary<float, Color>.Enumerator enumerator = gradient.GetEnumerator();
                for (int i = 0; i < gradient.Count; i++) 
                {
                    enumerator.MoveNext();
                    colorBlend.Positions[i] = enumerator.Current.Key;
                }
                // blend colors and copy them to result color list
                List<Color> values = new List<Color>(gradient.Values);
                colorBlend.Colors = values.ToArray();
                brush.InterpolationColors = colorBlend;
                G.FillRectangle(brush, rect);
                for (int i = 0; i < size; i++) colorList.Add(bmp.GetPixel(i, 0));
                brush.Dispose();
                timer.timestamp("interpolateColors() : end");
            }
            timer.stop();
            Debug.WriteLine(timer.listTimes());
            // return interpolated colors
            return colorList;
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

        /// <summary>
        /// Debug func for printing array min and max
        /// </summary>
        /// <param name="array"></param>
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
        
        /// <summary>
        /// Debug function for generating random image
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static byte[] generateRandomImage(int x, int y)
        {
            int width = x;
            int height = y;
            Debug.WriteLine("Getting debug camera image...");
            Debug.WriteLine("Image size = (" + width + "*" + height + ")");
            byte[] pixels = generateRandom16BitArray(width, height);
            return pixels;
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


        /// <summary>
        /// Generates random ushort[] array. 
        /// Randomisation factor is different for each image type. 
        /// This provides different images for further post-process testing.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ushort[] generateRandomUshortArray(int width, int height, int type)
        {
            Random r = new Random();
            ushort[] pixels = new ushort[width * height];

            switch (type)
            {
                case 0:
                    for (int i = 0; i < pixels.Length; i++)
                    {

                        pixels[i] = (ushort)r.Next(ushort.MinValue, 10000); ;
                    }
                break;
                case 1:
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        pixels[i] = (ushort)r.Next(10000, 30000);
                    }
                break;
                case 2:
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (i + j > width + 100 || i+j < height - 100)
                            {
                                 pixels[i] = (ushort)r.Next(ushort.MinValue, 100);
                            }
                            else
                            {
                                pixels[width * i + j] = (ushort)r.Next(10000, 200000);
                            }
                        }
                    }

                break;
                case 3:
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (i > ((j - 10) + r.Next(0, 10)))
                            {
                                pixels[width  * i + j] = 30000;
                            }
                            else
                            {
                                pixels[i] = (ushort)r.Next(ushort.MinValue, 100); ; ;
                            }
                        }
                    }
                break;
            }

            return pixels;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double[] meanAndStandardDeviation(ushort[] dataset)
        {
            double[] result = new double[2];
            double mean = 0.0;
            double sum = 0.0;
            int k = 1;
            foreach (ushort v in dataset)
            {
                //double v = Convert.ToDouble(value);
                double previousMean = mean;
                mean += (v - previousMean) / k;
                sum += (v - previousMean) * (v - mean);
                k++;
            }
            // save mean 
            result[0] = mean;
            // save standard deviation
            result[1] = Math.Sqrt(sum / (k - 2));
            // Write debug info
            Debug.WriteLine("meanAndStandardDeviation() : mean = " + result[0] + ", standardDeviation = " + result[1]);
            // return mean and standard deviation
            return result;
        }
    }
}
