using System;
namespace pcars
{
    public class TwoByteArrayDecoder : IDecoder
    {
        private readonly int amount;
        private TwoByteDecoder[] data;

        public TwoByteArrayDecoder(int amount)
        {
            this.amount = amount;
            data = new TwoByteDecoder[amount];

            for (int i = 0; i < amount; ++i)
            {
                data[i] = new TwoByteDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < amount; ++i)
            {
                data[i].Decode(ref bytes, ref index);
            }
        }

        public short Short(int index)
        {
            return data[index].Short();
        }

        public ushort UShort(int index)
        {
            return (ushort)data[index].UShort();
        }
    }
}
