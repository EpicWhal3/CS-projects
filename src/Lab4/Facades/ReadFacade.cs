using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Facades;

public class ReadFacade
{
    private readonly IReadFileSystem _reader;
    private readonly INavigateFileSystem _navigator;

    public ReadFacade(IReadFileSystem fileSystem, INavigateFileSystem navigator)
    {
        _reader = fileSystem;
        _navigator = navigator;
    }

    public IEnumerable<string> ListDirectory(string path, int depth)
    {
        return _reader.ListDirectory(path, depth);
    }

    public string GetCurrentPath()
    {
        if (_navigator.CurrentPath != null) return _navigator.CurrentPath;

        Console.WriteLine("No path selected");
        return string.Empty;
    }

    public void ShowFile(string path, string? mode = null)
    {
        _reader.ShowFile(path, mode);
    }
}