using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    public class SequenceItem
    {
        public int id { get; set; }
        public types type { get; set; }
        public double exposureTime { get; set; }
        public int imageCount { get; set; }
        public int triggerType { get; set; }
        public String filename { get; set; }

        public enum types : int { TYPE_BACKGROUND = 0, TYPE_SEQUENCE = 1, TYPE_BIAS = 2, TYPE_PROBE = 3 }

        public enum triggerTypes : int { TRIGGER_NONE = 0, TRIGGER_EACH = 1, TRIGGER_WHOLE = 2, TRIGGER_ALL_WITHOUT_FIRST = 3}

        public SequenceItem(int id, types type, double exposureTime, int imageCount, int triggerType, String filename)
        {
            this.id = id;
            this.type = type;
            this.exposureTime = exposureTime;
            this.imageCount = imageCount;
            this.triggerType = triggerType;
            this.filename = filename;
        }


    }
}
