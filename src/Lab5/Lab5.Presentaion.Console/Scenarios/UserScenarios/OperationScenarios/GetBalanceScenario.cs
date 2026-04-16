using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.UserScenarios.OperationScenarios;

public class GetBalanceScenario : IScenario
{
    private readonly IUserServices _userService;

    public GetBalanceScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Get balance";

    public void Run()
    {
        UserOperationResult balanceResult = _userService.GetBalance();

        switch (balanceResult)
        {
            case UserOperationResult.Failure failure:
                AnsiConsole.WriteLine(failure.Message);
                break;
            case UserOperationResult.Balance success:
                AnsiConsole.WriteLine($"Your balance: {success.Amount}");
                break;
        }

        AnsiConsole.Ask<string>("Press any key to continue");
        AnsiConsole.Clear();
    }
}