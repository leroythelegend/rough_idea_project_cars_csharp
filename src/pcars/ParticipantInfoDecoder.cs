using System;
namespace pcars
{
    public class ParticipantInfoDecoder : CompositeDecoder
    {
        public ShortArrayDecoder worldPosition;
        public ShortArrayDecoder orientation;
        public UShortDecoder currentLapDistance;
        public RacePositionDecoder racePosition;
        public SectorDecoder sector;
        public HighestFlagDecoder highestFlag;
        public PitModeScheduleDecoder pitModeSchedule;
        public UShortDecoder carIndex;
        public RaceStateDecoder raceState;
        public OneByteDecoder currentLap;
        public FloatDecoder currentTime;
        public FloatDecoder currentSectorTime;
        public UShortDecoder participantIndex;

        public ParticipantInfoDecoder()
        {
            worldPosition = new ShortArrayDecoder(3);
            orientation = new ShortArrayDecoder(3);
            currentLapDistance = new UShortDecoder();
            racePosition = new RacePositionDecoder();
            sector = new SectorDecoder();
            highestFlag = new HighestFlagDecoder();
            pitModeSchedule = new PitModeScheduleDecoder();
            carIndex = new UShortDecoder();
            raceState = new RaceStateDecoder();
            currentLap = new OneByteDecoder();
            currentTime = new FloatDecoder();
            currentSectorTime = new FloatDecoder();
            participantIndex = new UShortDecoder();

            base.Add(worldPosition);
            base.Add(orientation);
            base.Add(currentLapDistance);
            base.Add(racePosition);
            base.Add(sector);
            base.Add(highestFlag);
            base.Add(pitModeSchedule);
            base.Add(carIndex);
            base.Add(raceState);
            base.Add(currentLap);
            base.Add(currentTime);
            base.Add(currentSectorTime);
            base.Add(participantIndex);
        }
    }
}
