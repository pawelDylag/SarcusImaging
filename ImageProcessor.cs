using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;



namespace SarcusImaging
{
    /// <summary>
    /// Simple static class for image processing operations, conversions e.t.c
    /// </summary>
    static class ImageProcessor
    {
        // main heatmap color palette
        private static readonly Color[] HEATMAP_COLOR_PALETTE = new Color[7] {Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.White};
        
        // main heatmap color positions
        private static readonly float[] HEATMAP_COLOR_POSITIONS = new float[7] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
      
        // main heatmap height
        private static readonly int HEATMAP_GRADIENT_HEIGHT = 5;

        // main heatmap object. It is used to compute image pixel values from 0-65535 greyscale range into colorful heatmap.
        public static Bitmap heatmapGradient;

        /// <summary>
        /// Generates bitmap from 8bpp array
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap generateBitmap(byte[] pixels, int width, int height, PixelFormat pixelFormat)
        {
            Bitmap bitmap = new Bitmap(width, height, pixelFormat);
            Rectangle dimension = new Rectangle(Point.Empty, bitmap.Size);
            BitmapData picData = bitmap.LockBits(dimension, ImageLockMode.WriteOnly, pixelFormat);
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
            Bitmap heatmapColors = getResizedHeatmapGradient(range);
            Debug.WriteLine("convertArrayToHeatmapBitmap() : range = " + range + ", min = " + minMax[0] + ", max = " + minMax[1]);
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
                    Color color = heatmapColors.GetPixel(index, HEATMAP_GRADIENT_HEIGHT - 1 );
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
        /// Changes bitmap color palette to greyscale
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        public static void changeBitmapPaletteToGreyscale(Bitmap bitmap)
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
        /// Method for initial heatmap generation
        /// </summary>
        /// <returns></returns>
        public static Bitmap generateHeatmapGradient()
        {
            // use Bitmap and Graphics from bitmap
            Bitmap bmp = new Bitmap(ushort.MaxValue, HEATMAP_GRADIENT_HEIGHT);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                // create empty rectangle canvas
                Rectangle rect = new Rectangle(Point.Empty, bmp.Size);
                // use LinearGradientBrush class for gradient computation
                LinearGradientBrush brush = new LinearGradientBrush
                                        (rect, Color.Empty, Color.Empty, 0, false);
                // setup ColorBlend object
                ColorBlend colorBlend = new ColorBlend();
                // setup gradient colors
                colorBlend.Colors = HEATMAP_COLOR_PALETTE;
                // setup color positions
                colorBlend.Positions = HEATMAP_COLOR_POSITIONS;
                // blend colors and copy them to result color list
                brush.InterpolationColors = colorBlend;
                G.FillRectangle(brush, rect);
                // release brush object 
                brush.Dispose();
            }
            return bmp;
        }

        /// <summary>
        /// Generate main heatmap object and save it in memory. 
        /// </summary>
        public static void initHeatmapGradient()
        {
            Bitmap gradient = generateHeatmapGradient();
            heatmapGradient = gradient;
            Debug.WriteLine("initHeatmapGradient() : bitmap size = " + heatmapGradient.Size + " , format =" + heatmapGradient.PixelFormat);
        }

        /// <summary>
        /// Returns resized heatmap for given size. 
        /// </summary>
        /// <param name="newWidth"></param>
        /// <returns></returns>
        public static Bitmap getResizedHeatmapGradient(ushort size)
        {
            ushort scaledWidth = (ushort) (size + Math.Ceiling(size / 512.0));
            heatmapGradient.Save("beforeResizedHeatmap.png");
            Bitmap result = new Bitmap(heatmapGradient, new Size(scaledWidth, HEATMAP_GRADIENT_HEIGHT));
            result.Save("afterResizedHeatmap.png");
            return result;
        }


        /// <summary>
        /// LOSSY conversion from ushort[] to greyscale bitmap. 
        /// </summary>
        /// <param name="original">Pixels array</param>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <returns></returns>
        public static Bitmap convertArrayToGreyscaleBitmap(ushort[] original, long width, long height)
        {
            // calculate result array size
            int size = (int)height * (int)width;
            // create scale and offset func
            ushort[] minMax = getUshortMinMaxValues(original);
            float maxByteSize = (float)Byte.MaxValue;
            // setup scale variable and check dividing by 0 condition.
            float scale;
            if (minMax[0] == minMax[1])
                scale = maxByteSize;
            else 
                scale = maxByteSize / (minMax[1] - minMax[0]);
            Debug.WriteLine("convertShortToByteArray() : min = " + minMax[0] + ", max = " + minMax[1] + ", scale = " + scale);
            // create result array
            byte[] result = new byte[size];
            // Step through original array
            for (int i = 0; i < size; i++)
            {
                float value = (original[i] - minMax[0]) * scale;
                result[i] = (byte)value;       
            }
            Bitmap bitmap = generateBitmap(result, (int)width, (int)height, PixelFormat.Format8bppIndexed);
            changeBitmapPaletteToGreyscale(bitmap);
            return bitmap;
        }

