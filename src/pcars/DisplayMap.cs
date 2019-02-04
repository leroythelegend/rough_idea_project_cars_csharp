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

            Console.WriteLine("Max Speed " + telemetry.MaxInt("speed"));

            Console.WriteLine("Max Steering Left " + telemetry.MinInt("steering"));
            Console.WriteLine("Max Steering Right " + telemetry.MaxInt("steering"));


            Console.WriteLine("Gear 1" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear1")
                              + "/" + telemetry.OneInt("maxRpm")
                              + " Avg Torque "   + telemetry.AvgFloat("torqueGear1")
                              + " Avg EngSpeed " + telemetry.AvgFloat("engSpeedGear1"));


            Console.WriteLine("Gear 2" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear2")
                              + "/" + telemetry.OneInt("maxRpm")
                              + " Avg Torque " + telemetry.AvgFloat("torqueGear2")
                              + " Avg EngSpeed " + telemetry.AvgFloat("engSpeedGear2"));


            Console.WriteLine("Gear 3" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear3")
                              + "/" + telemetry.OneInt("maxRpm")
                              + " Avg Torque " + telemetry.AvgFloat("torqueGear3")
                              + " Avg EngSpeed " + telemetry.AvgFloat("engSpeedGear3"));


            Console.WriteLine("Gear 4" + " RPM/MAX_RPM " + telemetry.MaxInt("rpmGear4")
                              + "/" + telemetry.OneInt("maxRpm")
                              + " Avg Torque " + telemetry.AvgFloat("torqueGear4")
                              + " Avg EngSpeed " + telemetry.AvgFloat("engSpeedGear4"));

            telemetry.Clear();
        }
    }
}
