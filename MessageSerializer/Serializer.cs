using MessageSerializer.Format;
using MessageSerializer.Format.Strategy;

namespace MessageSerializer
{
    public class Serializer : ISerializer
    {
        public object Message { get; private set; }
        public MessageType MessageType { get; private set; }
        public byte[] SerializedMessage { get; private set; }
        public ISerializeStrategySelector StrategySelector { get; private set; }

        public Serializer()
        {
            this.StrategySelector = new DeserializeStrategySelector();
        }

        public Serializer(ISerializeStrategySelector strategySelector)
        {
            this.StrategySelector = strategySelector;
        }

        public byte[] SerializeAs(string contentType)
        {
            this.MessageType = FormatConversion.ToMessageType(contentType);
            var result = SerializeObject(this.Message, this.MessageType);
            return result;
        }

        public byte[] SerializeAs(MessageType messageType)
        {
            this.MessageType = messageType;
            var result = SerializeObject(this.Message, this.MessageType);
            return result;
        }

        public ISerializer UseObject(object message)
        {
            ValidateMessageIsNotNull(message);
            this.Message = message;
            return this;
        }

        private byte[] SerializeObject(object message, MessageType messageType)
        {
            ISerializerStrategy strategy = this.StrategySelector.UseStrategy(messageType);
            this.SerializedMessage = strategy.Serialize(message);
            return this.SerializedMessage;
        }

        private void ValidateMessageIsNotNull(object message)
        {
            if (message == null)
            {
                throw new System.ArgumentNullException("You need to supply a message object before you can serialize");
            }
        }
    }
}