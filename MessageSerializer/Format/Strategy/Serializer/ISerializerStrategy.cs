namespace MessageSerializer
{
    public interface ISerializerStrategy
    {
        byte[] Serialize(object message);
    }
}