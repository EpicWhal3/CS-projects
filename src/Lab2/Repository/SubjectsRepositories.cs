using Itmo.ObjectOrientedProgramming.Lab2.Contracts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class SubjectsRepositories : IRepository<Subject>
{
    private readonly ICollection<Subject> _repo = [];

    public void Add(Subject entity)
    {
        _repo.Add(entity);
    }

    public Subject GetById(Guid id)
    {
        return _repo.FirstOrDefault(x => x.Id == id) ??
               throw new ArgumentException("User not found");
    }
}