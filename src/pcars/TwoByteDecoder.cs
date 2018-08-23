using System;
namespace pcars
{
    public class TwoByteDecoder : IDecoder
    {
        readonly Byte[] data;

        public TwoByteDecoder()
        {
            data = new byte[2];
            data[0] = 0x00;
            data[1] = 0x00;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data[0] = bytes[index++];
            data[1] = bytes[index++];
        }

        public short Short()
        {
            return BitConverter.ToInt16(data, 0);
        }

        public ushort UShort()
        {
            return BitConverter.ToUInt16(data, 0);
        }

        public int Int()
        {
            return BitConverter.ToInt16(data, 0);
        }

        public uint UInt()
        {
            return BitConverter.ToUInt16(data, 0);
        }
    }
}
