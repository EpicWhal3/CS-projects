using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Models;

public abstract record DataBaseOperationResults
{
    public record Success(User User) : DataBaseOperationResults;

    public record NoFunds(User CurrentUser) : DataBaseOperationResults;

    public record Failure(string Message) : DataBaseOperationResults;
}