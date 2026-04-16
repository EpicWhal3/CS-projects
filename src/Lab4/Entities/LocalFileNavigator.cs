using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFileNavigator : INavigateFileSystem
{
    public LocalFileNavigator()
    {
        CurrentPath = Directory.GetCurrentDirectory();
    }

    public string? CurrentPath { get; set; }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath) || !Path.Exists(destinationPath))
        {
            Console.WriteLine($"File {sourcePath} not found.");
            return;
        }

        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        if (CurrentPath == null) return;

        string source = Path.Combine(CurrentPath, sourcePath);
        string destination = Path.Combine(CurrentPath, destinationPath);
        if (!File.Exists(source))
        {
            Console.WriteLine($"File {sourcePath} not found.");
            return;
        }

        File.Copy(source, destination);
    }

    public void DeleteFile(string path)
    {
        if (CurrentPath == null) return;

        string fullPath = Path.Combine(CurrentPath, path);
        if (!File.Exists(fullPath))
            Console.WriteLine($"File {path} not found.");

        File.Delete(fullPath);
    }

    public void RenameFile(string path, string newName)
    {
        if (CurrentPath == null) return;

        string fullPath = Path.Combine(CurrentPath, path);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File {path} not found.");
            return;
        }

        string? directory;

        if (Path.GetDirectoryName(fullPath) != null)
        {
            directory = Path.GetDirectoryName(fullPath);
        }
        else
        {
            Console.WriteLine("Directory cannot be determined.");
            return;
        }

        if (directory == null) return;

        string newFullPath = Path.Combine(directory, newName);

        if (File.Exists(newFullPath))
        {
            Console.WriteLine($"A file with the name {newName} already exists.");
            return;
        }

        File.Move(fullPath, newFullPath);
    }

    public void ChangeDirectory(string path)
    {
        if (CurrentPath == null)
        {
            Console.WriteLine("Not connected");
            return;
        }

        string newPath = Path.Combine(CurrentPath, path);
        if (!Directory.Exists(newPath))
        {
            Console.WriteLine("Directory does not exist");
            return;
        }

        CurrentPath = newPath;
    }
}