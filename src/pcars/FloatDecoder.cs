using System;
namespace pcars
{
    public class FloatDecoder : IDecoder
    {
        private float data;

        public FloatDecoder()
        {
            data = 0;
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data = BitConverter.ToSingle(bytes, index);
            index += 4;
        }

        public float Float()
        {
            return data;
        }
    }
}
