using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DeleteFileCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _path;

    public DeleteFileCommand(NavigationFacade navigationFacade, string path)
    {
        _navigationFacade = navigationFacade;
        _path = path;
    }

    public void Execute()
    {
        if (!Path.Exists(_path)) return;
        _navigationFacade.DeleteFile(_path);
    }
}