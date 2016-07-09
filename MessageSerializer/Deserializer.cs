using MessageSerializer.Format;
using MessageSerializer.Format.Strategy;
using MessageSerializer.Format.Strategy.Deserializer;

namespace MessageSerializer
{
    public class Deserializer<T> : IDeserializer<T>
    {
        private byte[] _buffer;
        private MessageType _messageType;
        private T _deserializedMessage;
        private IDeserializeStrategySelector<T> _strategySelector;

        public byte[] Buffer { get { return this._buffer; } private set { } }
        public MessageType MessageType { get { return this._messageType; } private set { } }
        public T DeserializedMessage { get { return this._deserializedMessage; } private set { } }

        /// <summary>
        /// Default Constructor which uses the default Strategy Selector impementation
        /// </summary>
        public Deserializer()
        {
            _strategySelector = new DeserializeStrategySelector<T>();
        }

        /// <summary>
        /// Constructor which allows to supply a custom Strategy Selector
        /// </summary>
        /// <param name="strategySelector">Strategy Selector</param>
        public Deserializer(IDeserializeStrategySelector<T> strategySelector)
        {
            this._strategySelector = strategySelector;
        }

        public T DeserializeAs(string contentType)
        {
            this._messageType = FormatConversion.ToMessageType(contentType);
            var result = DeserializeObject(this._buffer, this._messageType);
            return result;
        }

        public T DeserializeAs(MessageType messageType)
        {
            this._messageType = messageType;
            var result = DeserializeObject(this._buffer, this._messageType);
            return result;
        }

        public IDeserializer<T> UseBuffer(byte[] buffer)
        {
            this._buffer = buffer;
            return this;
        }

        private T DeserializeObject(byte[] buffer, MessageType messageType)
        {
            ValidateBufferIsNotNull();
            IDeserializerStrategy<T> strategy = _strategySelector.UseStrategy(messageType);
            this._deserializedMessage = strategy.Deserialize(buffer);
            return this._deserializedMessage;
        }

        private void ValidateBufferIsNotNull()
        {
            if (this._buffer == null)
            {
                throw new System.ArgumentNullException("Cannot deserializer, the supplied buffer is null.");
            }
        }
    }
}