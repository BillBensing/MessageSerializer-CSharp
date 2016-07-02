using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSerializer
{
    public abstract class BaseMessage
    {
        public object GetMessage { get { return _message; } private set { } }
        private object _message;
    }
}
