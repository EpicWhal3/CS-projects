using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public abstract class CommandHandler
{
    private CommandHandler? _nextHandler;

    public void SetNext(CommandHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract CreateCommandResult Handle(string[] args);

    public CreateCommandResult PassToNext(string[] args)
    {
        return _nextHandler?.Handle(args) ?? new CreateCommandResult.FailCreate();
    }
}