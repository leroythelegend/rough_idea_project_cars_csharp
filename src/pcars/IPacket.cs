using System;
namespace pcars
{
    public interface IPacket
    {
        PacketBaseDecoder PacketBase();
    }
}
