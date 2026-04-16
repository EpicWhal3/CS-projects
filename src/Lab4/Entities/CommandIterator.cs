namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class CommandIterator
{
    private readonly string[] _args;
    private int _currentIndex = 0;

    public CommandIterator(string[] args)
    {
        _args = args;
    }

    public bool HasNext()
    {
        return _currentIndex + 1 < _args.Length;
    }

    public void MoveNext()
    {
        _currentIndex++;
    }

    public string Current => _currentIndex >= 0
                             && _currentIndex < _args.Length
        ? _args[_currentIndex]
        : string.Empty;

    public bool IsFlag()
    {
        return Current?.StartsWith('-') ?? false;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}