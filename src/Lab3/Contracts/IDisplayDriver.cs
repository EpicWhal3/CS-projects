namespace Itmo.ObjectOrientedProgramming.Lab3.Contracts;

public interface IDisplayDriver
{
    void Clear();

    void Colorize(string text);

    void Write(string text);
}