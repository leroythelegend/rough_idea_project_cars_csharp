using System;
namespace pcars
{
    public class RaceDataDecoder : PacketDecoder
    {
        private readonly int TRACKNAME_LENGTH_MAX = 64;
        
        public PacketBaseDecoder packetBase;
        public FourByteDecoder worldFastestLapTime;
        public FourByteDecoder personalFastestLapTime;
        public FourByteDecoder personalFastestSector1Time;
        public FourByteDecoder personalFastestSector2Time;
        public FourByteDecoder personalFastestSector3Time;
        public FourByteDecoder worldFastestSector1Time;
        public FourByteDecoder worldFastestSector2Time;
        public FourByteDecoder worldFastestSector3Time;
        public FourByteDecoder trackLength;
        public StringMatrixDecoder trackLocation;
        public StringMatrixDecoder trackVariation;
        public StringMatrixDecoder translatedTrackLocation;
        public StringMatrixDecoder translatedTrackVariation;
        public LapsTimeInEvent lapsTimeInEvent;
        public OneByteDecoder enforcedPitStopLap;

        public RaceDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            worldFastestLapTime = new FourByteDecoder();
            personalFastestLapTime = new FourByteDecoder();
            personalFastestSector1Time = new FourByteDecoder();
            personalFastestSector2Time = new FourByteDecoder();
            personalFastestSector3Time = new FourByteDecoder();
            worldFastestSector1Time = new FourByteDecoder();
            worldFastestSector2Time = new FourByteDecoder();
            worldFastestSector3Time = new FourByteDecoder();
            trackLength = new FourByteDecoder();
            trackLocation = new StringMatrixDecoder(1, TRACKNAME_LENGTH_MAX);
            trackVariation = new StringMatrixDecoder(1, TRACKNAME_LENGTH_MAX);
            translatedTrackLocation = new StringMatrixDecoder(1, TRACKNAME_LENGTH_MAX);
            translatedTrackVariation = new StringMatrixDecoder(1, TRACKNAME_LENGTH_MAX);
            lapsTimeInEvent = new LapsTimeInEvent(); // need to test this in binary
            enforcedPitStopLap = new OneByteDecoder();

            base.Add(packetBase);
            base.Add(worldFastestLapTime);
            base.Add(personalFastestLapTime);
            base.Add(personalFastestSector1Time);
            base.Add(personalFastestSector2Time);
            base.Add(personalFastestSector3Time);
            base.Add(worldFastestSector1Time);
            base.Add(worldFastestSector2Time);
            base.Add(worldFastestSector3Time);
            base.Add(trackLength);
            base.Add(trackLocation);
            base.Add(trackVariation);
            base.Add(translatedTrackLocation);
            base.Add(translatedTrackVariation);
            base.Add(lapsTimeInEvent);
            base.Add(enforcedPitStopLap);
        }
    }
}
