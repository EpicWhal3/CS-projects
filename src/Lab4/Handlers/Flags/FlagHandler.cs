using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;

public abstract class FlagHandler
{
    private FlagHandler? _flag;

    public void SetNext(FlagHandler? flag)
    {
        _flag = flag;
    }

    public abstract FlagParseResult Handle(CommandIterator iterator);

    public FlagParseResult PassToNext(CommandIterator iterator)
    {
        return _flag?.Handle(iterator) ?? new FlagParseResult.FailParse();
    }
}