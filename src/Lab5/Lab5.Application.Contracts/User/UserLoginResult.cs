namespace Lab5.Application.Contracts.User;

public record UserLoginResult()
{
    public record Success : UserLoginResult;

    public record Failure(string Message) : UserLoginResult;
}