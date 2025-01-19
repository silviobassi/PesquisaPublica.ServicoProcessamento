namespace ServicoProcessamento.Communication.Errors;

public class Result
{
    public bool IsSuccess { get; }
    public AppError? Error { get; }

    protected Result(bool isSuccess, AppError? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);
    public static Result Failure(AppError? error) => new Result(false, error);

    public static implicit operator Result(AppError error) => Failure(error);
    public bool IsErrorType(ErrorType errorType) => Error?.ErrorType == errorType;

    public T Match<T>(Func<T> onSuccess, Func<AppError, T> onFailure)
    {
        return IsSuccess ? onSuccess() : onFailure(Error!);
    }
    public override string ToString()
    {
        return IsSuccess ? "Success" : $"Failure: {Error}";
    }
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

    public override string ToString()
    {
        return IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
    }
}