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

            base.Add(fastestLapTime);
            base.Add(lastLapTime);
            base.Add(lastSectorTime);
            base.Add(fastestSector1Time);
            base.Add(fastestSector2Time);
            base.Add(fastestSector3Time);
            base.Add(participantOnlineRep);
            base.Add(MPParticipantIndex);
        }
    }
}
