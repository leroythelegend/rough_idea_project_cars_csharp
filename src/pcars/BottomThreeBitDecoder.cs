using System;
namespace pcars
{
    public class BottomThreeBitDecoder
    {
        int data;

        public BottomThreeBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = (bytes[index] & 7);
        }

        public int Int()
        {
            return data;
        }
    }
}
