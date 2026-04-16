using Lab5.Application.Abstractions.Models;
using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    public void AddUser(string name, string pinCode);

    public User? GetUser(string name, string pinCode);

    public DataBaseOperationResults MoneyExchange(User user, double amount);
}