using Itmo.ObjectOrientedProgramming.Lab4.Facades;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class CommandHandlerFactory
{
    private readonly ConnectionFacade _connectionFacade;
    private readonly NavigationFacade _navigationFacade;
    private readonly ReadFacade _readFacade;

    public CommandHandlerFactory(
        ConnectionFacade connectionFacade,
        NavigationFacade navigationFacade,
        ReadFacade readFacade)
    {
        _connectionFacade = connectionFacade;
        _navigationFacade = navigationFacade;
        _readFacade = readFacade;
    }

    public CommandHandler CreateCommandHandlerChain()
    {
        CommandHandler connectHandler = new ConnectHandler(_connectionFacade);
        CommandHandler disconnectHandler = new DisconnectHandler(_connectionFacade);
        CommandHandler copyFileHandler = new CopyFileHandler(_navigationFacade);
        CommandHandler deleteFileHandler = new DeleteFileHandler(_navigationFacade);
        CommandHandler goToHandler = new GoToHandler(_navigationFacade);
        CommandHandler listHandler = new ListHandler(_readFacade);
        CommandHandler moveFileHandler = new MoveFileHandler(_navigationFacade);
        CommandHandler renameFileHandler = new RenameFileHandler(_navigationFacade);
        CommandHandler showContentHandler = new ShowFileContentHandler(_readFacade);

        connectHandler.SetNext(disconnectHandler);
        disconnectHandler.SetNext(copyFileHandler);
        copyFileHandler.SetNext(deleteFileHandler);
        deleteFileHandler.SetNext(goToHandler);
        goToHandler.SetNext(listHandler);
        listHandler.SetNext(moveFileHandler);
        moveFileHandler.SetNext(renameFileHandler);
        renameFileHandler.SetNext(showContentHandler);

        return connectHandler;
    }
}