using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Facades;

public class NavigationFacade
{
    private readonly INavigateFileSystem _fileSystem;

    public NavigationFacade(INavigateFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void ChangeDirectory(string path)
    {
        _fileSystem.ChangeDirectory(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        _fileSystem.DeleteFile(path);
    }

    public void RenameFile(string path, string newName)
    {
        _fileSystem.RenameFile(path, newName);
    }
}