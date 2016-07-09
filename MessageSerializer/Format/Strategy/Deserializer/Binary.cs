using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MessageSerializer.Format.Strategy.Deserializer
{
    public class Binary<T> : IDeserializerStrategy<T>
    {
        public T Deserialize(byte[] message)
        {
            var stream = new MemoryStream(message);
            var serializer = new BinaryFormatter();
            return (T)serializer.Deserialize(stream);
        }
    }
}