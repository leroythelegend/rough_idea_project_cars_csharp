using System;
using System.Net;
using System.Net.Sockets;

namespace pcars
{
public class UDPNonBlockingReader : IReader
    {
        readonly UdpClient client;
        IPEndPoint endPoint;

        public UDPNonBlockingReader(int port)
        {
            client = new UdpClient(port);
            endPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public Byte[] Read()
        {
            if (client.Available != 0)
            {
                return client.Receive(ref endPoint);
            }
            return new Byte[0];
        }
    }
}
