using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.E7.EasyResult;

// RailwayExtensions pattern implementation
public static class RailwayExtensions
{
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, AppError error)
    {
        if (result.IsFailure) return result.Error!;
        return predicate(result.Value) ? result.Value! : Result<T>.Failure(error);
    }

    public static Result<T> Ensure<T>(this Task<Result<T>> result, Func<T, bool> predicate, AppError error)
    {
        if (result.Result.IsFailure) return result.Result;
        return predicate(result.Result.Value) ? result.Result : Result<T>.Failure(error)!;
    }


    // Combine: Combines two results into a single result
    public static Result<(T1, T2)> Combine<T1, T2>(this Result<T1> result1, Result<T2> result2)
    {
        if (result1.IsFailure) return Result<(T1, T2)>.Failure(result1.Error!);

        return result2.IsFailure
            ? Result<(T1, T2)>.Failure(result2.Error!)
            : Result<(T1, T2)>.Success((result1.Value, result2.Value));
    }

    public static Result<TIn> Tap<TIn>(this Result<TIn> result, Action<TIn> action)
    {
        if (result.IsSuccess) action(result.Value);
        return result;
    }

    public static async Task<Result<TIn>> Tap<TIn>(this Result<TIn> result, Func<Task<TIn>> func)
    {
        if (result.IsSuccess) await func();
        return result;
    }

    public static async Task<Result<TIn>> Tap<TIn>(this Task<Result<TIn>> resultTask, Func<TIn, Task> func)
    {
        var result = await resultTask;
        if (result.IsSuccess) await func(result.Value);
        return result;
    }

    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> mappingFunc)
    {
        if (result.IsSuccess) return Result<TOut>.Success(mappingFunc(result.Value));
        return Result<TOut>.Failure(result.Error);
    }

    public static async Task<Result<TOut>> Map<TIn, TOut>(
        this Result<TIn> taskResult,
        Func<TIn, Task<TOut>> mapFunction
    )
    {
        if (taskResult.IsSuccess) return await mapFunction(taskResult.Value);
        return Result<TOut>.Failure(taskResult.Error);
    }

    // Bind: Chains a function to the pipeline if the previous result is successful
    public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> func)
    {
        return !result.IsSuccess ? Result<TOut>.Failure(result.Error) : func(result.Value);
    }

    public static Result<TOut> Bind<TIn, TOut>(this Task<Result<TIn>> result, Func<TIn, Result<TOut>> func)
    {
        return !result.Result.IsSuccess ? Result<TOut>.Failure(result.Result.Error) : func(result.Result.Value);
    }

    public static Result<T> MapFailure<T>(this Result<T> result, Func<AppError, AppError> func)
    {
        return result.IsSuccess ? result.Value : Result<T>.Failure(func(result.Error!));
    }

    public static Result<TOut?> TryCatch<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func, AppError appError)
    {
        try
        {
            return result.IsSuccess ? Result<TOut>.Success(func(result.Value)) : Result<TOut>.Failure(result.Error);
        }
        catch
        {
            return Result<TOut>.Failure(appError);
        }
    }

    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<AppError, TOut> onFailure
    )
        => result.IsSuccess ? onSuccess() : onFailure(result.Error!);

    public static TOut Match<T, TOut>(
        this Result<T> result,
        Func<T, TOut> onSuccess,
        Func<AppError, TOut> onFailure
    )
        => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error!);
}