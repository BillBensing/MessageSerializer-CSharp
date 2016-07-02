using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer;
using MessageSerializer.Format.Strategy;

namespace MessageSerializerTest
{
    [TestClass]
    public class XML_Strategy
    {
        [TestMethod]
        public void XML_format_produces_xml_object()
        {
            IFormat format = new FormatMessage();
            IFormatMessage xml = format.SelectFormat(MessageFormat.XML);

            Assert.IsInstanceOfType(xml, typeof(XML));
        }

        [TestMethod]
        public void XML_contentType_produces_xml_object()
        {
            string contentType = "text/xml";
            IFormat format = new FormatMessage();
            IFormatMessage xml = format.SelectFormat(contentType);

            Assert.IsInstanceOfType(xml, typeof(XML));
        }
    }
}
