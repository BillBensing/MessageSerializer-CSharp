namespace MessageSerializer.Exception
{
    public class ContentTypeNotSupportedException : System.Exception
    {
        public ContentTypeNotSupportedException(string message) : base(message)
        {
        }
    }
}