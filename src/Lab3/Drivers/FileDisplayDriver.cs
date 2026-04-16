using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab3.Drivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _path;

    public FileDisplayDriver(string path)
    {
        _path = path;
    }

    public void Clear()
    {
        File.WriteAllText(_path, string.Empty);
    }

    public void Colorize(string text)
    {
        Output.Green(text);
    }

    public void Write(string text)
    {
        File.WriteAllText(_path, text);
    }
}