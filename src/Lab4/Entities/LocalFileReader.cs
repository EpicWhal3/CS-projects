using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalFileReader : IReadFileSystem
{
    private readonly INavigateFileSystem _navigator;

    public LocalFileReader(INavigateFileSystem navigator)
    {
        _navigator = navigator;
    }

    public IEnumerable<string> ListDirectory(string path, int depth)
    {
        if (_navigator.CurrentPath == null) return [];

        string directory = Path.Combine(_navigator.CurrentPath, path);

        if (!Directory.Exists(directory))
        {
            Console.WriteLine("Directory does not exist");
            return [];
        }

        return GetFilesAndDirectories(directory, depth);
    }

    public void ShowFile(string path, string? mode = null)
    {
        if (_navigator.CurrentPath == null) return;

        if (mode != null && mode != "console")
        {
            Console.WriteLine("Invalid Mode");
            return;
        }

        string fullPath = Path.Combine(_navigator.CurrentPath, path);
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File {path} not found.");
            return;
        }

        Console.WriteLine(File.ReadAllText(fullPath));
    }

    private static List<string> GetFilesAndDirectories(string directory, int depth, int currentDepth = 0)
    {
        if (currentDepth > depth)
            return [];

        var results = new List<string>();

        foreach (string dir in Directory.GetDirectories(directory))
        {
            results.Add($"[D] {dir}");
            results.AddRange(GetFilesAndDirectories(dir, depth, currentDepth + 1));
        }

        foreach (string file in Directory.GetFiles(directory))
        {
            results.Add($"[F] {file}");
        }

        return results;
    }
}