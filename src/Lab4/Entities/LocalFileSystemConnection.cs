using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFileSystemConnection : IConnectFileSystem
{
    private readonly INavigateFileSystem _navigator;

    public string? CurrentConnection { get; private set; }

    public LocalFileSystemConnection(INavigateFileSystem navigator)
    {
        _navigator = navigator;
    }

    public void Connect(string address, string? mode)
    {
        if (string.IsNullOrEmpty(address) || !Path.Exists(address))
        {
            Console.WriteLine("Such address does not exist.");
            return;
        }

        CurrentConnection = address;
        _navigator.CurrentPath = address;
        Console.WriteLine($"Connected to {address}");
    }

    public void Disconnect()
    {
        if (CurrentConnection == null)
        {
            Console.WriteLine("No active connection to disconnect.");
            return;
        }

        Console.WriteLine($"Disconnected from {CurrentConnection}");
        CurrentConnection = null;
    }
}