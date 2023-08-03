namespace TestApp.Infrastructure.Result;

public abstract class ResultBase
{
    public ErrorDetails? ErrorDetails { get; protected set; }

    public bool IsSuccess => ErrorDetails == null;
}