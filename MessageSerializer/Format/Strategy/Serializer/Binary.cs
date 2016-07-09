using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MessageSerializer.Format.Strategy.Serializer
{
    public class Binary : ISerializerStrategy
    {
        public byte[] Serialize(object message)
        {
            var stream = new MemoryStream();
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, message);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream.GetBuffer();
        }
    }
}