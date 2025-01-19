using Microsoft.AspNetCore.Mvc;

namespace ServicoProcessamento.Communication.Errors;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;
    public AppError? Error { get; }

    protected Result(bool isSuccess, AppError? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(AppError? error) => new(false, error);

    public static implicit operator Result(AppError error) => Failure(error);
    public bool IsErrorType(ErrorType errorType) => Error?.ErrorType == errorType;

    public IActionResult Match(Func<IActionResult> onSuccess, Func<AppError, IActionResult> onFailure) =>
        IsSuccess ? onSuccess() : onFailure(Error!);

    public override string ToString() => IsSuccess ? "Success" : $"Failure: {Error}";
}

public class Result<T> : Result
{
    public T Value { get; }

    private Result(T value, bool isSuccess, AppError? error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(value, true, null);
    public new static Result<T?> Failure(AppError? error) => new(default, false, error);

    // Operador implícito para sucesso (de T para Result<T>)
    public static implicit operator Result<T>(T value) => Success(value);

    // Operador implícito para erro (de AppError para Result<T>)
    public static implicit operator Result<T?>(AppError error) => Failure(error);

    public override string ToString() => IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
}