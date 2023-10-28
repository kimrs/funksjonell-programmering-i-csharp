using System.Net;
using System.Text.Json;

namespace FunksjonellProgrammering.Api;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            context.Response.ContentType = "application/json";
            (context.Response.StatusCode, var message) = e switch
            {
                ArgumentException => ((int)HttpStatusCode.BadRequest, e.Message),
                {InnerException: ArgumentException} => ((int)HttpStatusCode.BadRequest, e.InnerException.Message),
                _ => ((int)HttpStatusCode.InternalServerError, string.Empty)
            };
            
            var result = JsonSerializer.Serialize(new {message});
            await context.Response.WriteAsync(result);
        }
    }
}