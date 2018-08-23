using System;
using System.Threading;

namespace pcars
{
    class MainClass
    {
        public static void Main()
        {
            //Test test = new Test();

            var packetQueue = new PacketQueue();
            var udpProcess = new UDPProcess(ref packetQueue);
            var consoleProcess = new ConsoleProcess(ref packetQueue);

            var udpThread = new Thread(new ThreadStart(udpProcess.Process));
            var consoleThread = new Thread(new ThreadStart(consoleProcess.Process));

            udpThread.Start();
            consoleThread.Start();

            Console.Read();

            udpThread.Abort();
            consoleThread.Abort();

            return;
        }
    }
}
