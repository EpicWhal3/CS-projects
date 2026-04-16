using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Facades;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class RenameFileCommandBuilder
{
    private NavigationFacade? _navigationFacade;
    private string? _path;
    private string? _newName;

    public RenameFileCommandBuilder WithNavigationFacade(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
        return this;
    }

    public RenameFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public RenameFileCommandBuilder WithNewName(string newName)
    {
        _newName = newName;
        return this;
    }

    public RenameFileCommand Build()
    {
        return new RenameFileCommand(
            _navigationFacade ?? throw new ArgumentNullException(nameof(_navigationFacade)),
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _newName ?? throw new ArgumentNullException(nameof(_newName)));
    }
}