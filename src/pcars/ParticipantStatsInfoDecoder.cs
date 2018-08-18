using System;
namespace pcars
{
    public class ParticipantStatsInfoDecoder : PacketDecoder
    {
        public FourByteDecoder fastestLapTime;
        public FourByteDecoder lastLapTime;
        public FourByteDecoder lastSectorTime;
        public FourByteDecoder fastestSector1Time;
        public FourByteDecoder fastestSector2Time;
        public FourByteDecoder fastestSector3Time;
        public FourByteDecoder participantOnlineRep;
        public TwoByteDecoder MPParticipantIndex;
        
        public ParticipantStatsInfoDecoder()
        {
            fastestLapTime = new FourByteDecoder();
            lastLapTime = new FourByteDecoder();
            lastSectorTime = new FourByteDecoder();
            fastestSector1Time = new FourByteDecoder();
            fastestSector2Time = new FourByteDecoder();
            fastestSector3Time = new FourByteDecoder();
            participantOnlineRep = new FourByteDecoder();
            MPParticipantIndex = new TwoByteDecoder();

            Add(fastestLapTime);
            Add(lastLapTime);
            Add(lastSectorTime);
            Add(fastestSector1Time);
            Add(fastestSector2Time);
            Add(fastestSector3Time);
            Add(participantOnlineRep);
            Add(MPParticipantIndex);
        }
    }
}
