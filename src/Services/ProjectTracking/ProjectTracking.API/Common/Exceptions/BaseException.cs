namespace ProjectTracking.API.Common.Exceptions;

public class BaseException : ApplicationException
{
    public ExceptionCode ExceptionCode { get; }

    public BaseException(ExceptionCode code, string message) : base(message)
    {
        ExceptionCode = code;
    }

    public BaseException(ExceptionCode code, string message, Exception innerException) : base(message, innerException)
    {
        ExceptionCode = code;
    }
}