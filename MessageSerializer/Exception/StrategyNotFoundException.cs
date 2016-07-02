using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSerializer.Exception
{
    public class StrategyNotFoundException : System.Exception

    {
        public StrategyNotFoundException()
        {
           
        }

        public StrategyNotFoundException(string message) : base(message)
        {
        }
    }
}
