using Lab5.Application.Contracts.Admin;
using Spectre.Console;

namespace Presentation.Scenarios.AdminScenarios.AdminScenariosProvider;

public class AdminScenarioProvider : IAdminScenarioProvider
{
    private readonly IAdminLoginService _loginService;
    private readonly IAdminService _adminService;

    public AdminScenarioProvider(
        IAdminLoginService loginService,
        IAdminService adminService)
    {
        _loginService = loginService;
        _adminService = adminService;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        string inputPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter admin password:")
                .Secret());

        if (!_adminService.Authenticate(inputPassword))
        {
            AnsiConsole.WriteLine("Invalid password!");
            Environment.Exit(0);
        }

        return new List<IScenario>
        {
            new AdminLoginScenario(_loginService),
        };
    }
}