using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Facades;

public class ConnectionFacade
{
    private readonly IConnectFileSystem _fileSystem;

    public ConnectionFacade(IConnectFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Connect(string address, string? mode)
    {
        _fileSystem.Connect(address, mode);
    }

    public void Disconnect()
    {
        _fileSystem.Disconnect();
    }
}