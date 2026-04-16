using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var navigator = new LocalFileNavigator();
        var reader = new LocalFileReader(navigator);
        var connector = new LocalFileSystemConnection(navigator);

        var connectionFacade = new ConnectionFacade(connector);
        var navigationFacade = new NavigationFacade(navigator);
        var readFacade = new ReadFacade(reader, navigator);

        var commandHandlerFactory =
            new CommandHandlerFactory(connectionFacade, navigationFacade, readFacade);

        var commandParser = new CommandParser(commandHandlerFactory);

        var consoleInterface = new ConsoleInterface(commandParser);

        consoleInterface.Run();
    }
}