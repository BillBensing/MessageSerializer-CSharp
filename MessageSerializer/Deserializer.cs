using MessageSerializer.Format;
using MessageSerializer.Format.Strategy;
using MessageSerializer.Format.Strategy.Deserializer;

namespace MessageSerializer
{
    public class Deserializer<T> : IDeserializer<T>
    {        
        public byte[] Buffer { get; private set; }
        public MessageType MessageType { get; private set; }
        public T DeserializedMessage { get; private set; }
        public IDeserializeStrategySelector<T> StrategySelector { get; private set; }

        /// <summary>
        /// Default Constructor which uses the default Strategy Selector impementation
        /// </summary>
        public Deserializer()
        {
            StrategySelector = new DeserializeStrategySelector<T>();
        }

        /// <summary>
        /// Constructor which allows to supply a custom Strategy Selector
        /// </summary>
        /// <param name="strategySelector">Strategy Selector</param>
        public Deserializer(IDeserializeStrategySelector<T> strategySelector)
        {
            this.StrategySelector = strategySelector;
        }

        public T DeserializeAs(string contentType)
        {
            this.MessageType = FormatConversion.ToMessageType(contentType);
            var result = DeserializeObject(this.Buffer, this.MessageType);
            return result;
        }

        public T DeserializeAs(MessageType messageType)
        {
            this.MessageType = messageType;
            var result = DeserializeObject(this.Buffer, this.MessageType);
            return result;
        }

        public IDeserializer<T> UseBuffer(byte[] buffer)
        { 
            ValidateBufferIsNotNull(buffer);
            this.Buffer = buffer;
            return this;
        }

        private T DeserializeObject(byte[] buffer, MessageType messageType)
        {
            IDeserializerStrategy<T> strategy = StrategySelector.UseStrategy(messageType);
            this.DeserializedMessage = strategy.Deserialize(buffer);
            return this.DeserializedMessage;
        }

        private void ValidateBufferIsNotNull(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new System.ArgumentNullException("Cannot deserialize, the supplied buffer is null.");
            }
        }
    }
}