using MessageSerializer.Format;
using MessageSerializer.Format.Strategy;

namespace MessageSerializer
{
    public class Serializer : ISerializer
    {
        private object _message;
        private MessageType _messageType;
        private byte[] _serializedMessage;
        private ISerializeStrategySelector _strategySelector;

        public object Message { get { return this._message; } private set { } }
        public MessageType MessageType { get { return this._messageType; } private set { } }
        public byte[] SerializedMessage { get { return this._serializedMessage; } private set { } }

        public Serializer()
        {
            this._strategySelector = new SerializeStrategySelector();
        }

        public Serializer(ISerializeStrategySelector strategySelector)
        {
            this._strategySelector = strategySelector;
        }

        public byte[] SerializeAs(string contentType)
        {
            this._messageType = FormatConversion.ToMessageType(contentType);
            var result = SerializeObject(this._message, this._messageType);
            return result;
        }

        public byte[] SerializeAs(MessageType messageType)
        {
            this._messageType = messageType;
            var result = SerializeObject(this._message, this._messageType);
            return result;
        }

        public ISerializer UseObject(object message)
        {
            this._message = message;
            return this;
        }

        private byte[] SerializeObject(object message, MessageType messageType)
        {
            ValidateMessageIsNotNull();
            ISerializerStrategy strategy = _strategySelector.UseStrategy(messageType);
            this._serializedMessage = strategy.Serialize(message);
            return this._serializedMessage;
        }

        private void ValidateMessageIsNotNull()
        {
            if (this._message == null)
            {
                throw new System.ArgumentNullException("You need to supply a message object before you can serialize");
            }
        }
    }
}