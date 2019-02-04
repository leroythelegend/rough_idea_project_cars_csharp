using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{
    public class Record : IRecord
    {
        readonly RecordedData recordedData;
        
        public Record()
        {
            recordedData = new RecordedData();
        }

        public void RecordTelemetry(PacketDecoder packet)
        {
            if (packet.GetType().Name == "TelemetryDataDecoder")
            {
                var decoder = (TelemetryDataDecoder)packet;

                var item = new Telemetry
                {
                    airPressureFL = decoder.airPressure.Int(0),
                    airPressureFR = decoder.airPressure.Int(1),
                    airPressureRL = decoder.airPressure.Int(2),
                    airPressureRR = decoder.airPressure.Int(3),

                    brakeTempFL = decoder.brakeTempCelsius.Int(0),
                    brakeTempFR = decoder.brakeTempCelsius.Int(1),
                    brakeTempRL = decoder.brakeTempCelsius.Int(2),
                    brakeTempRR = decoder.brakeTempCelsius.Int(3),

                    tyreWearFL = decoder.tyreWear.Int(0),
                    tyreWearFR = decoder.tyreWear.Int(1),
                    tyreWearRL = decoder.tyreWear.Int(2),
                    tyreWearRR = decoder.tyreWear.Int(3),

                    tyreTempFL = decoder.tyreTemp.Int(0),
                    tyreTempFR = decoder.tyreTemp.Int(1),
                    tyreTempRL = decoder.tyreTemp.Int(2),
                    tyreTempRR = decoder.tyreTemp.Int(3),

                    tyreTreadFL = decoder.tyreTreadTemp.Int(0),
                    tyreTreadFR = decoder.tyreTreadTemp.Int(1),
                    tyreTreadRL = decoder.tyreTreadTemp.Int(2),
                    tyreTreadRR = decoder.tyreTreadTemp.Int(3),

                    FLLeft = decoder.tyreTempLeft.Int(0),
                    FRLeft = decoder.tyreTempLeft.Int(1),
                    RLLeft = decoder.tyreTempLeft.Int(2),
                    RRLeft = decoder.tyreTempLeft.Int(3),

                    FLCentre = decoder.tyreTempCenter.Int(0),
                    FRCentre = decoder.tyreTempCenter.Int(1),
                    RLCentre = decoder.tyreTempCenter.Int(2),
                    RRCentre = decoder.tyreTempCenter.Int(3),

                    FLRight = decoder.tyreTempRight.Int(0),
                    FRRight = decoder.tyreTempRight.Int(1),
                    RLRight = decoder.tyreTempRight.Int(2),
                    RRRight = decoder.tyreTempRight.Int(3),

                    FLHeight = decoder.rideHeight.Float(0),
                    FRHeight = decoder.rideHeight.Float(1),
                    RLHeight = decoder.rideHeight.Float(2),
                    RRHeight = decoder.rideHeight.Float(3),


                    FLSupHeight = decoder.suspensionRideHeight.Int(0),
                    FRSupHeight = decoder.suspensionRideHeight.Int(1),
                    RLSupHeight = decoder.suspensionRideHeight.Int(2),
                    RRSupHeight = decoder.suspensionRideHeight.Int(3),


                    rpm = decoder.rpm.Int(),
                    maxrpm = decoder.maxRpm.Int(),
                    gear = (int)decoder.gearNumGears.Gear(),
                    numgear = (int)decoder.gearNumGears.NumGears(),
                    torque = decoder.engineTorque.Float(),
                    engSpeed = decoder.engineSpeed.Float(),

                    speed = decoder.speed.Float()
                };

                recordedData.telemetry.Add(item);
            }

            if (packet.GetType().Name == "RaceDataDecoder")
            {
                var decoder = (RaceDataDecoder)packet;

                var item = new RaceInfo
                {
                    trackLocation = decoder.trackLocation.String(0),
                    trackVariation = decoder.trackVariation.String(0)
                };

                recordedData.raceInfos.Add(item);
            }
        }

        public void Clear()
        {
            recordedData.Clear();
        }

        public RecordedData RecordedData()
        {
            return recordedData;   
        }

        public TelemetryMap RecordedMap()
        {
            return new TelemetryMap();
        }
    }
}
