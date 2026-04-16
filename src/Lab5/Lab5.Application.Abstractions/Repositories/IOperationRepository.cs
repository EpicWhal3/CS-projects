using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    IEnumerable<Operation> GetAllOperations(long accountId);
}