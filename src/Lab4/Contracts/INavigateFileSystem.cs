namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface INavigateFileSystem
{
    string? CurrentPath { get; set; }

    void ChangeDirectory(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string newName);
}