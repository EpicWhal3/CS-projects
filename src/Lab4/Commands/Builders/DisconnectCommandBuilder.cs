using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class DisconnectCommandBuilder
{
    private ConnectionFacade? _connectionFacade;

    public DisconnectCommandBuilder WithConnectionFacade(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
        return this;
    }

    public DisconnectCommand Build()
    {
        return new DisconnectCommand(
            _connectionFacade ?? throw new ArgumentNullException(nameof(_connectionFacade)));
    }
}