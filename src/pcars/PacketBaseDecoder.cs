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

            base.Add(packetNumber);
            base.Add(categoryPacketNumber);
            base.Add(partialPacketIndex);
            base.Add(partialPacketNumber);
            base.Add(packetType);
            base.Add(packetVersion);
        }
    }
}
