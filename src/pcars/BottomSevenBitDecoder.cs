using System;
namespace pcars
{
    public class BottomSevenBitDecoder
    {
        int data;

        public BottomSevenBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = (bytes[index] & 127);
        }

        public int Int()
        {
            return data;
        }
    }
}
