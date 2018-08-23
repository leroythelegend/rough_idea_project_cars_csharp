using System;
namespace pcars
{
    public interface IDisplay
    {
        void DisplayTelemetry(IRecord record);
    }
}
