using System;
namespace pcars
{
    public class PacketBaseDecoder : PacketDecoder
    {
        public FourByteDecoder packetNumber;
        public FourByteDecoder categoryPacketNumber;
        public OneByteDecoder partialPacketIndex;
        public OneByteDecoder partialPacketNumber;
        public OneByteDecoder packetType;
        public OneByteDecoder packetVersion;

        public PacketBaseDecoder()
        {
            packetNumber = new FourByteDecoder();
            categoryPacketNumber = new FourByteDecoder();
            partialPacketIndex = new OneByteDecoder();
            partialPacketNumber = new OneByteDecoder();
            packetType = new OneByteDecoder();
            packetVersion = new OneByteDecoder();

            Add(packetNumber);
            Add(categoryPacketNumber);
            Add(partialPacketIndex);
            Add(partialPacketNumber);
            Add(packetType);
            Add(packetVersion);
        }
    }
}
