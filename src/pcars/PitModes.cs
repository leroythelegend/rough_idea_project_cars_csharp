using System;
namespace pcars
{
    public enum PitModes
    {
        PIT_MODE_NONE = 0,
        PIT_MODE_DRIVING_INTO_PITS,
        PIT_MODE_IN_PIT,
        PIT_MODE_DRIVING_OUT_OF_PITS,
        PIT_MODE_IN_GARAGE,
        PIT_MODE_DRIVING_OUT_OF_GARAGE,
        PIT_MODE_MAX
    }
}
