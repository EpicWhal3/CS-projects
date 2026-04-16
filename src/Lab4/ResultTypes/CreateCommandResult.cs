using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public abstract record CreateCommandResult
{
    private CreateCommandResult() { }

    public sealed record SuccessConnectCommand : CreateCommandResult
    {
        public ConnectCommand Cmd { get; }

        public SuccessConnectCommand(ConnectCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessDisconnectCommand : CreateCommandResult
    {
        public ICommand Cmd { get; }

        public SuccessDisconnectCommand(DisconnectCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessGoToCommand : CreateCommandResult
    {
        public GoToCommand Cmd { get; }

        public SuccessGoToCommand(GoToCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessListCommand : CreateCommandResult
    {
        public ListCommand Cmd { get; }

        public SuccessListCommand(ListCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessShowFileContentCommand : CreateCommandResult
    {
        public ShowFileContentCommand Cmd { get; }

        public SuccessShowFileContentCommand(ShowFileContentCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessMoveFileCommand : CreateCommandResult
    {
        public MoveFileCommand Cmd { get; }

        public SuccessMoveFileCommand(MoveFileCommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessCopyFileCommand : CreateCommandResult
    {
        public ICommand Cmd { get; }

        public SuccessCopyFileCommand(ICommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessDeleteFileCommand : CreateCommandResult
    {
        public ICommand Cmd { get; }

        public SuccessDeleteFileCommand(ICommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record SuccessRenameFileCommand : CreateCommandResult
    {
        public ICommand Cmd { get; }

        public SuccessRenameFileCommand(ICommand cmd)
        {
            Cmd = cmd;
        }
    }

    public sealed record FailCreate : CreateCommandResult;
}