namespace Itmo.ObjectOrientedProgramming.Lab4.Contracts;

public interface IFileSystemComponent
{
    void Accept(IFileSystemVisitor visitor);
}