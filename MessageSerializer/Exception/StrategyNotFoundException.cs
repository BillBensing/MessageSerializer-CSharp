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