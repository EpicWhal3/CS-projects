namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface IConnectFileSystem
{
    void Connect(string address, string? mode);

    void Disconnect();
}