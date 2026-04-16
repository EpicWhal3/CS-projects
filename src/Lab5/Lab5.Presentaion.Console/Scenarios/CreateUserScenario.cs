using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Presentation.Scenarios;

public class CreateUserScenario : IScenario
{
    private readonly IUserServices _userService;

    public CreateUserScenario(
        IUserServices userService)
    {
        _userService = userService;
    }

    public string Name => "Create User";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Input your Account Name: ");
        string pinCode = AnsiConsole.Prompt(
            new TextPrompt<string>("Input 4-digit PIN: ")
                .Validate(p => p.Length == 4 && p.All(char.IsDigit))
                .Secret());

        UserCreationResult result = _userService.CreateUser(name, pinCode);

        string message = result switch
        {
            UserCreationResult.Success => "User created successfully!",
            UserCreationResult.Failure failure => failure.Message,
            _ => "Unknown error occurred",
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue");
        AnsiConsole.Clear();
    }
}