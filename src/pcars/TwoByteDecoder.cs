using System;
namespace pcars
{
    public class TwoByteDecoder : IDecoder
    {
        private Byte[] data;

        public TwoByteDecoder()
        {
            data = new byte[2];
            data[0] = 0x00;
            data[1] = 0x00;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data[0] = bytes[index];
            ++index;
            data[1] = bytes[index];
            ++index;
        }

        public short Short()
        {
            return BitConverter.ToInt16(data, 0);
        }

        public ushort UShort()
        {
            return BitConverter.ToUInt16(data, 0);
        }
    }
}
