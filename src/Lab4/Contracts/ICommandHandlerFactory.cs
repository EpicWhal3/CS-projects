using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface ICommandHandlerFactory
{
    CommandHandler CreateCommandHandlerChain();
}