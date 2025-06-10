using Csharp.SupplyChainLogisticManagement.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        
        var title = string.Empty;
        var details = exception.Message;
        if (statusCode == (int)HttpStatusCode.InternalServerError)
        {
            title = "Internal Server Error.";
        }

        var errorsDictionary = new Dictionary<string, List<string>>();
        if (exception is ValidationException validationEx)
        {
            statusCode = (int)HttpStatusCode.BadRequest;
            title = "Validation failed.";
            errorsDictionary["Datafield validation"] = new List<string>() { validationEx.Message };            
        }        

        if (exception is ValidationServiceException validationServiceException)
        {
            statusCode = (int)HttpStatusCode.BadRequest;
            title = validationServiceException.Title;
            details = "One or more fields have invalid values. See 'errors'.";            
                        
            foreach (var error in validationServiceException.Errors)
            {
                if (error.OrderNumber.IsNullOrEmpty())
                    error.OrderNumber = "NullOrderNumber";
                                  
                if (!errorsDictionary.TryGetValue(error.OrderNumber, out var val))
                {
                    val = new List<string>();
                    errorsDictionary[error.OrderNumber] = val;
                }
                val.Add(error.Message);
            }
        }

        var returnErrorDetails = new ReturnErrorDetails()
        {
            Title = title,
            Status = statusCode,
            Detail = details,
            Instance = context.Request.Path,
            Errors = errorsDictionary
        };

        await context.Response.WriteAsJsonAsync(returnErrorDetails);
    }
}
