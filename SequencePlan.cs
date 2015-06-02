using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    class SequencePlan
    {
        List<SequenceItem> items; 

        public SequencePlan()
        {
            items = new List<SequenceItem>();
        }

        public void addItem(SequenceItem item )
        {
            items.Add(item);
        }

        public int size()
        {
            return items.Count;
        }

        public SequenceItem getItem(int index)
        {
            SequenceItem result = null;
            if (index <= items.Count)
            {
                result = items[index];
            }
            return result;
        }

        public void setDebugPlan()
        {
            double exposure = 0.1;
            items.Add(new SequenceItem(0, 0, exposure, 1, 0, "debug"));
        }

    }
}
