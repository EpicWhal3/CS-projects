namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public abstract record FlagParseResult
{
    private FlagParseResult() { }

    public sealed record SuccessParseMode : FlagParseResult
    {
        public string Mode { get; }

        public SuccessParseMode(string mode)
        {
            Mode = mode;
        }
    }

    public sealed record SuccessfulParseDepth(int Depth) : FlagParseResult;

    public sealed record FailParse : FlagParseResult;
}