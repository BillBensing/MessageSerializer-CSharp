namespace MessageSerializer
{
    public interface IDeserializer<T>
    {
        IDeserializer<T> UseBuffer(byte[] buffer);

        T DeserializeAs(MessageType messageType);

        T DeserializeAs(string contentType);
    }
}