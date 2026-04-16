using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Contracts;

public abstract class IEducationalProgramFactory
{
    public abstract EducationalProgram CreateEducationalProgram(
        ElementName name,
        Dictionary<int, Subject> subjects,
        User author);
}