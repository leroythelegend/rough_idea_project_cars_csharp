using System;
namespace pcars
{
    public class UIntDecoder : IDecoder
    {
        private uint data;

        public UIntDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = BitConverter.ToUInt32(bytes, index);
            index += 4;
        }

        public uint UInt() {
            return data;
        }
    }
}
