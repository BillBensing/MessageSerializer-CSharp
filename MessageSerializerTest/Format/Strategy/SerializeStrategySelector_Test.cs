using MessageSerializer;
using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy;
using MessageSerializer.Format.Strategy.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageSerializerTest.Format.Strategy
{
    [TestClass]
    public class SerializeStrategySelector_Test
    {
        [TestMethod]
        public void StrategySelector_instantiates_binary_message_serializer()
        {
            SerializeStrategySelector selector = new SerializeStrategySelector();
            ISerializerStrategy serializer = selector.UseStrategy(MessageType.Binary);
            Assert.IsInstanceOfType(serializer, typeof(Binary));
        }

        [TestMethod]
        public void StrategySelector_instantiates_JSON_message_serializer()
        {
            SerializeStrategySelector selector = new SerializeStrategySelector();
            ISerializerStrategy serializer = selector.UseStrategy(MessageType.JSON);
            Assert.IsInstanceOfType(serializer, typeof(JSON));
        }

        [TestMethod]
        public void StrategySelector_instantiates_SML_message_serializer()
        {
            SerializeStrategySelector selector = new SerializeStrategySelector();
            ISerializerStrategy serializer = selector.UseStrategy(MessageType.XML);
            Assert.IsInstanceOfType(serializer, typeof(XML));
        }

        [TestMethod]
        [ExpectedException(typeof(StrategyNotFoundException))]
        public void StrategySelector_throws_execption_for_none_messageType()
        {
            SerializeStrategySelector selector = new SerializeStrategySelector();
            ISerializerStrategy serializer = selector.UseStrategy(MessageType.None);
        }
    }
}