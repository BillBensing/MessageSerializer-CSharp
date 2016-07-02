using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer;
using MessageSerializer.Format.Strategy;

namespace MessageSerializerTest
{
    [TestClass]
    public class Binary_Strategy
    {
        [TestMethod]
        public void Binary_format_produces_binary_object()
        {
            IFormat format = new FormatMessage();
            IFormatMessage binary = format.SelectFormat(MessageFormat.Binary);

            Assert.IsInstanceOfType(binary, typeof(Binary));
        }

        [TestMethod]
        public void Binary_contentType_produces_binary_object()
        {
            string contentType = "application/octet-stream";
            IFormat format = new FormatMessage();
            IFormatMessage binary = format.SelectFormat(contentType);

            Assert.IsInstanceOfType(binary, typeof(Binary));
        }
    }
}
