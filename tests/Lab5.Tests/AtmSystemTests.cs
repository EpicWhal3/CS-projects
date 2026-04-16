using Application.UserServices;
using Lab5.Application.Abstractions.Models;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models;
using Xunit;

namespace Lab5.Tests;

public class AtmSystemTests
{
    [Fact]
    public void DepositMoneyTest_CorrectResult()
    {
        var userService = new UserService(new MockUserRepo(), new MockOperationsRepo())
        {
            User = new User(123, "John", "1234", 123),
        };
        UserOperationResult result = userService.MoneyChange(10);
        Assert.IsType<UserOperationResult.Success>(result);
        Assert.Equal(133, userService.User.Money);
    }

    [Fact]
    public void WithdrawMoneyTest_CorrectResult()
    {
        var userService = new UserService(new MockUserRepo(), new MockOperationsRepo())
        {
            User = new User(123, "John", "1234", 123),
        };
        UserOperationResult result = userService.MoneyChange(-10);
        Assert.IsType<UserOperationResult.Success>(result);
        Assert.Equal(113, userService.User.Money);
    }

    [Fact]
    public void TryToWithdrawExceedAmount_Failure()
    {
        var userService = new UserService(new MockUserRepo(), new MockOperationsRepo())
        {
            User = new User(123, "John", "1234", 123),
        };
        UserOperationResult result = userService.MoneyChange(-100000);
        Assert.IsType<UserOperationResult.Failure>(result);
    }

    private class MockUserRepo : IUserRepository
    {
        public void AddUser(string name, string pinCode) { }

        public User? GetUser(string name, string pinCode)
        {
            return null;
        }

        public DataBaseOperationResults MoneyExchange(User user, double amount)
        {
            return amount + user.Money < 0
                ? new DataBaseOperationResults.Failure("not enough")
                : new DataBaseOperationResults.Success(user with { Money = user.Money + amount });
        }
    }

    private class MockOperationsRepo : IOperationRepository
    {
        public IEnumerable<Operation> GetAllOperations(long accountId)
        {
            return new List<Operation>();
        }
    }
}