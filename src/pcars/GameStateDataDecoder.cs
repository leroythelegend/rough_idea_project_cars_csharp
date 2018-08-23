using System;
namespace pcars
{
    public class GameStateDataDecoder : PacketDecoder
    {
        public PacketBaseDecoder packetBase;
        public TwoByteDecoder buildVersionNumber;
        public GameStateDecoder gameState;
        public OneByteDecoder ambientTemperature;
        public OneByteDecoder trackTemperature;
        public OneByteDecoder rainDensity;
        public OneByteDecoder snowDensity;
        public OneByteDecoder windSpeed;
        public OneByteDecoder windDirectionX;
        public OneByteDecoder windDirectionY;
        
        public GameStateDataDecoder()
        {
            packetBase = new PacketBaseDecoder();
            buildVersionNumber = new TwoByteDecoder();
            gameState = new GameStateDecoder();
            ambientTemperature = new OneByteDecoder();
            trackTemperature = new OneByteDecoder();
            rainDensity = new OneByteDecoder();
            snowDensity = new OneByteDecoder();
            windSpeed = new OneByteDecoder();
            windDirectionX = new OneByteDecoder();
            windDirectionY = new OneByteDecoder();

            Add(packetBase);
            Add(buildVersionNumber);
            Add(gameState);
            Add(ambientTemperature);
            Add(trackTemperature);
            Add(rainDensity);
            Add(snowDensity);
            Add(windSpeed);
            Add(windDirectionX);
            Add(windDirectionY);
        }
    }
}
