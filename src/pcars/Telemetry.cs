using System;
namespace pcars
{
    [Serializable()]
    public struct Telemetry
    {
        public int airPressureFL;
        public int airPressureFR;
        public int airPressureRL;
        public int airPressureRR;

        public int brakeTempFL;
        public int brakeTempFR;
        public int brakeTempRL;
        public int brakeTempRR;

        public int tyreWearFL;
        public int tyreWearFR;
        public int tyreWearRL;
        public int tyreWearRR;

        public int tyreTempFL;
        public int tyreTempFR;
        public int tyreTempRL;
        public int tyreTempRR;

        public int tyreTreadFL;
        public int tyreTreadFR;
        public int tyreTreadRL;
        public int tyreTreadRR;

        public int FLLeft, FLCentre, FLRight;
        public int FRLeft, FRCentre, FRRight;
        public int RLLeft, RLCentre, RLRight;
        public int RRLeft, RRCentre, RRRight;

        public float FLHeight;
        public float FRHeight;
        public float RLHeight;
        public float RRHeight;

        public int FLSupHeight;
        public int FRSupHeight;
        public int RLSupHeight;
        public int RRSupHeight;


        public int rpm;
        public int maxrpm;
        public int gear;
        public int numgear;
        public float torque;
        public float engSpeed;

        public float speed;
    }
}
