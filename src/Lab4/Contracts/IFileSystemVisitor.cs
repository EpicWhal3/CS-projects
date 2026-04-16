using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface IFileSystemVisitor
{
    void VisitFile(FileComponent file);

    void VisitDirectory(DirectoryComponent directory);
}