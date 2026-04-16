using Lab5.Application.Contracts.Admin;

namespace Application.AdminServices;

public class AdminLoginService : IAdminLoginService
{
    public AdminLoginResult Login(string password)
    {
        return password == "AdminPassword"
            ? new AdminLoginResult.Success()
            : new AdminLoginResult.Failure("Incorrect password");
    }
}