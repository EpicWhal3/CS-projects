using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public abstract class SubjectFactory
{
    public abstract Subject CreateSubject(
        ElementName name,
        IReadOnlyCollection<Laboratory> laboratories,
        IReadOnlyCollection<LectureMaterials> lectureMaterials,
        Grades points,
        User author);
}