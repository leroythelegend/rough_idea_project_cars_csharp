using System;
namespace pcars
{
    public class HighestFlagDecoder : IDecoder
    {
        TopFourBitDecoder flagReason;
        readonly BottomFourBitDecoder flagColour;

        public HighestFlagDecoder()
        {
            flagReason = new TopFourBitDecoder();
            flagColour = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            flagReason.Decode(ref bytes, ref index);
            flagColour.Decode(ref bytes, ref index);
            index++;
        }

        public FlagReasons FlagReason()
        {
            return (FlagReasons)flagReason.Int();
        }

        public FlagColours FlagColours()
        {
            return (FlagColours)flagColour.Int();
        }
    }
}
