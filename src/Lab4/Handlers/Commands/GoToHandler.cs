using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public class GoToHandler : CommandHandler
{
    private readonly NavigationFacade _navigationFacade;

    public GoToHandler(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "tree")
            return PassToNext(args);

        iterator.MoveNext();
        if (!iterator.HasNext() || iterator.Current != "goto")
            return PassToNext(args);

        iterator.MoveNext();
        var pathHandler = new PathArgumentHandler();
        pathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(pathHandler.Path))
        {
            Console.WriteLine("Path is required for tree goto command.");
            return new CreateCommandResult.FailCreate();
        }

        GoToCommand command = new GoToCommandBuilder()
            .WithNavigationFacade(_navigationFacade)
            .WithPath(pathHandler.Path)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessGoToCommand(command);
    }
}