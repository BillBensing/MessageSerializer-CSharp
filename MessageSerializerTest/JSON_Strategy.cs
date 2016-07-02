using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer;
using MessageSerializer.Format.Strategy;

namespace MessageSerializerTest
{
    [TestClass]
    public class JSON_Strategy
    {
        [TestMethod]
        public void JSON_format_produces_json_object()
        {
            IFormat format = new FormatMessage();
            IFormatMessage json = format.SelectFormat(MessageFormat.JSON);

            Assert.IsInstanceOfType(json, typeof(JSON));
        }

        [TestMethod]
        public void JSON_contentType_produces_json_object()
        {
            string contentType = "application/json";
            IFormat format = new FormatMessage();
            IFormatMessage json = format.SelectFormat(contentType);

            Assert.IsInstanceOfType(json, typeof(JSON));
        }
    }
}
