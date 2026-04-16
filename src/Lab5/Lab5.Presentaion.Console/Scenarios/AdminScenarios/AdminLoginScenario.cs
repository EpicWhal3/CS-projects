using Lab5.Application.Contracts.Admin;
using Spectre.Console;

namespace Presentation.Scenarios.AdminScenarios;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminLoginService _loginService;

    public AdminLoginScenario(
        IAdminLoginService loginService)
    {
        _loginService = loginService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");

        AdminLoginResult loginResult = _loginService.Login(password);
        AnsiConsole.Clear();
        switch (loginResult)
        {
            case AdminLoginResult.Failure failure:
                AnsiConsole.Ask<string>(failure.Message);
                Environment.Exit(0);
                break;
            case AdminLoginResult.Success:
                break;
        }
    }
}