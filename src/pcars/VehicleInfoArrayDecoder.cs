using System;
namespace pcars
{
    public class VehicleInfoArrayDecoder : IDecoder
    {
        public const int VEHICLES_PER_PACKET = 16;

        public VehicleInfoDecoder[] vehicleInfos;

        public VehicleInfoArrayDecoder()
        {
            vehicleInfos = new VehicleInfoDecoder[VEHICLES_PER_PACKET];
            for (uint i = 0; i < VEHICLES_PER_PACKET; ++i)
            {
                vehicleInfos[i] = new VehicleInfoDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < VEHICLES_PER_PACKET; ++i)
            {
                vehicleInfos[i].Decode(ref bytes, ref index);
            }
        }

        public VehicleInfoDecoder VehicleInfoArray(int index)
        {
            return vehicleInfos[index];
        }
    }
}
