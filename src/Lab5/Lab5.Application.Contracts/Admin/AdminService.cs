namespace Lab5.Application.Contracts.Admin;

public class AdminService : IAdminService
{
    private readonly string _systemPassword;

    public AdminService(string systemPassword)
    {
        _systemPassword = systemPassword;
    }

    public bool Authenticate(string password)
    {
        return password == _systemPassword;
    }
}