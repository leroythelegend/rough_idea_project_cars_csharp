using System;
namespace pcars
{
    public class OneByteArrayDecoder : IDecoder
    {
        readonly int amount;
        public OneByteDecoder[] data;

        public OneByteArrayDecoder(int amount)
        {
            this.amount = amount;
            data = new OneByteDecoder[amount];

            for (int i = 0; i < amount; ++i)
            {
                data[i] = new OneByteDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < amount; ++i)
            {
                data[i].Decode(ref bytes, ref index);
            }
        }

        public TyreFlags TyreFlag(int index)
        {
            return (TyreFlags)data[index].UInt();
        }

        public Terrains Terrain(int index)
        {
            return (Terrains)data[index].UInt();
        }

        public int Int(int index)
        {
            return data[index].Int();
        }

        public uint UInt(int index)
        {
            return data[index].UInt();
        }
    }
}
