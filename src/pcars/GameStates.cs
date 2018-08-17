using System;
namespace pcars
{
    public enum GameStates
    {
        GAME_EXITED = 0,
        GAME_FRONT_END,
        GAME_INGAME_PLAYING,
        GAME_INGAME_PAUSED,
        GAME_INGAME_INMENU_TIME_TICKING,
        GAME_INGAME_RESTARTING,
        GAME_INGAME_REPLAY,
        GAME_FRONT_END_REPLAY,
        GAME_MAX
    }
}
