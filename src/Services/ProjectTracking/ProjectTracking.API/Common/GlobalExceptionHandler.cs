using System.Net;
using System.Text;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Exceptions;

namespace ProjectTracking.API.Common;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (BaseException ex)
        {
            
            DefaultResponseObject<object> response = new(ex.ExceptionCode, GetBusinessExceptionMessage(ex));
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (FluentValidation.ValidationException ex)
        {
            Console.WriteLine(ex.Errors);
            DefaultResponseObject<object> response = new(ExceptionCode.ValidationDataException, ex.InnerException.Message);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync("Something went wrong");
        }
        
        
    }
    private static string GetStackTrace(Exception? innerException)
    {
        StringBuilder builder = new();

        while (innerException is not null)
        {
            builder.Append(innerException.Message);
            builder.Append('\n');

            innerException = innerException.InnerException;
        }

        return builder.ToString();
    }

    private static string GetBusinessExceptionMessage(BaseException ex)
    {
        return ex.ExceptionCode switch
        {
            ExceptionCode.DbException => "Database read/write exception. Try later or with another data",
            _ => "Unknown business error"
        };
    }


    
}