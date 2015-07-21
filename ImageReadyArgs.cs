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
        public SequenceItem.types imageType { get; set; }

        public ImageReadyArgs(ushort[] pixels, SequenceItem.types imageType)
        {
            this.pixels = pixels;
            this.imageType = imageType;
        }
    }
}
