using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy.Serializer;

namespace MessageSerializer.Format.Strategy
{
    public class DeserializeStrategySelector : ISerializeStrategySelector
    {
        /// <summary>
        /// Determines which strategy to implement based on the MessageType provided
        /// </summary>
        /// <param name="format">MessageType</param>
        /// <returns>object</returns>
        public virtual ISerializerStrategy UseStrategy(MessageType format)
        {
            switch (format)
            {
                case MessageType.Binary:
                    return new Binary();

                case MessageType.JSON:
                    return new JSON();

                case MessageType.XML:
                    return new XML();

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