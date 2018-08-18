using System;
namespace pcars
{
    public class ClassInfoDecoder : PacketDecoder
    {
        public int CLASS_NAME_LENGTH_MAX = 20;

        public FourByteDecoder classIndex;
        public StringMatrixDecoder name;

        public ClassInfoDecoder()
        {
            classIndex = new FourByteDecoder();
            name = new StringMatrixDecoder(1, CLASS_NAME_LENGTH_MAX);

            Add(classIndex);
            Add(name);
        }
    }
}
