using System.Net;
using System.Text.Json;

namespace TalaTask.API.src.Utils;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //var response = _environment.IsDevelopment()
            //    ? new AppException(context.Response.StatusCode, ex.Message, ex.StackTrace ?? string.Empty)
            //   : new AppException(context.Response.StatusCode, "Ha ocurrido un error interno");

            var response = new AppException(context.Response.StatusCode, "Ha ocurrido un error interno");

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}