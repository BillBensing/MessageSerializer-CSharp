using MessageSerializer.Format.Strategy.Deserializer;

namespace MessageSerializer.Format.Strategy
{
    public interface IDeserializeStrategySelector<T>
    {
        IDeserializerStrategy<T> UseStrategy(MessageType format);
    }
}