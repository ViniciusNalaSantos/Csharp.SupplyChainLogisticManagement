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

            //
            //var errorResult = new ErrorResult
            //{
            //    Success = false,
            //    Message = exception.Message,
            //};

            var response = context.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                //await response.WriteAsync(JsonSerializer.Serialize(errorResult));
            }
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = (int)HttpStatusCode.InternalServerError;
        var title = "An unexpected error occurred.";
        object errors = null;

        if (exception is ValidationException validationEx)
        {
            statusCode = (int)HttpStatusCode.BadRequest;
            title = "Validation failed.";
            //errors = validationEx.Errors;
        }

        var problem = new ProblemDetails
        {
            Title = title,
            Status = statusCode,
            Detail = exception.Message,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = statusCode;

        if (errors is IDictionary<string, string[]> validationErrors)
        {
            var validationProblem = new ValidationProblemDetails(validationErrors)
            {
                Title = title,
                Status = statusCode,
                Detail = problem.Detail,
                Instance = problem.Instance
            };

            await context.Response.WriteAsJsonAsync(validationProblem);
        }
        else
        {
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
