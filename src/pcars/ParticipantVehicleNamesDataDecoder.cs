using System;
namespace pcars
{
    public class ParticipantVehicleNamesDataDecoder : PacketDecoder, IPacket
    {
        public PacketBaseDecoder packetBase;
        public VehicleInfoArrayDecoder vehicles;
        
        public ParticipantVehicleNamesDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            vehicles = new VehicleInfoArrayDecoder();

            Add(packetBase);
            Add(vehicles);
        }

        public PacketBaseDecoder PacketBase()
        {
            return packetBase;
        }
    }
}
