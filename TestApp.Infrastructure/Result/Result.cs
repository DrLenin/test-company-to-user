namespace TestApp.Infrastructure.Result;

public class Result<T> : ResultBase
{
    public T Data { get; private set; }

    public static Result<T> Success(T data) => new()
    {
        Data = data
    };

    public static Result<T> Error(ErrorDetails error) => new()
    {
        ErrorDetails = error
    };

    public static implicit operator Result<T>(ErrorDetails errorResponse) => new()
    {
        ErrorDetails = errorResponse
    };

    public static implicit operator Result<T>(T data) => new()
    {
        Data = data
    };
}