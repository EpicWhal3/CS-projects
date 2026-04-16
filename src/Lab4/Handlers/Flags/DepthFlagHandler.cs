using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;

public class DepthFlagHandler : FlagHandler
{
    private int Depth { get; set; }

    public override FlagParseResult Handle(CommandIterator iterator)
    {
        if (string.IsNullOrWhiteSpace(iterator.Current))
        {
            Depth = 1;
            return new FlagParseResult.SuccessfulParseDepth(Depth);
        }

        if (!iterator.IsFlag() || iterator.Current != "-d") return PassToNext(iterator);

        iterator.MoveNext();
        if (string.IsNullOrWhiteSpace(iterator.Current))
        {
            Console.WriteLine("The Depth level isn't provided");
            return new FlagParseResult.FailParse();
        }

        Depth = int.Parse(iterator.Current);
        return new FlagParseResult.SuccessfulParseDepth(Depth);
    }
}