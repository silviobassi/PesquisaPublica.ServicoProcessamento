using OneOf;
using ServicoProcessamento.Communication.Errors;

namespace ServicoProcessamento.Application.Extensions;

public static class OneOfExtensions
{
    public static bool IsSuccess<TResult>(this OneOf<TResult, AppError> oneOf) => oneOf.IsT0;
    public static TResult GetSuccessResult<TResult>(this OneOf<TResult, AppError> oneOf) => oneOf.AsT0;

    public static bool IsFailure<TResult>(this OneOf<TResult, AppError> oneOf) => oneOf.IsT1;
    public static AppError GetFailureError<TResult>(this OneOf<TResult, AppError> oneOf) => oneOf.AsT1;
}