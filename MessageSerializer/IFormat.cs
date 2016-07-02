namespace MessageSerializer
{
    public interface IFormat
    {
        IFormatMessage SelectFormat(string contentType);
        IFormatMessage SelectFormat(MessageFormat format);
    }
}
