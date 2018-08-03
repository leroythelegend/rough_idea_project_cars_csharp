using System;
namespace pcars
{
    public class ShortArrayDecoder : IDecoder
    {
        private readonly int amount;
        public short[] data;

        public ShortArrayDecoder(int amount)
        {
            this.amount = amount;
            data = new short[amount];
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < amount; ++i)
            {
                data[i] = BitConverter.ToInt16(bytes, index);
                index += 2;
            }
        }

        public short[] ShortArray()
        {
            return data;
        }
    }
}
