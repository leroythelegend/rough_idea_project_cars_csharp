using System;
namespace pcars
{
    public class TopFourBitDecoder
    {
        int data;

        public TopFourBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = ((bytes[index] & 240) >> 4);
        }

        public int Int()
        {
            return data;
        }

        public uint UInt()
        {
            return (uint)data;
        }
    }
}
