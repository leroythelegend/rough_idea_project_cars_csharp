using System;
namespace pcars
{
    public class BottomFourBitDecoder
    {
        int data;

        public BottomFourBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = (bytes[index] & 15);
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
