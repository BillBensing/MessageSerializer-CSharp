using System;
using System.IO;
using System.Xml.Serialization;

namespace MessageSerializer.Format.Strategy.Deserializer
{
    public class XML<T> : IDeserializerStrategy<T>
    {
        public T Deserialize(byte[] message)
        {
            var stream = new MemoryStream(message);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}