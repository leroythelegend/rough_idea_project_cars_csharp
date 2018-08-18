using System;
namespace pcars
{
    public class VehicleInfoDecoder : PacketDecoder
    {
        public const int VEHICLE_NAME_LENGTH_MAX = 64;

        //public TwoByteDecoder index; // Header files says two bytes not sure this is correct
        public FourByteDecoder index;
        public FourByteDecoder vehicleClass;
        public StringMatrixDecoder name;

        public VehicleInfoDecoder()
        {
            index = new FourByteDecoder();
            vehicleClass = new FourByteDecoder();
            name = new StringMatrixDecoder(1, VEHICLE_NAME_LENGTH_MAX);

            Add(index);
            Add(vehicleClass);
            Add(name);
        }
    }
}
