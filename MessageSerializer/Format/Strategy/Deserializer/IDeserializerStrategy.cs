namespace MessageSerializer.Format.Strategy.Deserializer
{
    public interface IDeserializerStrategy<T>
    {
        T Deserialize(byte[] message);
    }
}