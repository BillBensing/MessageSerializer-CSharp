using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer;
using MessageSerializer.Format.Strategy;
using MessageSerializer.Format.Strategy.Serializer;

namespace MessageSerializerTest
{
    [TestClass]
    public class Deserializer_Tests
    {
        private MyMessage actualObject;
        private byte[] binaryActualBytes, jsonActualBytes, xmlActualBytes;

        [TestInitialize]
        public void TestInitialize()
        {
            actualObject = new MyMessage() { message = "hello" };
            jsonActualBytes = new JSON().Serialize(actualObject);
            binaryActualBytes = new Binary().Serialize(actualObject);
            xmlActualBytes = new XML().Serialize(actualObject);
        }

        [TestMethod]
        public void Test_UserBuffer_getter_and_setter()
        {
            var deserializer = new Deserializer<MyMessage>();
            deserializer.UseBuffer(jsonActualBytes);
            Assert.AreEqual(deserializer.Buffer, jsonActualBytes);        
        }

        [TestMethod]
        public void Test_Injectable_Constructor()
        {
            var customDeserializer = new Deserializer<MyMessage>(new DeserializeStrategySelector<MyMessage>());
            Assert.IsInstanceOfType(customDeserializer.StrategySelector, typeof(DeserializeStrategySelector<MyMessage>));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Expect_null_argument_from_null_bugger_()
        {
            var deserializer = new Deserializer<MyMessage>();
            deserializer.UseBuffer(null).DeserializeAs(MessageType.Binary);
        }

        [TestMethod]
        public void Deserialize_as_JSON_from_message_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var testMessageType = MessageType.JSON;
            testObject = deserializer.UseBuffer(jsonActualBytes).DeserializeAs(testMessageType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }

        [TestMethod]
        public void Deserialize_as_JSON_from_content_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var contentType = "application/json";
            var testMessageType = MessageType.JSON;
            testObject = deserializer.UseBuffer(jsonActualBytes).DeserializeAs(contentType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }

        [TestMethod]
        public void Deserialize_as_XML_from_message_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var testMessageType = MessageType.XML;
            testObject = deserializer.UseBuffer(xmlActualBytes).DeserializeAs(testMessageType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }

        [TestMethod]
        public void Deserialize_as_XML_from_content_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var contentType = "text/xml";
            var testMessageType = MessageType.XML;
            testObject = deserializer.UseBuffer(xmlActualBytes).DeserializeAs(contentType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }

        [TestMethod]
        public void Deserialize_as_Binary_from_message_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var testMessageType = MessageType.Binary;
            testObject = deserializer.UseBuffer(binaryActualBytes).DeserializeAs(testMessageType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }

        [TestMethod]
        public void Deserialize_as_Binary_from_content_type()
        {
            var deserializer = new Deserializer<MyMessage>();
            MyMessage testObject = new MyMessage();
            var contentType = "application/octet-stream";
            var testMessageType = MessageType.Binary;
            testObject = deserializer.UseBuffer(binaryActualBytes).DeserializeAs(contentType);

            Assert.AreEqual(deserializer.MessageType, testMessageType);
            Assert.AreEqual(testObject.message, actualObject.message);
            Assert.AreEqual(testObject.message, deserializer.DeserializedMessage.message);

        }
    }
}
