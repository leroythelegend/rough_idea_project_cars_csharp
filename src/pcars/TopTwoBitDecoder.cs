using System;
namespace pcars
{
    public class TopTwoBitDecoder
    {
        int data;

        public TopTwoBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = ((bytes[index] & 192) >> 6);
        }

        public int Int()
        {
            return data;
        }
    }
}
