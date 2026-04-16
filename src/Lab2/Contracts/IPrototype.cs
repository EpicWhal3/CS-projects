using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Contracts;

public interface IPrototype<T> where T : IPrototype<T>
{
    T Clone(User author);
}