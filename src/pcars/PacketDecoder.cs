using System;
using System.Collections.Generic;

namespace pcars
{
    public class PacketDecoder : IDecoder
    {
        readonly List<IDecoder> decoders;

        public PacketDecoder()
        {
            decoders = new List<IDecoder>();
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            foreach (var decoder in decoders) {
                decoder.Decode(ref bytes, ref index);
            }   
        }

        public void Add(IDecoder decoder)
        {
            decoders.Add(decoder);
        }
    }
}
