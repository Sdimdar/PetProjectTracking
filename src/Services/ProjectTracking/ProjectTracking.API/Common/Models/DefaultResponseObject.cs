using ProjectTracking.API.Common.Exceptions;

namespace ProjectTracking.API.Common.Models;

public class DefaultResponseObject<T>
{
    public T? Value { get; }
    public bool IsSuccess { get; }
    public ExceptionCode? ExceptionCode { get; }
    public string? Exception { get; }

    public DefaultResponseObject(T data)
    {
        Value = data;
        IsSuccess = true;
        ExceptionCode = null;
        Exception = null;
    }

    public DefaultResponseObject(ExceptionCode code, string exceptionMessage)
    {
        Value = default;
        IsSuccess = false;
        ExceptionCode = code;
        Exception = exceptionMessage;
    }
    
}