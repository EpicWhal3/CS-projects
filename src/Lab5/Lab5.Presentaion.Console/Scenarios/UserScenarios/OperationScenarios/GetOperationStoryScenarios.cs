using Lab5.Application.Contracts.User;
using Lab5.Application.Models;
using Spectre.Console;

namespace Presentation.Scenarios.UserScenarios.OperationScenarios;

public class GetOperationStoryScenarios : IScenario
{
    private readonly IUserServices _userService;

    public GetOperationStoryScenarios(IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Get operation story";

    public void Run()
    {
        UserOperationResult operationStory = _userService.UserOperationHistory();

        if (operationStory is UserOperationResult.UserOperations operations)
        {
            var table = new Table();
            table.AddColumn("Date");
            table.AddColumn("Start Balance");
            table.AddColumn("Change");
            table.AddColumn("Current Balance");
            table.AddColumn("Operation ID");

            foreach (Operation oper in operations.Operations)
            {
                table.AddRow(
                    oper.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    oper.AmountBefore.ToString("F2"),
                    oper.Change.ToString("F2"),
                    (oper.AmountBefore + oper.Change).ToString("F2"),
                    oper.OperationId.ToString());
            }

            AnsiConsole.Write(table);
        }
        else if (operationStory is UserOperationResult.Failure failure)
        {
            AnsiConsole.WriteLine(failure.Message);
        }

        AnsiConsole.Ask<string>("Press any key to continue");
        AnsiConsole.Clear();
    }
}