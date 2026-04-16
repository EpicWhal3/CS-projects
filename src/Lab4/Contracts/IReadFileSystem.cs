namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface IReadFileSystem
{
    IEnumerable<string> ListDirectory(string path, int depth);

    void ShowFile(string path, string? mode = null);
}