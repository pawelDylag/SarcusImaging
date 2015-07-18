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
        public int imageType { get; private set; }

        public ImageReadyArgs(ushort[] pixels, int imageType)
        {
            this.pixels = pixels;
            this.imageType = imageType;
        }
    }
}
