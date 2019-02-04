using System;
namespace pcars
{
    public class TelemetryData
    {
        public uint ui;
        public int i;
        public float f;

        public TelemetryData(int i)
        {
            this.ui = (uint)i;
            this.i = i;
            this.f = (float)i;
        }

        public TelemetryData(uint i)
        {
            this.ui = i;
            this.i = (int)i;
            this.f = (float)i;
        }

        public TelemetryData(float f)
        {
            this.ui = (uint)f;
            this.i = (int)f;
            this.f = f;
        }

        public int Int()
        {
            return i;
        }

        public uint UInt()
        {
            return ui;
        }

        public float Float()
        {
            return f;
        }
    }
}
