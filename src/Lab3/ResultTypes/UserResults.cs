namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record UserResults
{
    private UserResults() { }

    public sealed record SuccessRead(string Success) : UserResults;

    public sealed record AlreadyRead(string Error) : UserResults;

    public sealed record IndexOutOfRange(string Error) : UserResults;
}