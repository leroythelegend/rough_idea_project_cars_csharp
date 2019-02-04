using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{

    public class DisplayMap : IDisplay
    {
        public DisplayMap()
        {
        }

        public void DisplayTelemetry(IRecord record)
        {
            TelemetryMap telemetry = record.RecordedMap();

            if (telemetry.telemetry["brakeTempFL"].Count == 0)
            {
                return;
            }

            Console.WriteLine("Max Brake Temp");
            Console.WriteLine("   FL " + telemetry.MaxInt("brakeTempFL"));
            Console.WriteLine("   FR " + telemetry.MaxInt("brakeTempFR"));
            Console.WriteLine("   RL " + telemetry.MaxInt("brakeTempRL"));
            Console.WriteLine("   RR " + telemetry.MaxInt("brakeTempRR"));

            Console.WriteLine("Max Air Pressure");
            Console.WriteLine("   FL " + ((decimal)telemetry.MaxInt("airPressureFL") / 100));
            Console.WriteLine("   FR " + ((decimal)telemetry.MaxInt("airPressureFR") / 100));
            Console.WriteLine("   RL " + ((decimal)telemetry.MaxInt("airPressureRL") / 100));
            Console.WriteLine("   RR " + ((decimal)telemetry.MaxInt("airPressureRR") / 100));

            Console.WriteLine("Tyre Tread Avg Temp");
            Console.WriteLine("   FL " + (telemetry.AvgInt("tyreTreadFL")));
            Console.WriteLine("   FR " + (telemetry.AvgInt("tyreTreadFR")));
            Console.WriteLine("   RL " + (telemetry.AvgInt("tyreTreadRL")));
            Console.WriteLine("   RR " + (telemetry.AvgInt("tyreTreadRR")));

            Console.WriteLine("Tyre Carcass Avg Temp");
            Console.WriteLine("   FL " + (telemetry.AvgInt("tyreCarcassFL")));
            Console.WriteLine("   FR " + (telemetry.AvgInt("tyreCarcassFR")));
            Console.WriteLine("   RL " + (telemetry.AvgInt("tyreCarcassRL")));
            Console.WriteLine("   RR " + (telemetry.AvgInt("tyreCarcassRR")));

            Console.WriteLine("Tyre Layer Avg Temp");
            Console.WriteLine("   FL " + (telemetry.AvgInt("tyreLayerFL")));
            Console.WriteLine("   FR " + (telemetry.AvgInt("tyreLayerFR")));
            Console.WriteLine("   RL " + (telemetry.AvgInt("tyreLayerRL")));
            Console.WriteLine("   RR " + (telemetry.AvgInt("tyreLayerRR")));

            Console.WriteLine("Tyre Rim Avg Temp");
            Console.WriteLine("   FL " + (telemetry.AvgInt("tyreRimFL")));
            Console.WriteLine("   FR " + (telemetry.AvgInt("tyreRimFR")));
            Console.WriteLine("   RL " + (telemetry.AvgInt("tyreRimRL")));
            Console.WriteLine("   RR " + (telemetry.AvgInt("tyreRimRR")));

            Console.WriteLine("Tyre Avg Temp");
            Console.WriteLine("   FL " + (telemetry.AvgUInt("tyreTempFL")));
            Console.WriteLine("   FR " + (telemetry.AvgUInt("tyreTempFR")));
            Console.WriteLine("   RL " + (telemetry.AvgUInt("tyreTempRL")));
            Console.WriteLine("   RR " + (telemetry.AvgUInt("tyreTempRR")));

            Console.WriteLine("Tyre Wear");
            Console.WriteLine("   FL " + (telemetry.MaxInt("FLWear")));
            Console.WriteLine("   FR " + (telemetry.MaxInt("FRWear")));
            Console.WriteLine("   RL " + (telemetry.MaxInt("RLWear")));
            Console.WriteLine("   RR " + (telemetry.MaxInt("RRWear")));

            Console.WriteLine("Tyre Avg Left Centre Right Temp");
            Console.WriteLine("   FL " + telemetry.AvgInt("FLLeft") + " " + telemetry.AvgInt("FLCentre") + " " + telemetry.AvgInt("FLRight") +
                              "   FR " + telemetry.AvgInt("FRLeft") + " " + telemetry.AvgInt("FRCentre") + " " + telemetry.AvgInt("FRRight"));
            Console.WriteLine("   RL " + telemetry.AvgInt("RLLeft") + " " + telemetry.AvgInt("RLCentre") + " " + telemetry.AvgInt("RLRight") +
                              "   RR " + telemetry.AvgInt("RRLeft") + " " + telemetry.AvgInt("RRCentre") + " " + telemetry.AvgInt("RRRight"));

            Console.WriteLine("Min Suspension Ride Height");
            Console.WriteLine("   FL " + (telemetry.MinInt("FLSupHeight")));
            Console.WriteLine("   FR " + (telemetry.MinInt("FRSupHeight")));
            Console.WriteLine("   RL " + (telemetry.MinInt("RLSupHeight")));
            Console.WriteLine("   RR " + (telemetry.MinInt("RRSupHeight")));

            Console.WriteLine("Max Suspension Ride Height");
            Console.WriteLine("   FL " + (telemetry.MaxInt("FLSupHeight")));
            Console.WriteLine("   FR " + (telemetry.MaxInt("FRSupHeight")));
            Console.WriteLine("   RL " + (telemetry.MaxInt("RLSupHeight")));
            Console.WriteLine("   RR " + (telemetry.MaxInt("RRSupHeight")));

            Console.WriteLine("Min Ride Height");
            Console.WriteLine("   FL " + (telemetry.MinFloat("FLHeight")));
            Console.WriteLine("   FR " + (telemetry.MinFloat("FRHeight")));
            Console.WriteLine("   RL " + (telemetry.MinFloat("RLHeight")));
            Console.WriteLine("   RR " + (telemetry.MinFloat("RRHeight")));

            Console.WriteLine("Avg Suspension Travel");
            Console.WriteLine("   FL " + (telemetry.AvgFloat("FLSuspensionTravel")));
            Console.WriteLine("   FR " + (telemetry.AvgFloat("FRSuspensionTravel")));
            Console.WriteLine("   RL " + (telemetry.AvgFloat("RLSuspensionTravel")));
            Console.WriteLine("   RR " + (telemetry.AvgFloat("RRSuspensionTravel")));

            Console.WriteLine("Avg Suspension Velocity");
            Console.WriteLine("   FL " + (telemetry.AvgFloat("FLSuspensionVelocity")));
            Console.WriteLine("   FR " + (telemetry.AvgFloat("FRSuspensionVelocity")));
            Console.WriteLine("   RL " + (telemetry.AvgFloat("RLSuspensionVelocity")));
            Console.WriteLine("   RR " + (telemetry.AvgFloat("RRSuspensionVelocity")));

            Console.WriteLine("Avg Tyre RPS");
            Console.WriteLine("   FL " + (telemetry.AvgFloat("FLRPS")));
            Console.WriteLine("   FR " + (telemetry.AvgFloat("FRRPS")));
            Console.WriteLine("   RL " + (telemetry.AvgFloat("RLRPS")));
            Console.WriteLine("   RR " + (telemetry.AvgFloat("RRRPS")));

            Console.WriteLine("Max Speed " + telemetry.MaxFloat("speed"));

            Console.WriteLine("Max Water Temp " + telemetry.MaxInt("WaterTemp"));

            Console.WriteLine("Max Steering Left " + telemetry.MinInt("steering"));
            Console.WriteLine("Max Steering Right " + telemetry.MaxInt("steering"));


            Console.WriteLine("Gear 1" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear1")
                              + "/" + telemetry.OneInt("maxRpm") + "\n"
                              + "   Avg RPM         " + telemetry.AvgInt("rpmGear1") + "\n"
                              + "   Avg Torque      " + telemetry.AvgFloat("torqueGear1") + "\n"
                              + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear1") * (telemetry.AvgFloat("torqueGear1"))) / 5252)) + "\n"
                              + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear1"));
            
            Console.WriteLine("Gear 2" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear2")
                   + "/" + telemetry.OneInt("maxRpm") + "\n"
                   + "   Avg RPM         " + telemetry.AvgInt("rpmGear2") + "\n"
                   + "   Avg Torque      " + telemetry.AvgFloat("torqueGear2") + "\n"
                   + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear2") * (telemetry.AvgFloat("torqueGear2"))) / 5252)) + "\n"
                   + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear2"));

            Console.WriteLine("Gear 3" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear3")
                  + "/" + telemetry.OneInt("maxRpm") + "\n"
                  + "   Avg RPM         " + telemetry.AvgInt("rpmGear3") + "\n"
                  + "   Avg Torque      " + telemetry.AvgFloat("torqueGear3") + "\n"
                  + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear3") * (telemetry.AvgFloat("torqueGear3"))) / 5252)) + "\n"
                  + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear3"));
          
            Console.WriteLine("Gear 4" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear4")
                  + "/" + telemetry.OneInt("maxRpm") + "\n"
                  + "   Avg RPM         " + telemetry.AvgInt("rpmGear4") + "\n"
                  + "   Avg Torque      " + telemetry.AvgFloat("torqueGear4") + "\n"
                  + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear4") * (telemetry.AvgFloat("torqueGear4"))) / 5252)) + "\n"
                  + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear4"));

            Console.WriteLine("Gear 5" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear5")
                  + "/" + telemetry.OneInt("maxRpm") + "\n"
                  + "   Avg RPM         " + telemetry.AvgInt("rpmGear5") + "\n"
                  + "   Avg Torque      " + telemetry.AvgFloat("torqueGear5") + "\n"
                  + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear5") * (telemetry.AvgFloat("torqueGear5"))) / 5252)) + "\n"
                  + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear5"));

            Console.WriteLine("Gear 6" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear6")
                  + "/" + telemetry.OneInt("maxRpm") + "\n"
                  + "   Avg RPM         " + telemetry.AvgInt("rpmGear6") + "\n"
                  + "   Avg Torque      " + telemetry.AvgFloat("torqueGear6") + "\n"
                  + "   Avg Horse Power " + (((telemetry.AvgInt("rpmGear6") * (telemetry.AvgFloat("torqueGear6"))) / 5252)) + "\n"
                  + "   Avg EngSpeed    " + telemetry.AvgFloat("engSpeedGear6"));

            record.Clear();
        }
    }
}
