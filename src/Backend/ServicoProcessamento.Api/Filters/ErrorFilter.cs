using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServicoProcessamento.Communication.Errors;

namespace ServicoProcessamento.Api.Filters;

public class ErrorFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context) =>
        HandleAppErrorAsync(context, context.HttpContext.Items["AppError"] as AppError);

    private static void HandleAppErrorAsync(ExceptionContext context, AppError? appError)
    {
        if (appError is null) return;

        var errorResponse = new ErrorResponse(
            appError.ErrorType,
            appError.ErrorCodeName,
            appError.GetErrorsMessage(),
            appError.GetHttpStatusCode());

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = (int)appError.GetHttpStatusCode()
        };
    }
}

internal sealed record ErrorResponse(
    ErrorType ErrorType,
    string ErrorCodeName,
    List<string?> Message,
    HttpStatusCode StatusCode);