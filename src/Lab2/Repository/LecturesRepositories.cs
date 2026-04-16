using Itmo.ObjectOrientedProgramming.Lab2.Contracts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class LecturesRepositories : IRepository<LectureMaterials>
{
    private readonly ICollection<LectureMaterials> _repo = [];

    public void Add(LectureMaterials entity)
    {
        _repo.Add(entity);
    }

    public LectureMaterials GetById(Guid id)
    {
        return _repo.FirstOrDefault(x => x.Id == id) ??
               throw new ArgumentException("User not found");
    }
}