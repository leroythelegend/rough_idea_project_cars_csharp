using System;
namespace pcars
{
    public class PitModeScheduleDecoder : IDecoder
    {
        TopFourBitDecoder pitSchedule;
        readonly BottomFourBitDecoder pitMode;

        public PitModeScheduleDecoder()
        {
            pitSchedule = new TopFourBitDecoder();
            pitMode = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            pitSchedule.Decode(ref bytes, ref index);
            pitMode.Decode(ref bytes, ref index);
            index++;
        }

        public PitSchedules PitSchedule()
        {
            return (PitSchedules)pitSchedule.Int();
        }

        public PitModes PitMode()
        {
            return (PitModes)pitMode.Int();
        }

    }
}
