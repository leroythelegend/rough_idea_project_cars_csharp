using System;
namespace pcars
{
    public class TopBitDecoder : IDecoder
    {
        bool data;

        public TopBitDecoder()
        {
            data = false;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            if ((bytes[index] & 128) != 0) {
                data = true;
            }
            else {
                data = false;
            }
        }

        public bool Bool()
        {
            return data;
        }
    }
}
