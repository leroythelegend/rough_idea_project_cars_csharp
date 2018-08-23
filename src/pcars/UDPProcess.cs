using System;
namespace pcars
{
    public class UDPProcess : IProcess
    {
        readonly IReader reader;
        readonly PacketQueue packets;

        public UDPProcess(ref PacketQueue packets)
        {
            reader = new UDPNonBlockingReader(5606);
            this.packets = packets;
        }

        public void Process()
        {
            while (true)
            {
                var bytes = reader.Read();
                if (bytes.Length > 0)
                {
                    int index = 0;
                    var packetBase = new PacketBaseDecoder();

                    packetBase.Decode(ref bytes, ref index);

                    if (packetBase.packetType.UInt() == 0 && bytes.Length == 559)
                    {
                        var telem = new TelemetryDataDecoder();
                        index = 0;

                        telem.Decode(ref bytes, ref index);
                        packets.Push(telem);
                    }

                    if (packetBase.packetType.UInt() == 1 && bytes.Length == 308)
                    {
                        var race = new RaceDataDecoder();
                        index = 0;

                        race.Decode(ref bytes, ref index);
                        packets.Push(race);
                    }

                    if (packetBase.packetType.UInt() == 2 && bytes.Length == 1136)
                    {
                        var participants = new ParticipantsDataDecoder();
                        index = 0;

                        participants.Decode(ref bytes, ref index);
                        packets.Push(participants);
                    }

                    if (packetBase.packetType.UInt() == 3 && bytes.Length == 1063)
                    {
                        var timing = new TimingsDataDecoder();
                        index = 0;

                        timing.Decode(ref bytes, ref index);
                        packets.Push(timing);
                    }

                    if (packetBase.packetType.UInt() == 4 && bytes.Length == 24)
                    {
                        var gamestate = new GameStateDataDecoder();
                        index = 0;

                        gamestate.Decode(ref bytes, ref index);
                        packets.Push(gamestate);
                    }

                    if (packetBase.packetType.UInt() == 7 && bytes.Length == 1040)
                    {
                        var timestats = new TimeStatsDataDecoder();
                        index = 0;

                        timestats.Decode(ref bytes, ref index);
                        packets.Push(timestats);
                    }

                    if (packetBase.packetType.UInt() == 8 && packetBase.partialPacketIndex.UInt() == 1)
                    {
                        var vehicleName = new ParticipantVehicleNamesDataDecoder();
                        index = 0;

                        vehicleName.Decode(ref bytes, ref index);
                        packets.Push(vehicleName);
                    }

                    if (packetBase.packetType.UInt() == 8 && packetBase.partialPacketIndex.UInt() == 2)
                    {
                        var className = new VehicleClassNamesDataDecoder();
                        index = 0;

                        className.Decode(ref bytes, ref index);
                        packets.Push(className);
                    }
                }
            }
        }
    }
}
