namespace Lab5.Application.Contracts.User;

public abstract record UserCreationResult
{
    public record Success : UserCreationResult;

    public record Failure(string Message) : UserCreationResult;
}