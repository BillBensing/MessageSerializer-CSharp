using Newtonsoft.Json;
using System.Text;

namespace MessageSerializer.Format.Strategy.Serializer
{
    public class JSON : ISerializerStrategy
    {
        public byte[] Serialize(object message)
        {
            string json = JsonConvert.SerializeObject(message);
            byte[] messageBuffer = Encoding.Default.GetBytes(json);
            return messageBuffer;
        }
    }
}