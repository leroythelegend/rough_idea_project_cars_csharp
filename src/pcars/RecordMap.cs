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
                telemetry.telemetry["speed"].Add(new TelemetryData(decoder.speed.Int()));
                telemetry.telemetry["steering"].Add(new TelemetryData(decoder.steering.Int()));

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
            }
        }

        public void Clear()
        {
            telemetry.telemetry.Clear();
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
