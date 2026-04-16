using Lab5.Application.Contracts.User;
using Presentation.Scenarios.UserScenarios.UserScenariosProvider;
using Spectre.Console;

namespace Presentation.Scenarios.UserScenarios;

public class UserLoginScenario : IScenario
{
    private readonly IUserLoginService _loginService;
    private readonly IUserScenarioProvider _userScenarioProvider;
    private readonly IActionSelectionScenario _actionSelectionScenario;

    public UserLoginScenario(
        IUserLoginService loginService,
        IUserScenarioProvider userScenarioProvider,
        IActionSelectionScenario actionSelectionScenario)
    {
        _loginService = loginService;
        _userScenarioProvider = userScenarioProvider;
        _actionSelectionScenario = actionSelectionScenario;
    }

    public string Name => "Login";

    public void Run()
    {
        string accountName = AnsiConsole.Ask<string>("Enter your account name: ");
        string pin = AnsiConsole.Prompt(new TextPrompt<string>("Enter 4-digit pin-code: ").Secret());

        UserLoginResult loginResult = _loginService.Login(accountName, pin);
        AnsiConsole.Clear();

        switch (loginResult)
        {
            case UserLoginResult.Failure failure:
                AnsiConsole.Ask<string>(failure.Message);
                break;
            case UserLoginResult.Success:
                _actionSelectionScenario.SetScenarioProvider(_userScenarioProvider);
                _actionSelectionScenario.Run();
                break;
        }
    }
}