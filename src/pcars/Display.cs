using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{
    public class GearData
    {
        public int rpm;
        public List<float> torque;
        public List<float> engSpeed;

        public GearData()
        {
            torque = new List<float>();
            engSpeed = new List<float>();
        }
    }

    public class Display : IDisplay
    {
        string fileName;

        public Display()
        {
            fileName = string.Empty;
        }

        public void DisplayTelemetry(IRecord record)
        {
            var recordedData = record.RecordedData();

            if (recordedData.telemetry.Count == 0)
            {
                return;
            }

            int amount = recordedData.telemetry.Count;

            int maxAirPressureFL = 0;
            int maxAirPressureFR = 0;
            int maxAirPressureRL = 0;
            int maxAirPressureRR = 0;

            int brakeTempFL = 0;
            int brakeTempFR = 0;
            int brakeTempRL = 0;
            int brakeTempRR = 0;

            int tyreWearFL = 0;
            int tyreWearFR = 0;
            int tyreWearRL = 0;
            int tyreWearRR = 0;

            int tyreTempFL = 0;
            int tyreTempFR = 0;
            int tyreTempRL = 0;
            int tyreTempRR = 0;

            int tyreTreadFL = 0;
            int tyreTreadFR = 0;
            int tyreTreadRL = 0;
            int tyreTreadRR = 0;

            int FLLeft = 0, FLCentre = 0, FLRight = 0;
            int FRLeft = 0, FRCentre = 0, FRRight = 0;
            int RLLeft = 0, RLCentre = 0, RLRight = 0;
            int RRLeft = 0, RRCentre = 0, RRRight = 0;

            int avgFLLeft = 0, avgFLCentre = 0, avgFLRight = 0;
            int avgFRLeft = 0, avgFRCentre = 0, avgFRRight = 0;
            int avgRLLeft = 0, avgRLCentre = 0, avgRLRight = 0;
            int avgRRLeft = 0, avgRRCentre = 0, avgRRRight = 0;

            float FLHeight = 1000;
            float FRHeight = 1000;
            float RLHeight = 1000;
            float RRHeight = 1000;

            int maxFLSupHeight = 0;
            int maxFRSupHeight = 0;
            int maxRLSupHeight = 0;
            int maxRRSupHeight = 0;

            int minFLSupHeight = 1000;
            int minFRSupHeight = 1000;
            int minRLSupHeight = 1000;
            int minRRSupHeight = 1000;

            float topSpeed = 0;

            var maxrpm = recordedData.telemetry[0].maxrpm;
            var gearData = new List<GearData>();

            for (int i = 0; i < recordedData.telemetry[0].numgear; ++i)
            {
                gearData.Add(new GearData());
            }

            foreach (var item in recordedData.telemetry)
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
                if (brakeTempFL < item.brakeTempFL)
                {
                    brakeTempFL = item.brakeTempFL;
                }
                if (brakeTempFR < item.brakeTempFR)
                {
                    brakeTempFR = item.brakeTempFR;
                }
                if (brakeTempRL < item.brakeTempRL)
                {
                    brakeTempRL = item.brakeTempRL;
                }
                if (brakeTempRR < item.brakeTempRR)
                {
                    brakeTempRR = item.brakeTempRR;
                }
                if (topSpeed < item.speed)
                {
                    topSpeed = item.speed;
                }

                if (FLLeft < item.FLLeft)
                {
                    FLLeft = item.FLLeft;
                }
                if (FLCentre < item.FLCentre)
                {
                    FLCentre = item.FLCentre;
                }
                if (FLRight < item.FLRight)
                {
                    FLRight = item.FLRight;
                }

                if (FRLeft < item.FRLeft)
                {
                    FRLeft = item.FRLeft;
                }
                if (FRCentre < item.FRCentre)
                {
                    FRCentre = item.FRCentre;
                }
                if (FRRight < item.FRRight)
                {
                    FRRight = item.FRRight;
                }

                if (RLLeft < item.RLLeft)
                {
                    RLLeft = item.RLLeft;
                }
                if (RLCentre < item.RLCentre)
                {
                    RLCentre = item.RLCentre;
                }
                if (RLRight < item.RLRight)
                {
                    RLRight = item.RLRight;
                }

                if (RRLeft < item.RRLeft)
                {
                    RRLeft = item.RRLeft;
                }
                if (RRCentre < item.RRCentre)
                {
                    RRCentre = item.RRCentre;
                }
                if (RRRight < item.RRRight)
                {
                    RRRight = item.RRRight;
                }



                avgFLLeft += item.FLLeft;
                avgFLCentre += item.FLCentre;
                avgFLRight += item.FLRight;
                avgFRLeft += item.FRLeft;
                avgFRCentre += item.FRCentre;
                avgFRRight += item.FRRight;
                avgRLLeft += item.RLLeft;
                avgRLCentre += item.RLCentre;
                avgRLRight += item.RLRight;
                avgRRLeft += item.RRLeft;
                avgRRCentre += item.RRCentre;
                avgRRRight += item.RRRight;

                tyreTreadFL += item.tyreTreadFL;
                tyreTreadFR += item.tyreTreadFR;
                tyreTreadRL += item.tyreTreadRL;
                tyreTreadRR += item.tyreTreadRR;

                if (FLHeight > item.FLHeight)
                {
                    FLHeight = item.FLHeight;
                }

                if (FRHeight > item.FRHeight)
                {
                    FRHeight = item.FRHeight;
                }

                if (RLHeight > item.RLHeight)
                {
                    RLHeight = item.RLHeight;
                }

                if (RRHeight > item.RRHeight)
                {
                    RRHeight = item.RRHeight;
                }

                if (minFLSupHeight > item.FLSupHeight)
                {
                    minFLSupHeight = item.FLSupHeight;
                }

                if (minFRSupHeight > item.FRSupHeight)
                {
                    minFRSupHeight = item.FRSupHeight;
                }

                if (minRLSupHeight > item.RLSupHeight)
                {
                    minRLSupHeight = item.RLSupHeight;
                }

                if (minRRSupHeight > item.RRSupHeight)
                {
                    minRRSupHeight = item.RRSupHeight;
                }


                if (maxFLSupHeight < item.FLSupHeight)
                {
                    maxFLSupHeight = item.FLSupHeight;
                }

                if (maxFRSupHeight < item.FRSupHeight)
                {
                    maxFRSupHeight = item.FRSupHeight;
                }

                if (maxRLSupHeight < item.RLSupHeight)
                {
                    maxRLSupHeight = item.RLSupHeight;
                }

                if (maxRRSupHeight < item.RRSupHeight)
                {
                    maxRRSupHeight = item.RRSupHeight;
                }

                if (item.gear != 0 && item.gear <= gearData.Count)
                {
                    if (gearData[item.gear - 1].rpm < item.rpm)
                    {
                        gearData[item.gear - 1].rpm = item.rpm;
                    }

                    gearData[item.gear - 1].torque.Add(item.torque);
                    gearData[item.gear - 1].engSpeed.Add(item.engSpeed);
                }
            }

            tyreWearFL = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreWearFL;
            tyreWearFR = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreWearFR;
            tyreWearRL = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreWearRL;
            tyreWearRR = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreWearRR;

            tyreTempFL = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreTempFL;
            tyreTempFR = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreTempFR;
            tyreTempRL = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreTempRL;
            tyreTempRR = recordedData.telemetry[recordedData.telemetry.Count - 1].tyreTempRR;


            string trackLocation = string.Empty;
            string trackVariation = string.Empty;

            foreach (var item in recordedData.raceInfos)
            {
                trackLocation = item.trackLocation;
                trackVariation = item.trackVariation;
                fileName = trackLocation + "_" + trackVariation + ".bin";
            }




            //if (fileName.Length > 0)
            //{
            //    if (File.Exists(fileName))
            //    {
            //        Console.WriteLine("Reading saved file");
            //        Stream openFileStream = File.OpenRead(fileName);
            //        BinaryFormatter deserializer = new BinaryFormatter();
            //        RecordedData savedData = (RecordedData)deserializer.Deserialize(openFileStream);

            //        int maxAirPressureFLSaved = 0;
            //        int maxAirPressureFRSaved = 0;
            //        int maxAirPressureRLSaved = 0;
            //        int maxAirPressureRRSaved = 0;

            //        float topSpeedSaved = 0;


            //        foreach (var item in savedData.telemetry)
            //        {
            //            if (maxAirPressureFLSaved < item.airPressureFL)
            //            {
            //                maxAirPressureFLSaved = item.airPressureFL;
            //            }
            //            if (maxAirPressureFRSaved < item.airPressureFR)
            //            {
            //                maxAirPressureFRSaved = item.airPressureFR;
            //            }
            //            if (maxAirPressureRLSaved < item.airPressureRL)
            //            {
            //                maxAirPressureRLSaved = item.airPressureRL;
            //            }
            //            if (maxAirPressureRRSaved < item.airPressureRR)
            //            {
            //                maxAirPressureRRSaved = item.airPressureRR;
            //            }
            //            if (topSpeedSaved < item.speed)
            //            {
            //                topSpeedSaved = item.speed;
            //            }
            //        }


            //        string trackLocationSaved = string.Empty;
            //        string trackVariationSaved = string.Empty;

            //        foreach (var item in recordedData.raceInfos)
            //        {
            //            trackLocationSaved = item.trackLocation;
            //            trackVariationSaved = item.trackVariation;
            //            fileName = trackLocationSaved + "_" + trackVariationSaved + ".bin";
            //        }


            //        Console.WriteLine("Track Locatioin " + trackLocationSaved);
            //        Console.WriteLine("Track Variation " + trackVariationSaved);

            //        Console.WriteLine("Max Air Pressure");
            //        Console.WriteLine("   FL " + ((decimal)maxAirPressureFLSaved / 100));
            //        Console.WriteLine("   FR " + ((decimal)maxAirPressureFRSaved / 100));
            //        Console.WriteLine("   RL " + ((decimal)maxAirPressureRLSaved / 100));
            //        Console.WriteLine("   RR " + ((decimal)maxAirPressureRRSaved / 100));

            //        Console.WriteLine("Top Speed " + topSpeedSaved);

            //        openFileStream.Close();
            //    }
            //    Stream SaveFileStream = File.Create(fileName);
            //    BinaryFormatter serializer = new BinaryFormatter();
            //    serializer.Serialize(SaveFileStream, recordedData);
            //    SaveFileStream.Close();
            //}
            record.Clear();

            Console.WriteLine("Track Locatioin " + trackLocation);
            Console.WriteLine("Track Variation " + trackVariation);

            Console.WriteLine("Max Brake Temp");
            Console.WriteLine("   FL " + ((decimal)brakeTempFL));
            Console.WriteLine("   FR " + ((decimal)brakeTempFR));
            Console.WriteLine("   RL " + ((decimal)brakeTempRL));
            Console.WriteLine("   RR " + ((decimal)brakeTempRR));


            Console.WriteLine("Max Air Pressure");
            Console.WriteLine("   FL " + ((decimal)maxAirPressureFL / 100));
            Console.WriteLine("   FR " + ((decimal)maxAirPressureFR / 100));
            Console.WriteLine("   RL " + ((decimal)maxAirPressureRL / 100));
            Console.WriteLine("   RR " + ((decimal)maxAirPressureRR / 100));

            Console.WriteLine("Tyre Wear");
            Console.WriteLine("   FL " + (tyreWearFL));
            Console.WriteLine("   FR " + (tyreWearFR));
            Console.WriteLine("   RL " + (tyreWearRL));
            Console.WriteLine("   RR " + (tyreWearRR));

            Console.WriteLine("Tyre Temp");
            Console.WriteLine("   FL " + (tyreTempFL));
            Console.WriteLine("   FR " + (tyreTempFR));
            Console.WriteLine("   RL " + (tyreTempRL));
            Console.WriteLine("   RR " + (tyreTempRR));

            Console.WriteLine("Tyre Tread Avg Temp");
            Console.WriteLine("   FL " + (tyreTreadFL / amount));
            Console.WriteLine("   FR " + (tyreTreadFR / amount));
            Console.WriteLine("   RL " + (tyreTreadRL / amount));
            Console.WriteLine("   RR " + (tyreTreadRR / amount));

            Console.WriteLine("Tyre Max Left Centre Right Temp");
            Console.WriteLine("   FL " + FLLeft + " " + FLCentre + " " + FLRight +
                              "   FR " + FRLeft + " " + FRCentre + " " + FRRight);
            Console.WriteLine("   RL " + RLLeft + " " + RLCentre + " " + RLRight +
                              "   RR " + RRLeft + " " + RRCentre + " " + RRRight);

            Console.WriteLine("Tyre Avg Left Centre Right Temp");
            Console.WriteLine("   FL " + avgFLLeft / amount + " " + avgFLCentre / amount + " " + avgFLRight / amount+
                              "   FR " + avgFRLeft / amount + " " + avgFRCentre / amount + " " + avgFRRight / amount);
            Console.WriteLine("   RL " + avgRLLeft / amount + " " + avgRLCentre / amount + " " + avgRLRight / amount+
                              "   RR " + avgRRLeft / amount + " " + avgRRCentre / amount + " " + avgRRRight / amount);

            Console.WriteLine("Min Ride Height");
            Console.WriteLine("   FL " + (FLHeight));
            Console.WriteLine("   FR " + (FRHeight));
            Console.WriteLine("   RL " + (RLHeight));
            Console.WriteLine("   RR " + (RRHeight));

            Console.WriteLine("Min Suspension Ride Height");
            Console.WriteLine("   FL " + (minFLSupHeight));
            Console.WriteLine("   FR " + (minFRSupHeight));
            Console.WriteLine("   RL " + (minRLSupHeight));
            Console.WriteLine("   RR " + (minRRSupHeight));

            Console.WriteLine("Max Suspension Ride Height");
            Console.WriteLine("   FL " + (maxFLSupHeight));
            Console.WriteLine("   FR " + (maxFRSupHeight));
            Console.WriteLine("   RL " + (maxRLSupHeight));
            Console.WriteLine("   RR " + (maxRRSupHeight));

            int gear = 0;

            foreach(var i in gearData)
            {
                float average = 0;
                float aveengspeed = 0;

                foreach(var j in i.torque)
                {
                    average += j;
                }

                foreach (var j in i.engSpeed)
                {
                    aveengspeed += j;
                }

                Console.WriteLine("Gear " + ++gear + " Max RPM " + i.rpm + "/" + maxrpm
                                  + " Avg Torque "   + (average / i.torque.Count)
                                  + " Avg EngSpeed " + (aveengspeed / i.engSpeed.Count));
            }

            Console.WriteLine("Top Speed " + topSpeed);
        }
    }
}
