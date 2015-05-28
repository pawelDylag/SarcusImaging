using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    public class ImageReadyArgs : EventArgs
    {
        public ushort[] pixels { get; private set; }

        public ImageReadyArgs(ushort[] pixels)
        {
            this.pixels = pixels;
        }
    }
}
