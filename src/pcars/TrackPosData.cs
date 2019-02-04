using System;
using System.Collections.Generic;

namespace pcars
{
    [Serializable()]
    public class TrackPosData
    {
        public List<TrackData> trackData;

        public TrackPosData()
        {
            trackData = new List<TrackData>();
        }
    }
}
