using System;
using System.Collections.Generic;

namespace pcars
{
    public class Record : IRecord
    {
        readonly List<Telemetry> telemetry;
        
        public Record()
        {
            telemetry = new List<Telemetry>();
        }

        public void RecordTelemetry(PacketDecoder packet)
        {
            if (packet.GetType().Name == "TelemetryDataDecoder")
            {
                var decoder = (TelemetryDataDecoder)packet;

                var item = new Telemetry
                {
                    airPressureFL = decoder.airPressure.Int(0),
                    airPressureFR = decoder.airPressure.Int(1),
                    airPressureRL = decoder.airPressure.Int(2),
                    airPressureRR = decoder.airPressure.Int(3)
                };

                telemetry.Add(item);
            }
        }

        public void Clear()
        {
            telemetry.Clear();
        }

        public List<Telemetry> Telemetry()
        {
            return telemetry;   
        }
    }
}
