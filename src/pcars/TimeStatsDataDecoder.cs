using System;
namespace pcars
{
    public class TimeStatsDataDecoder : PacketDecoder, IPacket
    {
        public PacketBaseDecoder packetBase;
        public FourByteDecoder participantsChangedTimestamp;
        public ParticipantsStatsArrayDecoder stats;
        
        public TimeStatsDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            participantsChangedTimestamp = new FourByteDecoder();
            stats = new ParticipantsStatsArrayDecoder();

            Add(packetBase);
            Add(participantsChangedTimestamp);
            Add(stats);
        }

        public PacketBaseDecoder PacketBase()
        {
            return packetBase;
        }
    }
}
