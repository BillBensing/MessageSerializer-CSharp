namespace MessageSerializer.Exception
{
    public class ContentTypeNotSupportedException : System.Exception

    {
        public ContentTypeNotSupportedException()
        {
        }

        public ContentTypeNotSupportedException(string message) : base(message)
        {
        }
    }
}