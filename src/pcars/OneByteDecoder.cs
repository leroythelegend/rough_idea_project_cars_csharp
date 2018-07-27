using System;
namespace pcars
{
    public class OneByteDecoder : IDecoder
    {
        private Byte data;
        public OneByteDecoder()
        {
            data = 0x00;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = bytes[index];
            ++index;
        }

        public Byte OneByte() {
            return data;
        }

        public uint UInt() {
            return data;
        }
    }
}
