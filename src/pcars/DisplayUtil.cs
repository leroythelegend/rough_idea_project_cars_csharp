using System;
using System.Collections.Generic;

namespace pcars
{
    public class DisplayUtil
    {
        readonly TelemetryMap telemetry;

        public DisplayUtil(TelemetryMap map)
        {
            telemetry = map;
        }

        public int MaxInt(string item)
        {
            int m = 0;
            foreach (var i in telemetry.telemetry[item])
            {
                if (m < i.Int())
                {
                    m = i.Int();
                }
            }
            return m;
        }
    }
}
