using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.UserScenarios;

public class ExitToMainMenuScenario : IScenario
{
    private readonly IUserServices _userService;

    public ExitToMainMenuScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Exit to main menu";

    public void Run()
    {
        _userService.Logout();
        AnsiConsole.WriteLine("You logged out.");
        AnsiConsole.Ask<string>("Enter any symbol to continue.");
    }
}