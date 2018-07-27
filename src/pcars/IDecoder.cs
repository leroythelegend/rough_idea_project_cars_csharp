using System;
namespace pcars
{
    public interface IDecoder
    {
        void Decode(ref Byte[] bytes, ref int index);
    }
}
