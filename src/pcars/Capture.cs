using System;
namespace pcars
{
    public class Capture
    {
        ICaptureState state;

        public Capture(IRecord record, IDisplay display)
        {
            state = new GameFrontEndState(record, display);
        }

        public void CapturePacket(PacketDecoder packet)
        {
            state.Capture(this, packet);
        }

        public void NextState(ICaptureState captureState)
        {
            state = captureState;
        }
    }
}
