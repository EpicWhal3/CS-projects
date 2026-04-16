using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public class ListHandler : CommandHandler
{
    private readonly ReadFacade _readFacade;

    public ListHandler(ReadFacade navigator)
    {
        _readFacade = navigator;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "tree")
            return PassToNext(args);

        iterator.MoveNext();

        if (iterator.Current != "list")
            return PassToNext(args);

        iterator.MoveNext();

        int depth = 1;

        var flagHandlerFactory = new FlagHandlerFactory();
        FlagHandler flagHandler = flagHandlerFactory.CreateFlagHandlerChain();

        FlagParseResult flagResult = flagHandler.Handle(iterator);

        switch (flagResult)
        {
            case FlagParseResult.SuccessfulParseDepth depthResult:
                depth = depthResult.Depth;
                break;

            case FlagParseResult.FailParse:
                Console.WriteLine("Invalid flag or value.");
                return new CreateCommandResult.FailCreate();
        }

        var visitor = new ConsoleVisitor();

        ListCommand command = new ListCommandBuilder()
            .WithVisitor(visitor)
            .WithReadFacade(_readFacade)
            .WithDepth(depth)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessListCommand(command);
    }
}