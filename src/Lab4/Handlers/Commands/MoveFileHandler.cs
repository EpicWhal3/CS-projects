using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public class MoveFileHandler : CommandHandler
{
    private readonly NavigationFacade _navigationFacade;

    public MoveFileHandler(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "file")
            return PassToNext(args);

        iterator.MoveNext();

        if (!iterator.HasNext() || iterator.Current != "move")
            return PassToNext(args);

        iterator.MoveNext();

        var sourcePathHandler = new PathArgumentHandler();
        sourcePathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(sourcePathHandler.Path))
        {
            Console.WriteLine("Source path is required for file move command.");
            return new CreateCommandResult.FailCreate();
        }

        iterator.MoveNext();

        var destinationPathHandler = new PathArgumentHandler();
        destinationPathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(destinationPathHandler.Path))
        {
            Console.WriteLine("Destination path is required for file move command.");
            return new CreateCommandResult.FailCreate();
        }

        MoveFileCommand command = new MoveFileCommandBuilder()
            .WithNavigationFacade(_navigationFacade)
            .WithSourcePath(sourcePathHandler.Path)
            .WithDestinationPath(destinationPathHandler.Path)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessMoveFileCommand(command);
    }
}