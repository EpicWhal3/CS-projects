using Lab5.Application.Models;

namespace Lab5.Application.Contracts.User;

public abstract record UserOperationResult
{
    public record Success : UserOperationResult;

    public record Balance(double Amount) : UserOperationResult;

    public record Failure(string Message) : UserOperationResult;

    public record UserOperations(IEnumerable<Operation> Operations) : UserOperationResult;
}