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
        private string _myMessageAsString;
        private byte[] actualBytes, testBytes;
        private ISerializerStrategy _serializerStrategy;
        private IDeserializerStrategy<MyMessage> _deserializerStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _serializerStrategy = new JSON();
            _deserializerStrategy = new JSON<MyMessage>();

            actualObject = new MyMessage() { message = "hello" };
            _myMessageAsString = "{\"message\":\"hello\"}";

            actualBytes = Encoding.Default.GetBytes(_myMessageAsString); ;
        }

        [TestMethod]
        public void JSON_Serialize_object_to_byte_array()
        {
            testBytes = _serializerStrategy.Serialize(actualObject);
            Assert.AreEqual(Convert.ToBase64String(actualBytes),
                            Convert.ToBase64String(testBytes));
        }

        [TestMethod]
        public void JSON_deserialize_byte_array_to_object()
        {
            testObject = _deserializerStrategy.Deserialize(actualBytes);
            Assert.AreEqual(testObject.message,actualObject.message);
        }

    }

}