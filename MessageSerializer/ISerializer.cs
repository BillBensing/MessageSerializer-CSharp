namespace MessageSerializer
{
    public interface ISerializer
    {
        ISerializer UseObject(object message);

        byte[] SerializeAs(MessageType messageType);

        byte[] SerializeAs(string contentType);
    }
}