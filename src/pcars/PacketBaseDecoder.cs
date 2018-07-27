using System;
namespace pcars
{
    public class PacketBaseDecoder : CompositeDecoder
    {
        public UIntDecoder packetNumber;
        public UIntDecoder categoryPacketNumber;
        public OneByteDecoder partialPacketIndex;
        public OneByteDecoder partialPacketNumber;
        public OneByteDecoder packetType;
        public OneByteDecoder packetVersion;

        public PacketBaseDecoder()
        {
            packetNumber = new UIntDecoder();
            categoryPacketNumber = new UIntDecoder();
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
