using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class GoToCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _path;

    public GoToCommand(NavigationFacade navigationFacade, string path)
    {
        _navigationFacade = navigationFacade;
        _path = path;
    }

    public void Execute()
    {
        _navigationFacade.ChangeDirectory(_path);
    }
}