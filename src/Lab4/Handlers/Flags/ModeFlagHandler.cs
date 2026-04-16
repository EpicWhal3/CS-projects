using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;

public class ModeFlagHandler : FlagHandler
{
    public string? Mode { get; private set; } = string.Empty;

    public override FlagParseResult Handle(CommandIterator iterator)
    {
        if (!iterator.IsFlag() || iterator.Current != "-m") return PassToNext(iterator);
        iterator.MoveNext();
        if (string.IsNullOrWhiteSpace(iterator.Current))
        {
            Console.WriteLine("Mode flag is provided but no value is specified.");
            return new FlagParseResult.FailParse();
        }

        Mode = iterator.Current;
        return new FlagParseResult.SuccessParseMode(Mode);
    }
}