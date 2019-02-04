using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{
    public class RecordMap : IRecord
    {
        public TelemetryMap telemetry;

        public RecordMap()
        {
            telemetry = new TelemetryMap();
        }

        public void RecordTelemetry(PacketDecoder packet)
        {
            List<TelemetryData> airPressureFL = new List<TelemetryData>();

            if (packet.GetType().Name == "TelemetryDataDecoder")
            {
                var decoder = (TelemetryDataDecoder)packet;

                telemetry.telemetry["airPressureFL"].Add(new TelemetryData(decoder.airPressure.Int(0)));
                telemetry.telemetry["airPressureFR"].Add(new TelemetryData(decoder.airPressure.Int(1)));
                telemetry.telemetry["airPressureRL"].Add(new TelemetryData(decoder.airPressure.Int(2)));
                telemetry.telemetry["airPressureRR"].Add(new TelemetryData(decoder.airPressure.Int(3)));

                telemetry.telemetry["brakeTempFL"].Add(new TelemetryData(decoder.brakeTempCelsius.Int(0)));
                telemetry.telemetry["brakeTempFR"].Add(new TelemetryData(decoder.brakeTempCelsius.Int(1)));
                telemetry.telemetry["brakeTempRL"].Add(new TelemetryData(decoder.brakeTempCelsius.Int(2)));
                telemetry.telemetry["brakeTempRR"].Add(new TelemetryData(decoder.brakeTempCelsius.Int(3)));
            
                telemetry.telemetry["tyreTreadFL"].Add(new TelemetryData(decoder.tyreTreadTemp.Int(0)));
                telemetry.telemetry["tyreTreadFR"].Add(new TelemetryData(decoder.tyreTreadTemp.Int(1)));
                telemetry.telemetry["tyreTreadRL"].Add(new TelemetryData(decoder.tyreTreadTemp.Int(2)));
                telemetry.telemetry["tyreTreadRR"].Add(new TelemetryData(decoder.tyreTreadTemp.Int(3)));

                telemetry.telemetry["tyreLayerFL"].Add(new TelemetryData(decoder.tyreLayerTemp.Int(0)));
                telemetry.telemetry["tyreLayerFR"].Add(new TelemetryData(decoder.tyreLayerTemp.Int(1)));
                telemetry.telemetry["tyreLayerRL"].Add(new TelemetryData(decoder.tyreLayerTemp.Int(2)));
                telemetry.telemetry["tyreLayerRR"].Add(new TelemetryData(decoder.tyreLayerTemp.Int(3)));

                telemetry.telemetry["tyreCarcassFL"].Add(new TelemetryData(decoder.tyreCarcassTemp.Int(0)));
                telemetry.telemetry["tyreCarcassFR"].Add(new TelemetryData(decoder.tyreCarcassTemp.Int(1)));
                telemetry.telemetry["tyreCarcassRL"].Add(new TelemetryData(decoder.tyreCarcassTemp.Int(2)));
                telemetry.telemetry["tyreCarcassRR"].Add(new TelemetryData(decoder.tyreCarcassTemp.Int(3)));

                telemetry.telemetry["tyreRimFL"].Add(new TelemetryData(decoder.tyreRimTemp.Int(0)));
                telemetry.telemetry["tyreRimFR"].Add(new TelemetryData(decoder.tyreRimTemp.Int(1)));
                telemetry.telemetry["tyreRimRL"].Add(new TelemetryData(decoder.tyreRimTemp.Int(2)));
                telemetry.telemetry["tyreRimRR"].Add(new TelemetryData(decoder.tyreRimTemp.Int(3)));

                telemetry.telemetry["tyreTempFL"].Add(new TelemetryData(decoder.tyreTemp.UInt(0)));
                telemetry.telemetry["tyreTempFR"].Add(new TelemetryData(decoder.tyreTemp.UInt(1)));
                telemetry.telemetry["tyreTempRL"].Add(new TelemetryData(decoder.tyreTemp.UInt(2)));
                telemetry.telemetry["tyreTempRR"].Add(new TelemetryData(decoder.tyreTemp.UInt(3)));

                telemetry.telemetry["FLLeft"].Add(new TelemetryData(decoder.tyreTempLeft.Int(0)));
                telemetry.telemetry["FLCentre"].Add(new TelemetryData(decoder.tyreTempCenter.Int(0)));
                telemetry.telemetry["FLRight"].Add(new TelemetryData(decoder.tyreTempRight.Int(0)));

                telemetry.telemetry["FRLeft"].Add(new TelemetryData(decoder.tyreTempLeft.Int(1)));
                telemetry.telemetry["FRCentre"].Add(new TelemetryData(decoder.tyreTempCenter.Int(1)));
                telemetry.telemetry["FRRight"].Add(new TelemetryData(decoder.tyreTempRight.Int(1)));

                telemetry.telemetry["RLLeft"].Add(new TelemetryData(decoder.tyreTempLeft.Int(2)));
                telemetry.telemetry["RLCentre"].Add(new TelemetryData(decoder.tyreTempCenter.Int(2)));
                telemetry.telemetry["RLRight"].Add(new TelemetryData(decoder.tyreTempRight.Int(2)));

                telemetry.telemetry["RRLeft"].Add(new TelemetryData(decoder.tyreTempLeft.Int(3)));
                telemetry.telemetry["RRCentre"].Add(new TelemetryData(decoder.tyreTempCenter.Int(3)));
                telemetry.telemetry["RRRight"].Add(new TelemetryData(decoder.tyreTempRight.Int(3)));

                telemetry.telemetry["FLSupHeight"].Add(new TelemetryData(decoder.suspensionRideHeight.Int(0)));
                telemetry.telemetry["FRSupHeight"].Add(new TelemetryData(decoder.suspensionRideHeight.Int(1)));
                telemetry.telemetry["RLSupHeight"].Add(new TelemetryData(decoder.suspensionRideHeight.Int(2)));
                telemetry.telemetry["RRSupHeight"].Add(new TelemetryData(decoder.suspensionRideHeight.Int(3)));

                telemetry.telemetry["FLHeight"].Add(new TelemetryData(decoder.rideHeight.Float(0)));
                telemetry.telemetry["FRHeight"].Add(new TelemetryData(decoder.rideHeight.Float(1)));
                telemetry.telemetry["RLHeight"].Add(new TelemetryData(decoder.rideHeight.Float(2)));
                telemetry.telemetry["RRHeight"].Add(new TelemetryData(decoder.rideHeight.Float(3)));

                telemetry.telemetry["gear"].Add(new TelemetryData(decoder.gearNumGears.Gear()));
                telemetry.telemetry["numGear"].Add(new TelemetryData(decoder.gearNumGears.NumGears()));
                telemetry.telemetry["rpm"].Add(new TelemetryData(decoder.rpm.Int()));
                telemetry.telemetry["maxRpm"].Add(new TelemetryData(decoder.maxRpm.Int()));
                telemetry.telemetry["torque"].Add(new TelemetryData(decoder.engineTorque.Float()));
                telemetry.telemetry["engSpeed"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                telemetry.telemetry["speed"].Add(new TelemetryData(decoder.speed.Float()));
                telemetry.telemetry["steering"].Add(new TelemetryData(decoder.steering.Int()));

                telemetry.telemetry["FLSuspensionTravel"].Add(new TelemetryData(decoder.suspensionTravel.Float(0)));
                telemetry.telemetry["FRSuspensionTravel"].Add(new TelemetryData(decoder.suspensionTravel.Float(1)));
                telemetry.telemetry["RLSuspensionTravel"].Add(new TelemetryData(decoder.suspensionTravel.Float(2)));
                telemetry.telemetry["RRSuspensionTravel"].Add(new TelemetryData(decoder.suspensionTravel.Float(3)));

                telemetry.telemetry["FLSuspensionVelocity"].Add(new TelemetryData(decoder.suspensionVelocity.Float(0)));
                telemetry.telemetry["FRSuspensionVelocity"].Add(new TelemetryData(decoder.suspensionVelocity.Float(1)));
                telemetry.telemetry["RLSuspensionVelocity"].Add(new TelemetryData(decoder.suspensionVelocity.Float(2)));
                telemetry.telemetry["RRSuspensionVelocity"].Add(new TelemetryData(decoder.suspensionVelocity.Float(3)));

                telemetry.telemetry["FLWear"].Add(new TelemetryData(decoder.tyreWear.Int(0)));
                telemetry.telemetry["FRWear"].Add(new TelemetryData(decoder.tyreWear.Int(1)));
                telemetry.telemetry["RLWear"].Add(new TelemetryData(decoder.tyreWear.Int(2)));
                telemetry.telemetry["RRWear"].Add(new TelemetryData(decoder.tyreWear.Int(3)));

                telemetry.telemetry["FLRPS"].Add(new TelemetryData(decoder.tyreRPS.Float(0)));
                telemetry.telemetry["FRRPS"].Add(new TelemetryData(decoder.tyreRPS.Float(1)));
                telemetry.telemetry["RLRPS"].Add(new TelemetryData(decoder.tyreRPS.Float(2)));
                telemetry.telemetry["RRRPS"].Add(new TelemetryData(decoder.tyreRPS.Float(3)));


                telemetry.telemetry["WaterTemp"].Add(new TelemetryData(decoder.waterTempCelsius.Int()));

                if (decoder.gearNumGears.Gear() == 1)
                {
                    telemetry.telemetry["rpmGear1"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear1"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear1"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
                if (decoder.gearNumGears.Gear() == 2)
                {
                    telemetry.telemetry["rpmGear2"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear2"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear2"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
                if (decoder.gearNumGears.Gear() == 3)
                {
                    telemetry.telemetry["rpmGear3"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear3"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear3"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
                if (decoder.gearNumGears.Gear() == 4)
                {
                    telemetry.telemetry["rpmGear4"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear4"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear4"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
                if (decoder.gearNumGears.Gear() == 5)
                {
                    telemetry.telemetry["rpmGear5"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear5"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear5"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
                if (decoder.gearNumGears.Gear() == 6)
                {
                    telemetry.telemetry["rpmGear6"].Add(new TelemetryData(decoder.rpm.Int()));
                    telemetry.telemetry["torqueGear6"].Add(new TelemetryData(decoder.engineTorque.Float()));
                    telemetry.telemetry["engSpeedGear6"].Add(new TelemetryData(decoder.engineSpeed.Float()));
                }
            }
        }

        public void Clear()
        {
            telemetry.Clear();
        }

        public RecordedData RecordedData()
        {
            return new RecordedData();
        }

        public TelemetryMap RecordedMap()
        {
            return telemetry;
        }
    }
}
