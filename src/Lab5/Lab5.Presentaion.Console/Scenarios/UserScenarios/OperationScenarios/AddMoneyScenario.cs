using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios.UserScenarios.OperationScenarios;

public class AddMoneyScenario : IScenario
{
    private readonly IUserServices _userService;

    public AddMoneyScenario(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Add money";

    public void Run()
    {
        double amount = AnsiConsole.Ask<double>("Enter amount: ");
        if (amount < 0)
        {
            AnsiConsole.WriteLine("Amount must be greater than 0");
            return;
        }

        UserOperationResult result = _userService.MoneyChange(amount);

        switch (result)
        {
            case UserOperationResult.Failure failure:
                AnsiConsole.WriteLine(failure.Message);
                break;
            case UserOperationResult.Success:
                AnsiConsole.WriteLine("Money added successfully");
                break;
        }

        AnsiConsole.Ask<string>("Waiting");
        AnsiConsole.Clear();
    }
}