using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Arguments;

public class PathArgumentHandler : ArgumentHandler
{
    public string? Path { get; private set; }

    public override void Handle(CommandIterator iterator)
    {
        if (!string.IsNullOrWhiteSpace(iterator.Current))
        {
            Path = iterator.Current;
        }
        else
        {
            Console.WriteLine("Path is required but not provided.");
        }

        PassToNext(iterator);
    }
}