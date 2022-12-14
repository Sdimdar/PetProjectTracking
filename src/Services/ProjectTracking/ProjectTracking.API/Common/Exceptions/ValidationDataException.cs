namespace ProjectTracking.API.Common.Exceptions;

public class ValidationDataException : BaseException
{
    public ValidationDataException(string message) : base(ExceptionCode.ValidationDataException, message)
    {
    }

    public ValidationDataException( string message, Exception innerException) : base(ExceptionCode.ValidationDataException, message, innerException)
    {
    }
}