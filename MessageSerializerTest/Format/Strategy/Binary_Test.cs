using MessageSerializer;
using MessageSerializer.Format.Strategy.Deserializer;
using MessageSerializer.Format.Strategy.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MessageSerializerTest.Format.Strategy.Serializer
{
    [TestClass]
    public class Binary_Test
    {
        private MyMessage actualObject, testObject;
        private byte[] actualBytes, testBytes;
        private ISerializerStrategy serializerStrategy;
        private IDeserializerStrategy<MyMessage> deserializerStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            serializerStrategy = new Binary();
            deserializerStrategy = new Binary<MyMessage>();

            actualObject = new MyMessage() { message = "hello" };
            actualBytes = CreateTestableSerializtion(actualObject);
        }

        [TestMethod]
        public void Binary_Serialize_object_to_byte_array()
        {

            testBytes = serializerStrategy.Serialize(actualObject);
            Assert.AreEqual(Convert.ToBase64String(actualBytes),
                            Convert.ToBase64String(testBytes));
        }

        [TestMethod]
        public void Binary_deserialize_byte_array_to_object()
        {
            testObject = deserializerStrategy.Deserialize(actualBytes);
            Assert.AreEqual(testObject.message,actualObject.message);
        }

        private byte[] CreateTestableSerializtion(object message)
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