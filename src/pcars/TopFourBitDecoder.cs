using System;
namespace pcars
{
    public class TopFourBitDecoder
    {
        private int data;

        public TopFourBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = (bytes[index] & 240);
        }

        public int Int()
        {
            return data;
        }
    }
}
