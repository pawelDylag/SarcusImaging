using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    class FitResults
    {

        public static readonly int FIT_ERROR_RESULT = -1;

        // fit results data
        public double amplitudeX { get; set; }
        public double amplitudeY { get; set; }
        public double centerX { get; set; }
        public double centerY { get; set; }
        public double widthX { get; set; }
        public double widthY { get; set; }
        public double backgroundX { get; set; }
        public double backgroundY { get; set; }

        // fitting engine return code
        public int resultCodeX { get; set; }
        public int resultCodeY { get; set; }

        // fitting time data
        public long fitTimeX { get; set; }
        public long fitTimeY { get; set; }




        /// <summary>
        /// Saves results from raw data in array
        /// </summary>
        /// <param name="data"></param>
        public void fromRawDataX(double[] data)
        {
            // check if array is not to short
            if (data.Length >= FitParams.NUMBER_OF_PARAMS)
            {
                amplitudeX = data[0];
                centerX = data[1];
                widthX = data[2];
                backgroundX = data[3];
                resultCodeX = (int) data[4];
            }
        }

        /// <summary>
        /// Saves results from raw data in array
        /// </summary>
        /// <param name="data"></param>
        public void fromRawDataY(double[] data)
        {
            if (data.Length >= FitParams.NUMBER_OF_PARAMS)
            {
                amplitudeY = data[0];
                centerY = data[1];
                widthY = data[2];
                backgroundY = data[3];
                resultCodeY = (int) data[4];
            }
        }


    }
}
