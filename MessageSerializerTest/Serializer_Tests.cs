using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer;
using MessageSerializer.Format.Strategy.Serializer;
using MessageSerializer.Format.Strategy;

namespace MessageSerializerTest
{
    [TestClass]
    public class Serializer_Tests
    {
        private MyMessage actualObject;
        private ISerializer serializer;
        private MessageType testMessageType;
        private string testContentType;
        private byte[] binaryActualBytes, binaryTestBytes, jsonActualBytes, jsonTestBytes, xmlActualBytes, xmlTestBytes;

        [TestInitialize]
        public void TestInitialize()
        {
            actualObject = new MyMessage() { message = "hello" };
            serializer = new Serializer().UseObject(actualObject);

            jsonActualBytes = new JSON().Serialize(actualObject);
            binaryActualBytes = new Binary().Serialize(actualObject);
            xmlActualBytes = new XML().Serialize(actualObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_Exception_thrown_for_null_message_argument()
        {
            var nullSerializer = new Serializer().UseObject(null);
        }

        [TestMethod]
        public void Test_Injectable_Constructor()
        {
            var customSerializer = new Serializer(new DeserializeStrategySelector());
            Assert.IsInstanceOfType(customSerializer.StrategySelector, typeof(DeserializeStrategySelector));
        }

        [TestMethod]
        public void Serialize_JSON_from_message_type()
        {
            testMessageType = MessageType.JSON;
            jsonTestBytes = serializer.SerializeAs(testMessageType);

            Assert.AreEqual(ToBase64(jsonTestBytes),
                            ToBase64(jsonActualBytes));
        }

        [TestMethod]
        public void Serialize_JSON_from_content_type()
        { 
            testContentType = "application/json";
            jsonTestBytes = serializer.SerializeAs(testContentType);

            Assert.AreEqual(ToBase64(jsonTestBytes),
                            ToBase64(jsonActualBytes));

        }

        [TestMethod]
        public void Serialize_XML_from_message_type()
        {
            testMessageType = MessageType.XML;
            xmlTestBytes = serializer.SerializeAs(testMessageType);

            Assert.AreEqual(ToBase64(xmlTestBytes),
                            ToBase64(xmlActualBytes));
        }

        [TestMethod]
        public void Serialize_XML_from_content_type()
        {
            testContentType = "text/xml";
            xmlTestBytes = serializer.SerializeAs(testContentType);

            Assert.AreEqual(ToBase64(xmlTestBytes),
                            ToBase64(xmlActualBytes));

        }

        [TestMethod]
        public void Serialize_Binary_from_message_type()
        {
            testMessageType = MessageType.Binary;
            binaryTestBytes = serializer.SerializeAs(testMessageType);

            Assert.AreEqual(ToBase64(binaryTestBytes),
                            ToBase64(binaryActualBytes));
        }

        [TestMethod]
        public void Serialize_Binary_from_content_type()
        {
            testContentType = "application/octet-stream";
            binaryTestBytes = serializer.SerializeAs(testContentType);

            Assert.AreEqual(ToBase64(binaryTestBytes),
                            ToBase64(binaryActualBytes));
        }

        private string ToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
