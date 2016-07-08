using MessageSerializer;
using MessageSerializer.Exception;
using MessageSerializer.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageSerializerTest.Format
{
    [TestClass]
    public class FormatConversion_Test
    {
        [TestMethod]
        public void Binary_ConvertContentTypeToMessageType()
        {
            MessageType test = FormatConversion.ToMessageType("application/octet-stream");
            MessageType expected = MessageType.Binary;
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        public void Binary_ConvertMessageTypeToContentType()
        {
            string test = FormatConversion.ToContentType(MessageType.Binary);
            string expected = "application/octet-stream";
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        public void JSON_ConvertContentTypeToMessageType()
        {
            MessageType test = FormatConversion.ToMessageType("application/json");
            MessageType expected = MessageType.JSON;
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        public void JSON_ConvertMessageTypeToContentType()
        {
            string test = FormatConversion.ToContentType(MessageType.JSON);
            string expected = "application/json";
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        public void XML_ConvertContentTypeToMessageType()
        {
            MessageType test = FormatConversion.ToMessageType("text/xml");
            MessageType expected = MessageType.XML;
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        public void XML_ConvertMessageTypeToContentType()
        {
            string test = FormatConversion.ToContentType(MessageType.XML);
            string expected = "text/xml";
            Assert.AreEqual(test, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Thow_error_for_null_contentType()
        {
            MessageType test = FormatConversion.ToMessageType(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Thow_error_for_whitespace_contentType()
        {
            MessageType test = FormatConversion.ToMessageType(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Thow_error_for_stringEmpty_contentType()
        {
            MessageType test = FormatConversion.ToMessageType(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ContentTypeNotSupportedException))]
        public void Thow_error_for_contenttype_not_supported()
        {
            MessageType test = FormatConversion.ToMessageType("hello");
        }
    }
}