using System;
namespace pcars
{
    public class GameMenuState : ICaptureState
    {
        IRecord record;
        IDisplay display;

        bool displayed;

        public GameMenuState(IRecord record, IDisplay display)
        {
            displayed = false;
            this.record = record;
            this.display = display;
        }

        public void Capture(Capture capture, PacketDecoder packet)
        {
            // Console.WriteLine("In Game menu " + packet.GetType());

            if (packet.GetType().Name == "GameStateDataDecoder")
            {
                var gameState = (GameStateDataDecoder)packet;

                if (gameState.gameState.GameState() == GameStates.GAME_INGAME_PLAYING)
                {
                    displayed = false;
                    Next(capture, new GamePlayingState(record, display));
                }
                else if (gameState.gameState.GameState() == GameStates.GAME_FRONT_END)
                {
                    displayed = false;
                    Next(capture, new GameFrontEndState(record, display));
                }
            }
            else if (!displayed)
            {
                displayed = true;
                display.DisplayTelemetry(record);
            }
        }

        public void Next(Capture capture, ICaptureState captureState)
        {
            capture.NextState(captureState);
        }
    }
}

