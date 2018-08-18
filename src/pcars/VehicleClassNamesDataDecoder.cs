using System;
namespace pcars
{
    public class VehicleClassNamesDataDecoder : PacketDecoder, IPacket
    {
        public PacketBaseDecoder packetBase;
        public ClassInfoArrayDecoder classInfo;

        public VehicleClassNamesDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            classInfo = new ClassInfoArrayDecoder();

            Add(packetBase);
            Add(classInfo);
        }

        public PacketBaseDecoder PacketBase()
        {
            return packetBase;
        }
    }
}
