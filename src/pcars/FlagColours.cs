using System;
namespace pcars
{
    public enum FlagColours
    {
        FLAG_COLOUR_NONE = 0,             // Not used for actual flags, only for some query functions
        FLAG_COLOUR_GREEN,                // End of danger zone, or race started
        FLAG_COLOUR_BLUE,                 // Faster car wants to overtake the participant
        FLAG_COLOUR_WHITE_SLOW_CAR,       // Slow car in area
        FLAG_COLOUR_WHITE_FINAL_LAP,      // Final Lap
        FLAG_COLOUR_RED,                  // Huge collisions where one or more cars become wrecked and block the track
        FLAG_COLOUR_YELLOW,               // Danger on the racing surface itself
        FLAG_COLOUR_DOUBLE_YELLOW,        // Danger that wholly or partly blocks the racing surface
        FLAG_COLOUR_BLACK_AND_WHITE,      // Unsportsmanlike conduct
        FLAG_COLOUR_BLACK_ORANGE_CIRCLE,  // Mechanical Failure
        FLAG_COLOUR_BLACK,                // Participant disqualified
        FLAG_COLOUR_CHEQUERED,            // Chequered flag
        FLAG_COLOUR_MAX
    }
}
