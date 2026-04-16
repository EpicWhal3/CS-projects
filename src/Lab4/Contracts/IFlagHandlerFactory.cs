using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface IFlagHandlerFactory
{
    FlagHandler CreateFlagHandlerChain();
}