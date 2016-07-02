using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSerializer.Format.Strategy
{
    public class JSON : BaseMessage, IFormatMessage
    {
        public object Deserialize(object message, string contentyType, MessageFormat serializeAs)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(object message, MessageFormat format, MessageFormat serializeAs)
        {
            throw new NotImplementedException();
        }

        public object Serialize(object message, string contentType, MessageFormat serializeAs)
        {
            throw new NotImplementedException();
        }

        public object Serialize(object message, MessageFormat format, MessageFormat serializeAs)
        {
            throw new NotImplementedException();
        }
    }
}
