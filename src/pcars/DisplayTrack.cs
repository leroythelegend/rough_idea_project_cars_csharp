using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{
    public class DisplayTrack : IDisplay
    {
        string fileName;

        public DisplayTrack()
        {
            fileName = "Dubai_Autodrome_Club.bin";
        }

        public void DisplayTelemetry(IRecord record)
        {
            var recordedData = record.RecordedData();

            int lap = 0;
            if (recordedData.trackDatas.Count > 0)
            {
                lap = recordedData.trackDatas[0].currentLap;
            }

            List<TrackPosData> laps = new List<TrackPosData>();
            TrackPosData data = new TrackPosData();

            foreach (var item in recordedData.trackDatas)
            {                
                    var trackData = new TrackData
                    {
                        worldposx = item.worldposx,
                        worldposy = item.worldposy,
                        worldposz = item.worldposz
                    };

                    data.trackData.Add(trackData);

                if (lap != item.currentLap)
                {
                    laps.Add(data);
                    data.trackData.Clear();
                    lap = item.currentLap;
                }
            }

            if (laps.Count > 0)
            {
                Stream SaveFileStream = File.Create(fileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, laps);
                SaveFileStream.Close();
            }
        }
    }
}
