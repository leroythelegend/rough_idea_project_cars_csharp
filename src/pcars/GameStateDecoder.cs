using System;
namespace pcars
{
    public class GameStateDecoder : IDecoder
    {
        TopFourBitDecoder sessionState;
        readonly BottomFourBitDecoder gameState;

        public GameStateDecoder()
        {
            sessionState = new TopFourBitDecoder();
            gameState = new BottomFourBitDecoder();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            sessionState.Decode(ref bytes, ref index);
            gameState.Decode(ref bytes, ref index);
            index++;
        }

        public SessionStates SessionState()
        {
            return (SessionStates)sessionState.UInt();
        }

        public GameStates GameState()
        {
            return (GameStates)gameState.UInt();
        }

    }
}
