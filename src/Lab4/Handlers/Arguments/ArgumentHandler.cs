using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Arguments;

public abstract class ArgumentHandler
{
    private ArgumentHandler? _nextHandler;

    public void SetNext(ArgumentHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void Handle(CommandIterator iterator);

    protected void PassToNext(CommandIterator iterator)
    {
        _nextHandler?.Handle(iterator);
    }
}