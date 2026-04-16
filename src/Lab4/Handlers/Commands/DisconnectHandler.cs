using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

public class DisconnectHandler : CommandHandler
{
    private readonly ConnectionFacade _connectionFacade;

    public DisconnectHandler(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (iterator.Current != "disconnect")
            return PassToNext(args);

        DisconnectCommand command = new DisconnectCommandBuilder()
            .WithConnectionFacade(_connectionFacade)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessDisconnectCommand(command);
    }
}