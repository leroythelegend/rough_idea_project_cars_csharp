using System;
namespace pcars
{
    public class ParticipantsDataDecoder : PacketDecoder
    {
        
        private readonly int PARTICIPANTS_PER_PACKET = 16;
        private readonly int PARTICIPANT_NAME_LENGTH_MAX = 64;

        public PacketBaseDecoder packetBase;
        public FourByteDecoder participantsChangedTimestamp;
        public StringMatrixDecoder name;
        public FourByteArrayDecoder nationality;
        public TwoByteArrayDecoder index;


        public ParticipantsDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            participantsChangedTimestamp = new FourByteDecoder();
            name = new StringMatrixDecoder(PARTICIPANTS_PER_PACKET, PARTICIPANT_NAME_LENGTH_MAX);
            nationality = new FourByteArrayDecoder(PARTICIPANTS_PER_PACKET);
            index = new TwoByteArrayDecoder(PARTICIPANTS_PER_PACKET);

            base.Add(packetBase);
            base.Add(participantsChangedTimestamp);
            base.Add(name);
            base.Add(nationality);
            base.Add(index);
        }
    }
}
