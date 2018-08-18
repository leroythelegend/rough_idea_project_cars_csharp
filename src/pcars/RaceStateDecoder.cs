using System;
namespace pcars
{
    public class RaceStateDecoder : IDecoder
    {
        BottomThreeBitDecoder raceStateFlags;
        readonly FourthBitDecoder invalidLap;

        public RaceStateDecoder()
        {
            raceStateFlags = new BottomThreeBitDecoder();
            invalidLap = new FourthBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            raceStateFlags.Decode(ref bytes, ref index);
            invalidLap.Decode(ref bytes, ref index);
            ++index;
        }

        public RaceStates RaceState()
        {
            return (RaceStates)raceStateFlags.Int();
        }

        public bool InvalidLap()
        {
            return invalidLap.Bool();
        }
    }
}
