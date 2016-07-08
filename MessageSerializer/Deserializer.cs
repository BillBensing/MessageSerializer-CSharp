using MessageSerializer.Format;
using MessageSerializer.Format.Strategy;

namespace MessageSerializer
{
    public class Deserializer<T> : IDeserializer<T>
    {
        private byte[] _buffer;
        private MessageType _messageType;
        private T _deserializedMessage;
        private ISerializeStrategySelector _strategySelector;

        public byte[] Buffer { get { return this._buffer; } private set { } }
        public MessageType MessageType { get { return this._messageType; } private set { } }
        public T DeserializedMessage { get { return this._deserializedMessage; } private set { } }

        /// <summary>
        /// Default Constructor which uses the default Strategy Selector impementation
        /// </summary>
        public Deserializer()
        {
            _strategySelector = new SerializeStrategySelector();
        }

        /// <summary>
        /// Constructor which allows to supply a custome Strategcy Selector
        /// </summary>
        /// <param name="strategySelector">Strategy Selector</param>
        public Deserializer(ISerializeStrategySelector strategySelector)
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
            ISerializerStrategy serializer = _strategySelector.UseStrategy(messageType);
            //this._deserializedMessage = (T)serializer.Deserialize<T>(buffer);
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