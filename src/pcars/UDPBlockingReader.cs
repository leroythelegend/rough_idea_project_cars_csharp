using System;
using System.Net;
using System.Net.Sockets;

namespace pcars
{
    public class UDPBlockingReader : IReader
    {
        readonly UdpClient client;
        IPEndPoint endPoint;

        public UDPBlockingReader(int port)
        {
            client = new UdpClient(port);
            endPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public Byte[] Read()
        {
            return client.Receive(ref endPoint);
        }
    }
}
