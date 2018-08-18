using System;
namespace pcars
{
    public class RacePositionDecoder : IDecoder
    {
        TopBitDecoder topBit;
        readonly BottomSevenBitDecoder bottomBits;

        public RacePositionDecoder()
        {
            topBit = new TopBitDecoder();
            bottomBits = new BottomSevenBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            topBit.Decode(ref bytes, ref index);
            bottomBits.Decode(ref bytes, ref index);
            index++;
        }

        public bool IsActive()
        {
            return topBit.Bool();
        }

        public int RacePosition()
        {
            return bottomBits.Int();
        }
    }
}
