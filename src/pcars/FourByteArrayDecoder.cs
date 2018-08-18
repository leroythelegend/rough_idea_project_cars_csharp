using System;
namespace pcars
{
    public class FourByteArrayDecoder : IDecoder
    {
        readonly int amount;
        readonly FourByteDecoder[] data;

        public FourByteArrayDecoder(int amount)
        {
            this.amount = amount;
            data = new FourByteDecoder[amount];

            for (int i = 0; i < amount; ++i)
            {
                data[i] = new FourByteDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < amount; ++i)
            {
                data[i].Decode(ref bytes, ref index);
            }
        }

        public float Float(int index)
        {
            return data[index].Float();
        }


        public uint UInt(int index)
        {
            return data[index].UInt();
        }
    }
}
