using System;
namespace pcars
{
    public class BottomFourBitDecoder
    {
        private int data;

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
    }
}
