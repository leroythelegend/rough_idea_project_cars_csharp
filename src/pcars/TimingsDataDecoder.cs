using System;
namespace pcars
{
    public class TimingsDataDecoder : PacketDecoder
    {
        public PacketBaseDecoder packetBase;
        public OneByteDecoder numParticipants;
        public FourByteDecoder participantsChangedTimestamp;
        public FourByteDecoder eventTimeRemaining;
        public FourByteDecoder splitTimeAhead;
        public FourByteDecoder splitTimeBehind;
        public FourByteDecoder splitTime;
        public ParticipantInfoArrayDecoder participants;
        public TwoByteDecoder localParticipantIndex;
        public FourByteDecoder tickCount;


        public TimingsDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            numParticipants = new OneByteDecoder();
            participantsChangedTimestamp = new FourByteDecoder();
            eventTimeRemaining = new FourByteDecoder();
            splitTimeAhead = new FourByteDecoder();
            splitTimeBehind = new FourByteDecoder();
            splitTime = new FourByteDecoder();
            participants = new ParticipantInfoArrayDecoder(ParticipantInfoArrayDecoder.UDP_STREAMER_PARTICIPANTS_SUPPORTED);
            localParticipantIndex = new TwoByteDecoder();
            tickCount = new FourByteDecoder();

            Add(packetBase);
            Add(numParticipants);
            Add(participantsChangedTimestamp);
            Add(eventTimeRemaining);
            Add(splitTimeAhead);
            Add(splitTimeBehind);
            Add(splitTime);
            Add(participants);
            Add(localParticipantIndex);
            Add(tickCount);
        }
    }
}
