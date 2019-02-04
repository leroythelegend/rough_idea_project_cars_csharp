using System;
namespace pcars
{
    public class TelemetryData
    {
        public int i;
        public float f;

        public TelemetryData(int i)
        {
            this.i = i;
            this.f = (float)i;
        }

        public TelemetryData(float f)
        {
            this.i = (int)f;
            this.f = f;
        }

        public int Int()
        {
            return i;
        }

        public float Float()
        {
            return f;
        }
    }
}
