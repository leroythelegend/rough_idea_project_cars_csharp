using System;
using System.Text;

namespace pcars
{
    public class StringMatrixDecoder : IDecoder
    {
        readonly int firstIndex;
        readonly int secondIndex;
        readonly string[] data;

        public StringMatrixDecoder(int firstIndex, int secondIndex)
        {
            this.firstIndex = firstIndex;
            this.secondIndex = secondIndex;
            data = new string[firstIndex];
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (int i = 0; i < firstIndex; ++i)
            {
                var raw = Encoding.UTF8.GetString(bytes, index, secondIndex);
                data[i] = raw.Substring(0, raw.IndexOf('\0'));
                index += secondIndex;
            }
        }

        public string String(int index)
        {
            return data[index];
        }
    }
}
