using System;
namespace pcars
{
    public class ParticipantVehicleNamesDataDecoder : PacketDecoder
    {
        public PacketBaseDecoder packetBase;
        public VehicleInfoArrayDecoder vehicles;
        
        public ParticipantVehicleNamesDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            vehicles = new VehicleInfoArrayDecoder();

            base.Add(packetBase);
            base.Add(vehicles);
        }
    }
}
