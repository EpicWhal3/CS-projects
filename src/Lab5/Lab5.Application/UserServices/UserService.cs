using Lab5.Application.Abstractions.Models;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models;
using Microsoft.IdentityModel.Tokens;

namespace Application.UserServices;

public class UserService : IUserServices
{
    private readonly IUserRepository _userRepository;

    private readonly IOperationRepository _operationRepository;

    public UserService(IUserRepository userRepository, IOperationRepository operationRepository)
    {
        _userRepository = userRepository;

        _operationRepository = operationRepository;
    }

    public User? User { get; set; }

    public UserOperationResult GetBalance()
    {
        return User is null
            ? new UserOperationResult.Failure("Such user is not available or isn't existing")
            : new UserOperationResult.Balance(User.Money);
    }

    public UserCreationResult CreateUser(string name, string pinCode)
    {
        if (name.IsNullOrEmpty())
            return new UserCreationResult.Failure("Id cannot be non-positive");

        if (!int.TryParse(pinCode, out _) || pinCode.Length != 4)
            return new UserCreationResult.Failure("Invalid PIN code");

        _userRepository.AddUser(name, pinCode);
        return new UserCreationResult.Success();
    }

    public UserOperationResult MoneyChange(double amount)
    {
        if (User is null)
            return new UserOperationResult.Failure("Such user is not available or isn't existing");

        DataBaseOperationResults dbRequest = _userRepository.MoneyExchange(User, amount);

        switch (dbRequest)
        {
            case DataBaseOperationResults.Failure failure:
                return new UserOperationResult.Failure(failure.Message);

            case DataBaseOperationResults.Success success:
                User = success.User;
                return new UserOperationResult.Success();

            case DataBaseOperationResults.NoFunds notEnoughMoney:
                User = notEnoughMoney.CurrentUser;
                return new UserOperationResult.Failure("Not enough money");

            default:
                return new UserOperationResult.Failure("Unknown error appeared");
        }
    }

    public UserOperationResult UserOperationHistory()
    {
        return User is null
            ? new UserOperationResult.Failure("Such user is not available or isn't existing")
            : new UserOperationResult.UserOperations(_operationRepository.GetAllOperations(User.Id));
    }

    public void Logout()
    {
        User = null;
    }
}