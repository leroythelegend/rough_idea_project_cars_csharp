using System;
namespace pcars
{
    public class FourthBitDecoder
    {
        bool data;

        public FourthBitDecoder()
        {
            data = false;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            if ((bytes[index] & 8) != 0)
            {
                data = true;
            }
            else
            {
                data = false;    
            }
        }

        public bool Bool()
        {
            return data;
        }
    }
}
