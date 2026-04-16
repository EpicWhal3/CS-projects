using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class ConsoleVisitor : IFileSystemVisitor
{
    public void VisitFile(FileComponent file)
    {
        Console.WriteLine($"[F] {file.Path}");
    }

    public void VisitDirectory(DirectoryComponent directory)
    {
        Console.WriteLine($"[D] {directory.Path}");
    }
}