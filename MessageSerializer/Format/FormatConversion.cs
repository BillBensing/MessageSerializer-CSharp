using MessageSerializer.Exception;

namespace MessageSerializer.Format
{
    public class FormatConversion
    {
        public static MessageType ToMessageType(string contentType)
        {
            ValidateContentTypeIsNotNull(contentType);

            switch (contentType)
            {
                case ContentType.Binary:
                    return MessageType.Binary;

                case ContentType.JSON:
                    return MessageType.JSON;

                case ContentType.XML:
                    return MessageType.XML;

                default:
                    throw new ContentTypeNotSupportedException(ContentTypeNotFoundSupportedMessage(contentType));
            }
        }

        public static string ToContentType(MessageType messageType)
        {
            string result = string.Empty;
            switch (messageType)
            {
                case MessageType.Binary:
                    result = ContentType.Binary;
                    break;

                case MessageType.JSON:
                    result = ContentType.JSON;
                    break;

                case MessageType.XML:
                    result = ContentType.XML;
                    break;
            }
            return result;
        }

        private static void ValidateContentTypeIsNotNull(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                string exceptionMessage = "The Content-Type provided is either null or an empty string.";
                throw new System.ArgumentNullException(exceptionMessage);
            }
        }

        private static string ContentTypeNotFoundSupportedMessage(string contentType)
        {
            return string.Format("Ummm, yeah... {0} is not a Content-Type I recgonize.", contentType);
        }
    }
}