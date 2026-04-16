using Itmo.ObjectOrientedProgramming.Lab2.Contracts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class ProgrammsRepositories : IRepository<EducationalProgram>
{
    private readonly ICollection<EducationalProgram> _repo = [];

    public void Add(EducationalProgram entity)
    {
        _repo.Add(entity);
    }

    public EducationalProgram GetById(Guid id)
    {
        return _repo.FirstOrDefault(x => x.Id == id) ??
               throw new ArgumentException("User not found");
    }
}