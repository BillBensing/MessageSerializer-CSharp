using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageSerializer.Exception;

namespace MessageSerializerTest.Exception
{
    [TestClass]
    public class StrategyNotFoundException_Test
    {
        [TestMethod]
        public void Instantiate_ContentTypeNotSupportedException_with_message()
        {
            var message = "Error Occurred Test";
            var error = new StrategyNotFoundException(message);
            Assert.AreEqual(error.Message, message);
        }
    }
}
