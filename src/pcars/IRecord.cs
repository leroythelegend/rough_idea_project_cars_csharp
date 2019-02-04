using System;
using System.Collections.Generic;

namespace pcars
{
    public interface IRecord
    {
        void RecordTelemetry(PacketDecoder packet);
        void Clear();

        RecordedData RecordedData();
        TelemetryMap RecordedMap();
    }
}
