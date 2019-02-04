using System;
namespace pcars
{
    public class RecordTrack : IRecord
    {
        readonly RecordedData recordedData;

        public RecordTrack()
        {
            recordedData = new RecordedData();
        }

        public void RecordTelemetry(PacketDecoder packet)
        {
            if (packet.GetType().Name == "TimingsDataDecoder")
            {
                var decoder = (TimingsDataDecoder)packet;

                var item = new TrackData
                {
                    worldposx = decoder.participants.ParticipantInfoArray(0).worldPosition.Int(0),
                    worldposy = decoder.participants.ParticipantInfoArray(0).worldPosition.Int(1),
                    worldposz = decoder.participants.ParticipantInfoArray(0).worldPosition.Int(2),
                    currentLap = decoder.participants.ParticipantInfoArray(0).currentLap.Int()
                };

                recordedData.trackDatas.Add(item);
            }
        }

        public void Clear()
        {
            recordedData.Clear();
        }

        public RecordedData RecordedData()
        {
            return recordedData;
        }

        public TelemetryMap RecordedMap()
        {
            return new TelemetryMap();
        }
    }
}
