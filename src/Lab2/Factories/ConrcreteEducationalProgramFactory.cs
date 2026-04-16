using Itmo.ObjectOrientedProgramming.Lab2.Contracts;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class ConrcreteEducationalProgramFactory : IEducationalProgramFactory
{
    public override EducationalProgram CreateEducationalProgram(
        ElementName name,
        Dictionary<int, Subject> subjects,
        User author)
    {
        return new EducationalProgram(name, subjects, author);
    }
}