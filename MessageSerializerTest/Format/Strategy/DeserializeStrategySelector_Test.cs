using MessageSerializer;
using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy;
using MessageSerializer.Format.Strategy.Deserializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageSerializerTest.Format.Strategy
{
    [TestClass]
    public class DeserializeStrategySelector_Test
    {
        [TestMethod]
        public void Instantiates_binary_message_deserializer()
        {
            DeserializeStrategySelector<object> selector = new DeserializeStrategySelector<object>();
            IDeserializerStrategy<object> serializer = selector.UseStrategy(MessageType.Binary);
            Assert.IsInstanceOfType(serializer, typeof(Binary<object>));
        }

        [TestMethod]
        public void Instantiates_JSON_message_deserializer()
        {
            DeserializeStrategySelector<object> selector = new DeserializeStrategySelector<object>();
            IDeserializerStrategy<object> serializer = selector.UseStrategy(MessageType.JSON);
            Assert.IsInstanceOfType(serializer, typeof(JSON<object>));
        }

        [TestMethod]
        public void Instantiates_xML_message_deserializer()
        {
            DeserializeStrategySelector<object> selector = new DeserializeStrategySelector<object>();
            IDeserializerStrategy<object> serializer = selector.UseStrategy(MessageType.XML);
            Assert.IsInstanceOfType(serializer, typeof(XML<object>));
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyNotFoundException))]
        public void Throws_execption_for_none_messageType()
        {
            DeserializeStrategySelector<object> selector = new DeserializeStrategySelector<object>();
            IDeserializerStrategy<object> serializer = selector.UseStrategy(MessageType.None);
        }
    }
}