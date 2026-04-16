namespace Lab5.Application.Contracts.Admin;

public interface IAdminService
{
    bool Authenticate(string password);
}