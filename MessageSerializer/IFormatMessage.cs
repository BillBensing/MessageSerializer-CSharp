using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSerializer
{
    public interface IFormatMessage
    {
        object Serialize(object message, MessageFormat format, MessageFormat serializeAs);
        object Serialize(object message, string contentType, MessageFormat serializeAs);
        object Deserialize(object message, MessageFormat format, MessageFormat serializeAs);
        object Deserialize(object message, string contentyType, MessageFormat serializeAs);
    }
}
