using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models;

namespace Application.UserServices;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _userRepository;

    private readonly UserService _userServices;

    public UserLoginService(IUserRepository userRepository, UserService userServices)
    {
        _userRepository = userRepository;
        _userServices = userServices;
    }

    public UserLoginResult Login(string name, string passCode)
    {
        User? user = _userRepository.GetUser(name, passCode);
        if (user is null)
            return new UserLoginResult.Failure("Incorrect Id or PIN");
        _userServices.User = user;
        return new UserLoginResult.Success();
    }
}