        /// <summary>
        /// Returns array with average pixel datas from Y Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ushort[] getImageYAveragePixelValue (ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageXAveragePixelValue()");
            ushort[] result = new ushort[width];
          
            // Step through the image by row  
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
                result[y] = (ushort) (average / (uint) width);
            }
            return result;
        }

        /// <summary>
        /// Returns array with average pixel data from X Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ushort[] getImageXAveragePixelValue(ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageYAveragePixelValue()");
            ushort[] result = new ushort[width];

            // Step through the image by colum  
            for (int x = 0; x < width; x++)
            {
                // Step through the image by width
                ulong average = 0;
                for (int y = 0; y < height; y++)
                {
                    // Get inbuffer index and outbuffer index 
                    int index = x + (width * y);
                    average += pixels[index];
                }
                // calculate average value of colum
                result[x] = (ushort)(average / (uint)width);
            }
            return result;
        }

        /// <summary>
        /// Returns array with sum of pixel data from Y Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static double[] getImageSumY(ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageYAveragePixelValue()");
            double[] result = new double[width];

            // Step through the image by row  
            for (int x = 0; x < width; x++)
            {
                // Step through the image by width
                double sum = 0;
                for (int y = 0; y < height; y++)
                {
                    // Get inbuffer index and outbuffer index 
                    int index = x + (width * y);
                    sum += pixels[index];
                }
                // calculate average value of colum
                result[x] = sum;
            }
            return result;
        }


        /// <summary>
        /// Returns array with sum of pixel data from Y Axis
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static double[] getImageSumOfX(ushort[] pixels, int width, int height)
        {
            Debug.WriteLine("getImageYAveragePixelValue()");
            double[] result = new double[width];

            // Step through the image by colum  
            for (int y = 0; y < height; y++)
            {
                // Step through the image by width
                double sum = 0;
                for (int x = 0; x < width; x++)
                {
                    // Get inbuffer index and outbuffer index 
                    int index = x + (width * y);
                    sum += pixels[index];
                }
                // calculate average value of colum
                result[y] = sum;
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
                                pixels[i] = (ushort)r.Next(ushort.MinValue, 100);
                            }
                        }
                    }
                break;
                case 4:
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        pixels[width * i + j] = (ushort)(i + j +r.Next(0, 10));

                    }
                }
                break;
            }

            return pixels;
        }


        /// <summary>
        /// Returns mean and standard deviation of given dataset.
        /// Calculated using Welford's algorithm 
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

        /// <summary>
        /// Returns mean and standard deviation of given dataset.
        /// Calculated using Welford's algorithm 
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double[] meanAndStandardDeviationForDoubles(double[] dataset)
        {
            double[] result = new double[2];
            double mean = 0.0;
            double sum = 0.0;
            int k = 1;
            foreach (double v in dataset)
            {
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

        /// <summary>
        /// Finds center of mass of given raw pixel data
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void findCenterOfMass(ushort[] pixels, int width, int height)
        {
            // declare result values
            int centerX, centerY;
            int sizeX, sizeY;
            // find sum of rows
            double[] sumX = getImageSumOfX(pixels, width, height);
            // find minimal row sum value for substraction
            double minX = sumX.Min();
            // find sum of columns
            double[] sumY = getImageSumY(pixels, width, height);
            // find minimal column sum value for substraction
            double minY = sumY.Min();
            // substract minimum value from range for optimization
            // also find non-positive values and zeroe them
            for( int i = 0; i < width; i++)
            {
                // substract minimal value
                sumX[i] -= minX;
                sumY[i] -= minY;
                // check non-positives
                if (sumX[i] < 0)
                    sumX[i] = 0;
                if (sumY[i] < 0)
                    sumY[i] = 0;
            }
            // generate range from 1 to width
            int[] x = Enumerable.Range(1, width).ToArray();
            // generate range from 1 to height
            int[] y = Enumerable.Range(1, height).ToArray();
            // compute center X and Y values
            double ax, ay;
            double sumRangeX, sumRangeY;
            for (int i = 0; i < width; i++)
            {
                ax = sumX[i] * x[i];
                ay = sumY[i] * y[i];
            }

        }

        /// <summary>
        /// Main data fitting function. Consists of running two fittings against each axis.
        /// Returns container object with result data. <see cref="FitResults"/> 
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <param name="fitParams"></param>
        /// <returns></returns>
        public static FitResults fitData(ushort[] pixels, int imageWidth, int imageHeight, FitParams fitParams)
        {
            // create fitting results object
            FitResults fitResults = new FitResults();
            // create stopwatch object for data fitting 
            Stopwatch watch = new Stopwatch();
            // create range data
            double[,] range = new double[imageWidth, 1];
            for (int i = 0; i < imageWidth; i++)
            {
                range[i, 0] = i + 1;
            }

            // get sum of X axis
            double[] sum = getImageSumOfX(pixels, imageWidth, imageHeight);
            // start time observation
            watch.Start();
            // fit X axis
            double[] rawResultX = fit(range, sum, imageWidth, imageWidth, fitParams);
            // stop observation X
            watch.Stop();
            // put results in FitResults object
            fitResults.fromRawDataX(rawResultX);
            fitResults.fitTimeX = watch.ElapsedMilliseconds;

            // get sum of Y axis
            sum = getImageSumY(pixels, imageWidth, imageHeight);
            // start time observation
            watch.Restart();
            // fit Y axis
            double[] rawResultY = fit(range, sum, imageWidth, imageWidth, fitParams);
            // stop observation Y
            watch.Stop();
            // put results in FitResults object
            fitResults.fromRawDataY(rawResultY);
            fitResults.fitTimeY = watch.ElapsedMilliseconds;

            return fitResults;
        }


        /// <summary>
        /// This function runs ALGLIB methods for gaussian curve fitting algorithm.
        /// W need to provide additional fitting parameters as a double[] fitParams parameter.
        /// Notice, that result double[] has an additional last place for resultCode!
        /// </summary>
        /// <param name="range"> 1 - width range of 1d fitting </param>
        /// <param name="pixels"> X, or Y summed data of image pixels </param>
        /// <param name="width"> image width </param>
        /// <param name="height"> image height </param>
        /// <param name="parameters"> array of params for gauss fitting algorithm </param>
        /// <param name="epsf"> Stopping criterion </param>
        /// <param name="epsx"> Stop condition -> |V|=<epsX </param>
        /// <param name="maxits">Maximum iterations. If equals to 0, then iterations are automatic</param>
        /// <param name="diffstep"> differentiation step </param>
        /// <returns></returns>
        public static double[] fit(double[,] range, double[] pixels, int width, int height, FitParams fitParams)
        {
            // make array for results + one place for fitting result code
            double[] results = new double[FitParams.NUMBER_OF_PARAMS];
            //double[] y = pixels;
            //double[] c = new double[] { 0.3, 215, 148, 0.2 };
            // declare result data objects
            int resultCode = FitResults.FIT_ERROR_RESULT;
            alglib.lsfitstate state;
            alglib.lsfitreport rep;
            // run main fitting algorithm
            try {
                alglib.lsfitcreatef(range, pixels, fitParams.getInitialParams(), fitParams.diffStep, out state);
                alglib.lsfitsetcond(state, fitParams.epsF, fitParams.epsX, fitParams.maxIterations);
                alglib.lsfitfit(state, function_cx_1_func, null, null);
                alglib.lsfitresults(state, out resultCode, out results, out rep);
            } catch (Exception e)
            {
                Debug.WriteLine("fit() : " + e.StackTrace);
            }
            // add result Code to results
            Array.Resize(ref results, FitParams.NUMBER_OF_PARAMS + 1);
            results[FitParams.NUMBER_OF_PARAMS] = resultCode;
            return results;
        }

        /// <summary>
        /// Mathematical function for gauss curve fitting algorithm
        /// </summary>
        /// <param name="c"></param>
        /// <param name="x"></param>
        /// <param name="func"></param>
        /// <param name="obj"></param>
        public static void function_cx_1_func(double[] c, double[] x, ref double func, object obj)
        {
            //x is a position on X-axis and c is adjustable parameter
            func = c[0] * Math.Exp(-(x[0] - c[1]) * (x[0] - c[1]) / (c[2] * c[2])) + c[3];
        }


    }
}
