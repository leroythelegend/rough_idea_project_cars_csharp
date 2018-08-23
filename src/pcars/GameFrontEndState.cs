using System;
namespace pcars
{
    public class GameFrontEndState : ICaptureState
    {
        IRecord record;
        IDisplay display;

        public GameFrontEndState(IRecord record, IDisplay display)
        {
            this.record = record;
            this.display = display;
        }

        public void Capture(Capture capture, PacketDecoder packet)
        {
            // Console.WriteLine("In Game Front End " + packet.GetType());

            if (packet.GetType().Name == "GameStateDataDecoder")
            {
                var gameState = (GameStateDataDecoder)packet;

                if (gameState.gameState.GameState() == GameStates.GAME_INGAME_PLAYING)
                {
                    Next(capture, new GamePlayingState(record, display));
                }
                else if (gameState.gameState.GameState() == GameStates.GAME_INGAME_INMENU_TIME_TICKING)
                {
                    Next(capture, new GameMenuState(record, display));
                }
            }
        }

        public void Next(Capture capture, ICaptureState captureState)
        {
            capture.NextState(captureState);
        }
    }
}

