using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class MoveFileCommandBuilder
{
    private NavigationFacade? _navigationFacade;
    private string? _sourcePath;
    private string? _destinationPath;

    public MoveFileCommandBuilder WithNavigationFacade(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
        return this;
    }

    public MoveFileCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public MoveFileCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public MoveFileCommand Build()
    {
        return new MoveFileCommand(
            _navigationFacade ?? throw new ArgumentNullException(nameof(_navigationFacade)),
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}