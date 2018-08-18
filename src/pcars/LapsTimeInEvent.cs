using System;
namespace pcars
{
    public class LapsTimeInEvent : IDecoder
    {
        readonly TwoByteDecoder lapsTimeInEvent;

        public LapsTimeInEvent()
        {
            lapsTimeInEvent = new TwoByteDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            lapsTimeInEvent.Decode(ref bytes, ref index);
        }

        public bool IsTimedEvent() 
        {
            if (lapsTimeInEvent.Short() < 0)
            {
                return true;
            }
            return false;
        }

        public short Laps()
        {
            if (!(IsTimedEvent()))
            {
                return lapsTimeInEvent.Short();
            }
            return 0;
        }

        public string TimeInEvent()
        {
            if (IsTimedEvent())
            {
                var time = new TimeSpan();

                time = TimeSpan.FromMinutes((lapsTimeInEvent.UShort() & 32767) * 5);
                return time.ToString("g");
            }
            return "Not Timed";
        }
    }
}
