namespace MessageSerializer.Format.Strategy
{
    public interface ISerializeStrategySelector
    {
        ISerializerStrategy UseStrategy(MessageType format);
    }
}