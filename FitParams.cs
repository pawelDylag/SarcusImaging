using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    class FitParams
    {

        public static readonly int NUMBER_OF_PARAMS = 4;

        public double epsF { get; set; }
        public double epsX { get; set; }
        public double diffStep { get; set; }
        public int maxIterations { get; set; }

        public double amplitude { get; set; }
        public double center { get; set; }
        public double width { get; set; }
        public double background { get; set; }


        public double[] getInitialParams()
        {
            return new double[4] {amplitude, center, width, background};         
        }

    }
}
