using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy.Deserializer;

namespace MessageSerializer.Format.Strategy
{
    public class DeserializeStrategySelector<T> : IDeserializeStrategySelector<T>
    {

        /// <summary>
        /// Determines which strategy to implement based on the MessageType provided
        /// </summary>
        /// <param name="format">MessageType</param>
        /// <returns>object</returns>
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