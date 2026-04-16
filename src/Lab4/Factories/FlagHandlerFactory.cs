using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class FlagHandlerFactory : IFlagHandlerFactory
{
    public FlagHandler CreateFlagHandlerChain()
    {
        FlagHandler mode = new ModeFlagHandler();
        FlagHandler depth = new DepthFlagHandler();

        mode.SetNext(depth);
        depth.SetNext(null);
        return mode;
    }
}