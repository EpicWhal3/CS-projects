using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DisconnectCommand : ICommand
{
    private readonly ConnectionFacade _connectionFacade;

    public DisconnectCommand(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
    }

    public void Execute()
    {
        _connectionFacade.Disconnect();
    }
}