using System;
using System.IO;
using System.Xml.Serialization;

namespace MessageSerializer.Format.Strategy.Serializer
{
    public class XML : ISerializerStrategy
    {
        public byte[] Serialize(object message)
        {
            var stream = new MemoryStream();
            var serializer = new XmlSerializer(message.GetType());
            serializer.Serialize(stream, message);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream.GetBuffer();
        }
    }   
}