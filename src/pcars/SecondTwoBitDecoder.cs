using System;
namespace pcars
{
    public class SecondTwoBitDecoder
    {
        int data;

        public SecondTwoBitDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = ((bytes[index] & 48) >> 4);
        }

        public int Int()
        {
            return data;
        }
    }
}
