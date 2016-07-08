using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy.Deserializer;

namespace MessageSerializer.Format.Strategy
{
    public class DeserializeStrategySelector<T> : IDeserializeStrategySelector<T>
    {
        public IDeserializerStrategy<T> UseStrategy(MessageType format)
        {
            switch (format)
            {
                case MessageType.Binary:
                    return new Binary<T>();

                case MessageType.JSON:
                    return new JSON<T>();

                case MessageType.XML:
                    return new XML<T>();

                default:
                    throw new StrategyNotFoundException(StrategyNotFoundExceptionMessage(format));
            }
        }

        private string StrategyNotFoundExceptionMessage(MessageType format)
        {
            return string.Format("{0} format is not a valid strategy.", format.ToString());
        }
    }
}