using System;
using System.Collections.Generic;

namespace pcars
{
    [Serializable()]
    public class RecordedData
    {
        public List<Telemetry> telemetry;
        public List<RaceInfo> raceInfos;
        public List<TrackData> trackDatas;



        public RecordedData()
        {
            telemetry = new List<Telemetry>();
            raceInfos = new List<RaceInfo>();
            trackDatas = new List<TrackData>();
        }

        public void Clear()
        {
            telemetry.Clear();
            raceInfos.Clear();
        }
    }
}
