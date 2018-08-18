using System;
namespace pcars
{
    public class ParticipantInfoDecoder : PacketDecoder
    {
        public TwoByteArrayDecoder worldPosition;
        public TwoByteArrayDecoder orientation;
        public TwoByteDecoder currentLapDistance;
        public RacePositionDecoder racePosition;
        public SectorDecoder sector;
        public HighestFlagDecoder highestFlag;
        public PitModeScheduleDecoder pitModeSchedule;
        public TwoByteDecoder carIndex;
        public RaceStateDecoder raceState;
        public OneByteDecoder currentLap;
        public FourByteDecoder currentTime;
        public FourByteDecoder currentSectorTime;
        public TwoByteDecoder participantIndex;

        public ParticipantInfoDecoder()
        {
            worldPosition = new TwoByteArrayDecoder(3);
            orientation = new TwoByteArrayDecoder(3);
            currentLapDistance = new TwoByteDecoder();
            racePosition = new RacePositionDecoder();
            sector = new SectorDecoder();
            highestFlag = new HighestFlagDecoder();
            pitModeSchedule = new PitModeScheduleDecoder();
            carIndex = new TwoByteDecoder();
            raceState = new RaceStateDecoder();
            currentLap = new OneByteDecoder();
            currentTime = new FourByteDecoder();
            currentSectorTime = new FourByteDecoder();
            participantIndex = new TwoByteDecoder();

            Add(worldPosition);
            Add(orientation);
            Add(currentLapDistance);
            Add(racePosition);
            Add(sector);
            Add(highestFlag);
            Add(pitModeSchedule);
            Add(carIndex);
            Add(raceState);
            Add(currentLap);
            Add(currentTime);
            Add(currentSectorTime);
            Add(participantIndex);
        }
    }
}
