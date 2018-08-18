using System;
namespace pcars
{
    public class SectorDecoder : IDecoder
    {
        TopTwoBitDecoder zExtraPrecision;
        SecondTwoBitDecoder xExtraPrecision;
        readonly BottomFourBitDecoder sector;

        public SectorDecoder()
        {
            zExtraPrecision = new TopTwoBitDecoder();
            xExtraPrecision = new SecondTwoBitDecoder();
            sector = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            zExtraPrecision.Decode(ref bytes, ref index);
            xExtraPrecision.Decode(ref bytes, ref index);
            sector.Decode(ref bytes, ref index);
            index++;
        }

        public int ZExtraPrecision()
        {
            return zExtraPrecision.Int();
        }

        public int XExtraPrecision()
        {
            return xExtraPrecision.Int();
        }

        public int Sector()
        {
            return sector.Int();
        }
    }
}
