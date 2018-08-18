using System;
namespace pcars
{
    public class ClassInfoArrayDecoder : IDecoder
    {
        public const int CLASSES_SUPPORTED_PER_PACKET = 60;

        public ClassInfoDecoder[] classInfos;

        public ClassInfoArrayDecoder()
        {
            classInfos = new ClassInfoDecoder[CLASSES_SUPPORTED_PER_PACKET];
            for (uint i = 0; i < CLASSES_SUPPORTED_PER_PACKET; ++i)
            {
                classInfos[i] = new ClassInfoDecoder();
            }
        }

        public void Decode(ref Byte[] bytes, ref int index)
        {
            for (uint i = 0; i < CLASSES_SUPPORTED_PER_PACKET; ++i)
            {
                classInfos[i].Decode(ref bytes, ref index);
            }
        }

        public ClassInfoDecoder ClassInfoArray(int index)
        {
            return classInfos[index];
        }
    }
}
