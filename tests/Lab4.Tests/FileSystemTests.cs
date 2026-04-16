using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Xunit;

namespace Lab4.Tests;

public class FileSystemTests
{
    public FileSystemTests()
    {
        var facadeFactory = new FacadeFactory();
        _commandHandlerFactory = new CommandHandlerFactory(
            facadeFactory.CreateConnectionFacade(),
            facadeFactory.CreateNavigationFacade(),
            facadeFactory.CreateReadFacade());
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessConnectCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] args = ["connect", "C:\\TestDirectory", "-m", "local"];

        CreateCommandResult result = commandHandler.Handle(args);

        Assert.True(result is CreateCommandResult.SuccessConnectCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessDisconnectCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = ["connect", "C:\\TestDirectory", "-m", "local"];
        string[] disconnectArgs = ["disconnect"];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(disconnectArgs);

        Assert.True(result is CreateCommandResult.SuccessDisconnectCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessGoToCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = { "connect", "C:\\TestDirectory", "-m", "local" };
        string[] goToArgs = { "tree", "goto", "C:\\TestDirectory" };

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(goToArgs);

        Assert.True(result is CreateCommandResult.SuccessGoToCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessListCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = ["connect", "C:\\TestDirectory", "-m", "local"];
        string[] listArgs = ["tree", "list"];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(listArgs);

        Assert.True(result is CreateCommandResult.SuccessListCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessShowFileContentCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = ["connect", "C:\\TestDirectory", "-m", "local"];
        string[] showFileArgs = ["file", "show", @"C:\TestDirectory\TestFile.txt"];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(showFileArgs);
        Assert.True(result is CreateCommandResult.SuccessShowFileContentCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessMoveFileCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = ["connect", "C:\\TestDirectory", "-m", "local"];
        string[] moveFileArgs =
        [
            "file", "move", @"C:\TestDirectory\TestFile.txt", @"C:\TestDirectory\TestDirectory2\TestFile.txt"
        ];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(moveFileArgs);

        Assert.True(result is CreateCommandResult.SuccessMoveFileCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessCopyFileCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = { "connect", "C:\\TestDirectory", "-m", "local" };
        string[] copyFileArgs =
            ["file", "copy", @"C:\TestDirectory\TestFile.txt", @"C:\TestDirectory\TestFile2.txt"];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(copyFileArgs);

        Assert.True(result is CreateCommandResult.SuccessCopyFileCommand);
    }

    [Fact]
    public void CreateCommand_ShouldReturnSuccessRenameFileCommand()
    {
        CommandHandler commandHandler = CreateCommandHandler();
        string[] connectArgs = ["connect", "C:\\TestDirectory", "-m", "local"];
        string[] renameFileArgs = ["file", "rename", @"C:\TestDirectory\TestFile.txt", "TestFile2.txt"];

        commandHandler.Handle(connectArgs);
        CreateCommandResult result = commandHandler.Handle(renameFileArgs);

        Assert.True(result is CreateCommandResult.SuccessRenameFileCommand);
    }

    private CommandHandler CreateCommandHandler()
    {
        return _commandHandlerFactory.CreateCommandHandlerChain();
    }

    private readonly CommandHandlerFactory _commandHandlerFactory;
}