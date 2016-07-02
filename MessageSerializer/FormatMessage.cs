using MessageSerializer.Exception;
using MessageSerializer.Format.Strategy;

namespace MessageSerializer
{
    public class FormatMessage : IFormat
    {
        private const string BinaryContentType = "application/octet-stream";
        private const string JSONContentType = "application/json";
        private const string XMLContentType = "text/xml";

        public IFormatMessage SelectFormat(MessageFormat format)
        {
            switch (format)
            {
                case MessageFormat.Binary:
                    return new Binary();
                case MessageFormat.JSON:
                    return new JSON();
                case MessageFormat.XML:
                    return new XML();
                default:
                    throw new StrategyNotFoundException(StrategyNotFoundExceptionMessage(format));
            }
        }

        public IFormatMessage SelectFormat(string contentType)
        {
            switch (contentType)
            {
                case BinaryContentType:
                    return new Binary();
                case JSONContentType:
                    return new JSON();
                case XMLContentType:
                    return new XML();
                default:
                    throw new StrategyNotFoundException(StrategyNotFoundExceptionMessage(contentType));
            }
        }

        private string StrategyNotFoundExceptionMessage(MessageFormat format)
        {
            return string.Format("{0} format is not valid.", format.ToString());
        }


        private string StrategyNotFoundExceptionMessage(string format)
        {
            return string.Format("{0} format is not valid.", format);
        }
    }
}