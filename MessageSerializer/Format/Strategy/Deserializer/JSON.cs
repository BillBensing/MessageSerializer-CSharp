using Newtonsoft.Json;
using System.Text;

namespace MessageSerializer.Format.Strategy.Deserializer
{
    public class JSON<T> : IDeserializerStrategy<T>
    {
        public T Deserialize(byte[] message)
        {
            string json = Encoding.Default.GetString(message);
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}