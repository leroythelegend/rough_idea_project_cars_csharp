using System;
namespace pcars
{
    public interface ICaptureState
    {
        void Capture(Capture capture, PacketDecoder packet);

        void Next(Capture capture, ICaptureState captureState);
    }
}
