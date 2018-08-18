using System;
namespace pcars
{
    public class TimeStatsDataDecoder : PacketDecoder
    {
        public PacketBaseDecoder packetBase;
        public FourByteDecoder participantsChangedTimestamp;
        public ParticipantsStatsArrayDecoder stats;
        
        public TimeStatsDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            participantsChangedTimestamp = new FourByteDecoder();
            stats = new ParticipantsStatsArrayDecoder();

            base.Add(packetBase);
            base.Add(participantsChangedTimestamp);
            base.Add(stats);
        }
    }
}
