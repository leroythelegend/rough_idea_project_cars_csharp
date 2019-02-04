using System;
using System.Collections.Generic;

namespace pcars
{
    public class TelemetryMap
    {
        public Dictionary<string, List<TelemetryData>> telemetry;

        public TelemetryMap()
        {
            telemetry = new Dictionary<string, List<TelemetryData>>
            {
                { "airPressureFL", new List<TelemetryData>() },
                { "airPressureFR", new List<TelemetryData>() },
                { "airPressureRL", new List<TelemetryData>() },
                { "airPressureRR", new List<TelemetryData>() },
                { "brakeTempFL", new List<TelemetryData>() },
                { "brakeTempFR", new List<TelemetryData>() },
                { "brakeTempRL", new List<TelemetryData>() },
                { "brakeTempRR", new List<TelemetryData>() },
                { "tyreTreadFL", new List<TelemetryData>() },
                { "tyreTreadFR", new List<TelemetryData>() },
                { "tyreTreadRL", new List<TelemetryData>() },
                { "tyreTreadRR", new List<TelemetryData>() },
                { "FLLeft", new List<TelemetryData>() },
                { "FLCentre", new List<TelemetryData>() },
                { "FLRight", new List<TelemetryData>() },
                { "FRLeft", new List<TelemetryData>() },
                { "FRCentre", new List<TelemetryData>() },
                { "FRRight", new List<TelemetryData>() },
                { "RLLeft", new List<TelemetryData>() },
                { "RLCentre", new List<TelemetryData>() },
                { "RLRight", new List<TelemetryData>() },
                { "RRLeft", new List<TelemetryData>() },
                { "RRCentre", new List<TelemetryData>() },
                { "RRRight", new List<TelemetryData>() },
                { "FLSupHeight", new List<TelemetryData>() },
                { "FRSupHeight", new List<TelemetryData>() },
                { "RLSupHeight", new List<TelemetryData>() },
                { "RRSupHeight", new List<TelemetryData>() },
                { "FLHeight", new List<TelemetryData>() },
                { "FRHeight", new List<TelemetryData>() },
                { "RLHeight", new List<TelemetryData>() },
                { "RRHeight", new List<TelemetryData>() },
                { "gear", new List<TelemetryData>() },
                { "numGear", new List<TelemetryData>() },
                { "maxRpm", new List<TelemetryData>() },
                { "rpm", new List<TelemetryData>() },
                { "torque", new List<TelemetryData>() },
                { "engSpeed", new List<TelemetryData>() },
                { "rpmGear1", new List<TelemetryData>() },
                { "torqueGear1", new List<TelemetryData>() },
                { "engSpeedGear1", new List<TelemetryData>() },
                { "rpmGear2", new List<TelemetryData>() },
                { "torqueGear2", new List<TelemetryData>() },
                { "engSpeedGear2", new List<TelemetryData>() },
                { "rpmGear3", new List<TelemetryData>() },
                { "torqueGear3", new List<TelemetryData>() },
                { "engSpeedGear3", new List<TelemetryData>() },
                { "rpmGear4", new List<TelemetryData>() },
                { "torqueGear4", new List<TelemetryData>() },
                { "engSpeedGear4", new List<TelemetryData>() },
                { "speed", new List<TelemetryData>() },
                { "steering", new List<TelemetryData>() }
            };
        }

        public int OneInt(string key)
        {
            if (telemetry[key].Count != 0)
            {
                return telemetry[key][0].Int();
            }
            return 0;
        }

        public float OneFloat(string key)
        {
            if (telemetry[key].Count != 0)
            {
                return telemetry[key][0].Float();
            }
            return 0;
        }

        public int MaxInt(string key)
        {
            int m = 0;
            foreach (var i in telemetry[key])
            {
                if (m < i.Int())
                {
                    m = i.Int();
                }
            }
            return m;
        }

        public int MinInt(string key)
        {
            int m = int.MaxValue;
            foreach (var i in telemetry[key])
            {
                if (m > i.Int())
                {
                    m = i.Int();
                }
            }
            return m;
        }

        public float MinFloat(string key)
        {
            float m = float.MaxValue;
            foreach (var i in telemetry[key])
            {
                if (m > i.Float())
                {
                    m = i.Float();
                }
            }
            return m;
        }

        public int AvgInt(string key)
        {
            if (telemetry[key].Count == 0)
            {
                return 0;
            }
            int avg = 0;
            foreach (var i in telemetry[key])
            {
                avg += i.Int();
            }
            return (avg / telemetry[key].Count);
        }

        public float AvgFloat(string key)
        {
            if (telemetry[key].Count == 0)
            {
                return 0;
            }
            float avg = 0;
            foreach (var i in telemetry[key])
            {
                avg += i.Float();
            }
            return (avg / telemetry[key].Count);
        }

        public void Clear()
        {
            telemetry["airPressureFL"].Clear();
            telemetry["airPressureFR"].Clear();
            telemetry["airPressureRL"].Clear();
            telemetry["airPressureRR"].Clear();
            telemetry["brakeTempFL"].Clear();
            telemetry["brakeTempFR"].Clear();
            telemetry["brakeTempRL"].Clear();
            telemetry["brakeTempRR"].Clear();
            telemetry["tyreTreadFL"].Clear();
            telemetry["tyreTreadFR"].Clear();
            telemetry["tyreTreadRL"].Clear();
            telemetry["tyreTreadRR"].Clear();
            telemetry["FLLeft"].Clear();
            telemetry["FLCentre"].Clear();
            telemetry["FLRight"].Clear();
            telemetry["FRLeft"].Clear();
            telemetry["FRCentre"].Clear();
            telemetry["FRRight"].Clear();
            telemetry["RLLeft"].Clear();
            telemetry["RLCentre"].Clear();
            telemetry["RLRight"].Clear();
            telemetry["RRLeft"].Clear();
            telemetry["RRCentre"].Clear();
            telemetry["RRRight"].Clear();
            telemetry["FLSupHeight"].Clear();
            telemetry["FRSupHeight"].Clear();
            telemetry["RLSupHeight"].Clear();
            telemetry["RRSupHeight"].Clear();
            telemetry["FLHeight"].Clear();
            telemetry["FRHeight"].Clear();
            telemetry["RLHeight"].Clear();
            telemetry["RRHeight"].Clear();
            telemetry["gear"].Clear();
            telemetry["numGear"].Clear();
            telemetry["maxRpm"].Clear();
            telemetry["rpm"].Clear();
            telemetry["torque"].Clear();
            telemetry["engSpeed"].Clear();
            telemetry["rpmGear1"].Clear();
            telemetry["torqueGear1"].Clear();
            telemetry["engSpeedGear1"].Clear();
            telemetry["rpmGear2"].Clear();
            telemetry["torqueGear2"].Clear();
            telemetry["engSpeedGear2"].Clear();
            telemetry["rpmGear3"].Clear();
            telemetry["torqueGear3"].Clear();
            telemetry["engSpeedGear3"].Clear();
            telemetry["rpmGear4"].Clear();
            telemetry["torqueGear4"].Clear();
            telemetry["engSpeedGear4"].Clear();
            telemetry["speed"].Clear();
            telemetry["steering"].Clear();
        }
    }
}
