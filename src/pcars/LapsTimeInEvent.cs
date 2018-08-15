using System;
namespace pcars
{
    public class LapsTimeInEvent : IDecoder
    {
        //private TopBitDecoder isTimedEvent;
        private TwoByteDecoder lapsTimeInEvent;

        public LapsTimeInEvent()
        {
            //isTimedEvent = new TopBitDecoder();
            lapsTimeInEvent = new TwoByteDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            lapsTimeInEvent.Decode(ref bytes, ref index);
            //isTimedEvent.Decode(ref bytes, ref index);
            //index++;
        }

        public bool IsTimedEvent() 
        {
            if (lapsTimeInEvent.Short() < 0)
            {
                return true;
            }
            else {
                return false;
            }
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
                TimeSpan time = new TimeSpan();
                time = TimeSpan.FromMinutes((lapsTimeInEvent.UShort() & 32767) * 5);
                return time.ToString("g");
                //return (lapsTimeInEvent.UShort() & 32767) * 5;
            }
            return "Not Timed";
        }
    }
}
