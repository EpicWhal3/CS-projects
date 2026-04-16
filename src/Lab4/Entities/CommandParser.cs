using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class CommandParser
{
    private readonly CommandHandler _commandHandler;

    public CommandParser(CommandHandlerFactory commandHandlerFactory)
    {
        _commandHandler = commandHandlerFactory.CreateCommandHandlerChain();
    }

    public void ParseAndExecute(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No command provided.");
            return;
        }

        string[] args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        CreateCommandResult result = _commandHandler.Handle(args);

        Console.WriteLine(result is CreateCommandResult.FailCreate
            ? "Command execution failed."
            : "Command executed successfully.");
    }
}