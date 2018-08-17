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

            base.Add(packetBase);
            base.Add(buildVersionNumber);
            base.Add(gameState);
            base.Add(ambientTemperature);
            base.Add(trackTemperature);
            base.Add(rainDensity);
            base.Add(snowDensity);
            base.Add(windSpeed);
            base.Add(windDirectionX);
            base.Add(windDirectionY);
        }
    }
}
