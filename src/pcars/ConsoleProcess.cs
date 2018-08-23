using System;
namespace pcars
{
    public class ConsoleProcess : IProcess
    {
        readonly PacketQueue packets;

        readonly Record recordSession;
        readonly Display displayConsole;

        readonly Capture capture;

        public ConsoleProcess(ref PacketQueue packets)
        {
            recordSession = new Record();
            displayConsole = new Display();

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
