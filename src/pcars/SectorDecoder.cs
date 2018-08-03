using System;
namespace pcars
{
    public class SectorDecoder : IDecoder
    {
        private TopTwoBitDecoder zExtraPrecision;
        private SecondTwoBitDecoder yExtraPrecision;
        private BottomFourBitDecoder sector;

        public SectorDecoder()
        {
            zExtraPrecision = new TopTwoBitDecoder();
            yExtraPrecision = new SecondTwoBitDecoder();
            sector = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            zExtraPrecision.Decode(ref bytes, ref index);
            yExtraPrecision.Decode(ref bytes, ref index);
            sector.Decode(ref bytes, ref index);
            index++;
        }

        public int ZExtraPrecision()
        {
            return zExtraPrecision.Int();
        }

        public int YExtraPrecision()
        {
            return yExtraPrecision.Int();
        }

        public int Sector()
        {
            return sector.Int();
        }
    }
}
