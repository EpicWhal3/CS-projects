using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FileSystemBuilder
{
    public IFileSystemComponent? Build(string path, int maxDepth)
    {
        return BuildComponent(path, maxDepth, 0);
    }

    private IFileSystemComponent? BuildComponent(string path, int maxDepth, int currentDepth)
    {
        if (currentDepth > maxDepth) return null;

        if (File.Exists(path)) return new FileComponent(path);

        if (!Directory.Exists(path)) return null;

        var directory = new DirectoryComponent(path);
        foreach (string entry in Directory.GetFileSystemEntries(path))
        {
            IFileSystemComponent? component = BuildComponent(entry, maxDepth, currentDepth + 1);
            if (component != null)
                directory.AddComponent(component);
        }

        return directory;
    }
}