using System;
namespace pcars
{
    public class ParticipantsStatsArrayDecoder : IDecoder
    {
        public const int UDP_STREAMER_PARTICIPANTS_SUPPORTED = 32;

        public ParticipantStatsInfoDecoder[] participants;
        
        public ParticipantsStatsArrayDecoder()
        {
            participants = new ParticipantStatsInfoDecoder[UDP_STREAMER_PARTICIPANTS_SUPPORTED];
            for (uint i = 0; i < UDP_STREAMER_PARTICIPANTS_SUPPORTED; ++i)
            {
                participants[i] = new ParticipantStatsInfoDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < UDP_STREAMER_PARTICIPANTS_SUPPORTED; ++i)
            {
                participants[i].Decode(ref bytes, ref index);
            }
        }

        public ParticipantStatsInfoDecoder ParticipantsStatsArray(int index)
        {
            return participants[index];
        }
    }
}
