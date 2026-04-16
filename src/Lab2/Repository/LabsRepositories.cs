using Itmo.ObjectOrientedProgramming.Lab2.Contracts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class LabsRepositories : IRepository<Laboratory>
{
    private readonly ICollection<Laboratory> _repo = [];

    public void Add(Laboratory entity)
    {
        _repo.Add(entity);
    }

    public Laboratory GetById(Guid id)
    {
        Laboratory? x = _repo.FirstOrDefault(x => x.Id == id) ??
                        throw new ArgumentException("Laboratory not found");
        return x;
    }
}