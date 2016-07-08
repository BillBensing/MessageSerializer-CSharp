using System;

namespace MessageSerializer.Format.Strategy.Deserializer
{
    public class XML<T> : IDeserializerStrategy<T>
    {
        public T Deserialize(byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}