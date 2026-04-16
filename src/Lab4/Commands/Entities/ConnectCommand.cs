using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class ConnectCommand : ICommand
{
    private readonly ConnectionFacade _connectionFacade;
    private readonly string _address;
    private readonly string _mode;

    public ConnectCommand(ConnectionFacade connectionFacade, string address, string mode)
    {
        _connectionFacade = connectionFacade;
        _address = address;
        _mode = mode;
    }

    public void Execute()
    {
        _connectionFacade.Connect(_address, _mode);
    }
}