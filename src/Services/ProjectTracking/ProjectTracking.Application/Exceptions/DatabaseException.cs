

namespace ProjectTracking.Application.Exceptions;

public class DatabaseException:BaseException
{
    public DatabaseException(string message) : base(ExceptionCode.DbException, message)
    {
    }

    public DatabaseException( string message, Exception innerException) : base(ExceptionCode.DbException, message, innerException)
    {
    }
}