using MessageSerializer;
using MessageSerializer.Format.Strategy.Deserializer;
using MessageSerializer.Format.Strategy.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace MessageSerializerTest.Format.Strategy.Serializer
{
    [TestClass]
    public class JSON_Test
    {
        private MyMessage actualObject, testObject;
        private byte[] actualBytes, testBytes;
        private ISerializerStrategy serializerStrategy;
        private IDeserializerStrategy<MyMessage> deserializerStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            serializerStrategy = new JSON();
            deserializerStrategy = new JSON<MyMessage>();

            actualObject = new MyMessage() { message = "hello" };
            actualBytes = Encoding.Default.GetBytes("{\"message\":\"hello\"}");
        }

        [TestMethod]
        public void JSON_Serialize_object_to_byte_array()
        {
            testBytes = serializerStrategy.Serialize(actualObject);
            Assert.AreEqual(Convert.ToBase64String(actualBytes),
                            Convert.ToBase64String(testBytes));
        }

        [TestMethod]
        public void JSON_deserialize_byte_array_to_object()
        {
            testObject = deserializerStrategy.Deserialize(actualBytes);
            Assert.AreEqual(testObject.message,actualObject.message);
        }

    }

}