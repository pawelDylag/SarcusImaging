using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarcusImaging
{
    /// <summary>
    /// Utility class for time measurement
    /// </summary>
    class ImagingTimer
    {

        Stopwatch stopwatch;
        List<Timestamp> timestamps;

        public ImagingTimer ()
        {
            stopwatch = new Stopwatch();
            timestamps = new List<Timestamp>();
        }

        private struct Timestamp
        {
            public long timestamp;
            public String comment;
        }

        public void start()
        {
            stopwatch.Start();
        }

        public void timestamp(String comment)
        {
            Timestamp timestamp = new Timestamp();
            timestamp.comment = comment;
            timestamp.timestamp = stopwatch.ElapsedMilliseconds;
            timestamps.Add(timestamp);
        }

        public void stop()
        {
            stopwatch.Stop();
        }

        public String listTimes()
        {
            String result = "Imaging time (absolute time / period time):" + Environment.NewLine;
            long lastTimestamp = 0;
            for (int i = 0; i < timestamps.Count; i++)
            {
                long timestamp = timestamps[i].timestamp - lastTimestamp;
                result += (i + ". " + timestamps[i].timestamp + "ms (" + timestamp + "ms)" + " - " + timestamps[i].comment + Environment.NewLine);
                lastTimestamp = timestamps[i].timestamp;
            }
            return result;
        }

        public String listPeriodTimes()
        {
            String result = "Imaging time:" + Environment.NewLine;
            long lastTimestamp = 0;
            for (int i = 0; i < timestamps.Count; i++)
            {
                long timestamp = timestamps[i].timestamp - lastTimestamp;
                result += (i + ". " + timestamp + "ms" + " - " + timestamps[i].comment + Environment.NewLine);
                lastTimestamp = timestamps[i].timestamp;
            }
            return result;
        }

        public void reset()
        {
            stopwatch.Reset();
            timestamps.Clear();
        }

    }
}
