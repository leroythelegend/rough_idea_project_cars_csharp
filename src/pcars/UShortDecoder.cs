using System;
namespace pcars
{
    public class UShortDecoder : IDecoder
    {
        private ushort data;

        public UShortDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = BitConverter.ToUInt16(bytes, index);
            index += 2;
        }

        public ushort UShort() 
        {
            return data;
        }
    }
}
