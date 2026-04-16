using Itmo.ObjectOrientedProgramming.Lab4.Contracts;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class MoveFileCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveFileCommand(
        NavigationFacade navigationFacade,
        string sourcePath,
        string destinationPath)
    {
        _navigationFacade = navigationFacade;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _navigationFacade.MoveFile(_sourcePath, _destinationPath);
    }
}