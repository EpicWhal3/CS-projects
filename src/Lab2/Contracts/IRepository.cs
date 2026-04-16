namespace Itmo.ObjectOrientedProgramming.Lab2.Contracts;

public interface IRepository<T>
{
    void Add(T entity);

    T GetById(Guid id);
}