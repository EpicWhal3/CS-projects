using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class ExamSubjectFactory : SubjectFactory
{
    public override Subject CreateSubject(
        ElementName name,
        IReadOnlyCollection<Laboratory> laboratories,
        IReadOnlyCollection<LectureMaterials> lectureMaterials,
        Grades points,
        User author)
    {
        return new ExamSubject(name, laboratories, lectureMaterials, points, author);
    }
}