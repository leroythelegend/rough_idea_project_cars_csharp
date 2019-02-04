using System;
namespace pcars
{
    public class ConsoleProcess : IProcess
    {
        readonly PacketQueue packets;

        //readonly Record recordSession;
        //readonly RecordTrack recordSession;
        readonly RecordMap recordSession;

        //readonly Display displayConsole;
        //readonly DisplayTrack displayConsole;
        readonly DisplayMap displayConsole;

        readonly Capture capture;

        public ConsoleProcess(ref PacketQueue packets)
        {
            //recordSession = new RecordTrack();
            //displayConsole = new DisplayTrack();
            //recordSession = new Record();
            //displayConsole = new Display();
            recordSession = new RecordMap();
            displayConsole = new DisplayMap();

            this.packets = packets;
            capture = new Capture(recordSession, displayConsole);
        }

        public void Process()
        {
            while (true)
            {
                //Console.WriteLine("Number of elements " + packets.Size());
                if (!packets.IsEmpty())
                {
                    capture.CapturePacket(packets.Pop());
                }
            }
        }
    }
}
