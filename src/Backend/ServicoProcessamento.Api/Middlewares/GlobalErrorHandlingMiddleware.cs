using System.Net;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Api.Middlewares;

public class GlobalErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);

        if (context.Items.TryGetValue("AppError", out var appErrorObj) && appErrorObj is AppError appError)
            await HandleAppErrorAsync(context, appError);
    }

    private static Task HandleAppErrorAsync(HttpContext context, AppError appError)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)appError.GetHttpStatusCode();

        var errorResponse = ResponseErrorSelect(context, appError);

        return errorResponse;
    }

    private static Task ResponseErrorSelect(HttpContext context, AppError appError)
    {
        AssemblerErrorValidationResponse(appError, out var errorValidationResponse, out var errorGenericResponse);

        var errorResponse = appError.ErrorType == ErrorType.ValidationRule
            ? context.Response.WriteAsJsonAsync(errorValidationResponse)
            : context.Response.WriteAsJsonAsync(errorGenericResponse);
        return errorResponse;
    }

    private static void AssemblerErrorValidationResponse(AppError appError,
        out ValidationResponseError validationResponseError, out GenericResponseError genericResponseError)
    {
        validationResponseError = new ValidationResponseError(
            appError.GetHttpStatusCode(),
            appError.ErrorType,
            appError.ErrorCodeName,
            appError.GetErrorsMessage()!
        );

        genericResponseError = new GenericResponseError(
            appError.GetHttpStatusCode(),
            appError.ErrorType,
            appError.ErrorCodeName,
            appError.GetErrorsMessage().FirstOrDefault()!
        );
    }
}

internal sealed record ValidationResponseError(
    HttpStatusCode StatusCode,
    ErrorType ErrorType,
    string ErrorCodeName,
    List<string> ErrorsMessages
);

internal sealed record GenericResponseError(
    HttpStatusCode StatusCode,
    ErrorType ErrorType,
    string ErrorCodeName,
    object Message
);