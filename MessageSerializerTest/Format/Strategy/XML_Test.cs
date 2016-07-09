using MessageSerializer;
using MessageSerializer.Format.Strategy.Deserializer;
using MessageSerializer.Format.Strategy.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MessageSerializerTest.Format.Strategy.Serializer
{
    [TestClass]
    public class XML_Test
    {
        private MyMessage actualObject, testObject;
        private byte[] actualBytes, testBytes;
        private ISerializerStrategy serializerStrategy;
        private IDeserializerStrategy<MyMessage> deserializerStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            serializerStrategy = new XML();
            deserializerStrategy = new XML<MyMessage>();

            actualObject = new MyMessage() { message = "hello" };
            actualBytes = CreateTestableSerializtion(actualObject);
        }

        [TestMethod]
        public void XML_Serialize_object_to_byte_array()
        {

            testBytes = serializerStrategy.Serialize(actualObject);
            Assert.AreEqual(Convert.ToBase64String(actualBytes),
                            Convert.ToBase64String(testBytes));
        }

        [TestMethod]
        public void XML_deserialize_byte_array_to_object()
        {
            testObject = deserializerStrategy.Deserialize(actualBytes);
            Assert.AreEqual(testObject.message,actualObject.message);
        }

        private byte[] CreateTestableSerializtion(object message)
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