using System;
namespace pcars
{
    public class GamePlayingState : ICaptureState
    {
        IRecord record;
        IDisplay display;

        public GamePlayingState(IRecord record, IDisplay display)
        {
            this.record = record;
            this.display = display;
        }

        public void Capture(Capture capture, PacketDecoder packet)
        {
            // Console.WriteLine("In Game Playing " + packet.GetType());

            if (packet.GetType().Name == "GameStateDataDecoder")
            {
                var gameState = (GameStateDataDecoder)packet;

                if (gameState.gameState.GameState() == GameStates.GAME_FRONT_END)
                {
                    Next(capture, new GameFrontEndState(record, display));
                }
                else if (gameState.gameState.GameState() == GameStates.GAME_INGAME_INMENU_TIME_TICKING)
                {
                    Next(capture, new GameMenuState(record, display));
                }
            }

            record.RecordTelemetry(packet);
        }

        public void Next(Capture capture, ICaptureState captureState)
        {
            capture.NextState(captureState);
        }
    }
}

