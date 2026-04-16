using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public class ShowFileContentHandler : CommandHandler
{
    private readonly ReadFacade _readFacade;

    public ShowFileContentHandler(ReadFacade readFacade)
    {
        _readFacade = readFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "file")
            return PassToNext(args);

        iterator.MoveNext();
        if (!iterator.HasNext() || iterator.Current != "show")
            return PassToNext(args);

        iterator.MoveNext();
        var pathHandler = new PathArgumentHandler();
        pathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(pathHandler.Path))
        {
            Console.WriteLine("Path is required for file show command.");
            return new CreateCommandResult.FailCreate();
        }

        string mode = "console"; // По умолчанию консольный режим
        if (iterator.HasNext() && iterator.Current == "-m")
        {
            iterator.MoveNext();
            if (iterator.HasNext())
            {
                mode = iterator.Current;
            }
            else
            {
                Console.WriteLine("Mode is required after the -m flag.");
                return new CreateCommandResult.FailCreate();
            }
        }

        if (mode != "console")
        {
            Console.WriteLine("Only 'console' mode is supported.");
            return new CreateCommandResult.FailCreate();
        }

        ShowFileContentCommand command = new ShowFileCommandBuilder()
            .WithReadFacade(_readFacade)
            .WithPath(pathHandler.Path)
            .WithMode(mode)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessShowFileContentCommand(command);
    }
}