using System;
namespace pcars
{
    public enum PitSchedules
    {
        PIT_SCHEDULE_NONE = 0,            // Nothing scheduled
        PIT_SCHEDULE_PLAYER_REQUESTED,    // Used for standard pit sequence - requested by player
        PIT_SCHEDULE_ENGINEER_REQUESTED,  // Used for standard pit sequence - requested by engineer
        PIT_SCHEDULE_DAMAGE_REQUESTED,    // Used for standard pit sequence - requested by engineer for damage
        PIT_SCHEDULE_MANDATORY,           // Used for standard pit sequence - requested by engineer from career enforced lap number
        PIT_SCHEDULE_DRIVE_THROUGH,       // Used for drive-through penalty
        PIT_SCHEDULE_STOP_GO,             // Used for stop-go penalty
        PIT_SCHEDULE_PITSPOT_OCCUPIED,    // Used for drive-through when pitspot is occupied
        PIT_SCHEDULE_MAX
    }
}
