using System;
namespace pcars
{
    public class ParticipantInfoArrayDecoder : IDecoder
    {
        public const int UDP_STREAMER_PARTICIPANTS_SUPPORTED = 32;
        readonly ParticipantInfoDecoder[] data;

        int amount;

        public ParticipantInfoArrayDecoder(int amount)
        {
            this.amount = amount;
            data = new ParticipantInfoDecoder[amount];
            for (uint i = 0; i < amount; ++i) 
            {
                data[i] = new ParticipantInfoDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < amount; ++i)
            {
                data[i].Decode(ref bytes, ref index);
            }
        }

        public ParticipantInfoDecoder ParticipantInfoArray(int index)
        {
            return data[index];
        }
    }
}
