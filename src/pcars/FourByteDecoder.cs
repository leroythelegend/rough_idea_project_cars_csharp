using System;
namespace pcars
{
    public class FourByteDecoder : IDecoder
    {
        private readonly Byte[] data;

        public FourByteDecoder()
        {
            data = new Byte[4];
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            data[0] = bytes[index];
            ++index;
            data[1] = bytes[index];
            ++index;
            data[2] = bytes[index];
            ++index;
            data[3] = bytes[index];
            ++index;
        }

        public float Float()
        {
            return BitConverter.ToSingle(data, 0);
        }

        public uint UInt()
        {
            return BitConverter.ToUInt32(data, 0);
        }

        public int Int()
        {
            return BitConverter.ToInt32(data, 0);
        }

        public string TimeStamp()
        {
            TimeSpan time = new TimeSpan();
            float timeData = BitConverter.ToSingle(data, 0);
            if (timeData < TimeSpan.MaxValue.Milliseconds &&
                timeData > TimeSpan.MinValue.TotalMilliseconds)
            {
                time = TimeSpan.FromSeconds(BitConverter.ToSingle(data, 0));
                return time.ToString("g");
            }
            return string.Empty;
        }
    }
}
