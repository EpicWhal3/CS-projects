using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Drivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Colorize(string text)
    {
        Console.WriteLine(Black(text));
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}