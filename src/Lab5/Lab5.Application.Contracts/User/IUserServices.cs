namespace Lab5.Application.Contracts.User;

public interface IUserServices
{
    UserOperationResult GetBalance();

    UserOperationResult MoneyChange(double amount);

    UserOperationResult UserOperationHistory();

    UserCreationResult CreateUser(string name, string pinCode);

    void Logout();
}