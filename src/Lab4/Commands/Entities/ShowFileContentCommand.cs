using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class ShowFileContentCommand : ICommand
{
    private readonly ReadFacade _readFacade;
    private readonly string _path;
    private readonly string _mode;

    public ShowFileContentCommand(
        ReadFacade readFacade,
        string path,
        string mode)
    {
        _readFacade = readFacade;
        _path = path;
        _mode = mode;
    }

    public void Execute()
    {
        _readFacade.ShowFile(_path, _mode);
    }
}