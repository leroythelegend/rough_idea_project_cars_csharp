using System;
namespace pcars
{
    public class GearNumGearsDecoder : IDecoder
    {
        TopFourBitDecoder numGears;
        readonly BottomFourBitDecoder gear;

        public GearNumGearsDecoder()
        {
            numGears = new TopFourBitDecoder();
            gear = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            numGears.Decode(ref bytes, ref index);
            gear.Decode(ref bytes, ref index);
            index++;
        }

        public uint NumGears()
        {
            return numGears.UInt();
        }

        public uint Gear()
        {
            return gear.UInt();
        }
    }
}
