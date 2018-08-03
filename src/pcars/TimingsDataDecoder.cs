using System;
namespace pcars
{
    public class TimingsDataDecoder : CompositeDecoder
    {

        public PacketBaseDecoder packetBase;
        public OneByteDecoder numParticipants;
        public UIntDecoder participantsChangedTimestamp;
        public FloatDecoder eventTimeRemaining;
        public FloatDecoder splitTimeAhead;
        public FloatDecoder splitTimeBehind;
        public FloatDecoder splitTime;
        public ParticipantInfoArrayDecoder participants;
        public UShortDecoder localParticipantIndex;
        public UIntDecoder tickCount;


        public TimingsDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            numParticipants = new OneByteDecoder();
            participantsChangedTimestamp = new UIntDecoder();
            eventTimeRemaining = new FloatDecoder();
            splitTimeAhead = new FloatDecoder();
            splitTimeBehind = new FloatDecoder();
            splitTime = new FloatDecoder();
            participants = new ParticipantInfoArrayDecoder(ParticipantInfoArrayDecoder.UDP_STREAMER_PARTICIPANTS_SUPPORTED);
            localParticipantIndex = new UShortDecoder();
            tickCount = new UIntDecoder();

            base.Add(packetBase);
            base.Add(numParticipants);
            base.Add(participantsChangedTimestamp);
            base.Add(eventTimeRemaining);
            base.Add(splitTimeAhead);
            base.Add(splitTimeBehind);
            base.Add(splitTime);
            base.Add(participants);
            base.Add(localParticipantIndex);
            base.Add(tickCount);
        }
    }
}
