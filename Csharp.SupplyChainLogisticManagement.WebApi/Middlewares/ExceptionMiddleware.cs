using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Csharp.SupplyChainLogisticManagement.WebApi.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";        

        var statusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.StatusCode = statusCode;

        var title = "An unexpected error occurred.";
        if (statusCode == (int)HttpStatusCode.InternalServerError)
        {
            title = "Internal Server Error.";
        }

        var errors = new Dictionary<string, string[]>();
        if (exception is ValidationException validationEx)
        {
            statusCode = (int)HttpStatusCode.BadRequest;
            title = "Validation failed.";
            errors.Add("Datafield validation: ", new string[] { validationEx.Message });
        }

        var validationProblem = new ValidationProblemDetails()
        {
            Title = title,
            Status = statusCode,
            Detail = exception.Message,
            Instance = context.Request.Path,
            Errors = errors
        };

        await context.Response.WriteAsJsonAsync(validationProblem);
    }
}
