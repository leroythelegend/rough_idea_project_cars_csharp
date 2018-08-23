using System;
using System.Collections.Generic;

namespace pcars
{
    public class Display : IDisplay
    {
        public void DisplayTelemetry(IRecord record)
        {
            var telemetry = record.Telemetry();

            int maxAirPressureFL = 0;
            int maxAirPressureFR = 0;
            int maxAirPressureRL = 0;
            int maxAirPressureRR = 0;


            foreach (var item in telemetry)
            {
                if (maxAirPressureFL < item.airPressureFL)
                {
                    maxAirPressureFL = item.airPressureFL;
                }
                if (maxAirPressureFR < item.airPressureFR)
                {
                    maxAirPressureFR = item.airPressureFR;
                }
                if (maxAirPressureRL < item.airPressureRL)
                {
                    maxAirPressureRL = item.airPressureRL;
                }
                if (maxAirPressureRR < item.airPressureRR)
                {
                    maxAirPressureRR = item.airPressureRR;
                }
            }

            record.Clear();

            Console.WriteLine("Max Air Pressure");
            Console.WriteLine("   FL " + ((decimal)maxAirPressureFL / 100));
            Console.WriteLine("   FR " + ((decimal)maxAirPressureFR / 100));
            Console.WriteLine("   RL " + ((decimal)maxAirPressureRL / 100));
            Console.WriteLine("   RR " + ((decimal)maxAirPressureRR / 100));
        }
    }
}
