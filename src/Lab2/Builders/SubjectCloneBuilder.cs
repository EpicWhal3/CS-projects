using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectCloneBuilder
{
    private readonly Subject _existingSubject;
    private User _author;

    public SubjectCloneBuilder(Subject existingSubject)
    {
        _existingSubject = existingSubject;
        _author = existingSubject.Author;
    }

    public SubjectCloneBuilder WithAuthor(User author)
    {
        _author = author;
        return this;
    }

    public Subject Build()
    {
        return _existingSubject switch
        {
            ExamSubject => new ExamSubject(
                _existingSubject.Name,
                _existingSubject.LabsList,
                _existingSubject.Lectures,
                _existingSubject.PointsNeeded,
                _author),

            PassFailSubject => new PassFailSubject(
                _existingSubject.Name,
                _existingSubject.LabsList,
                _existingSubject.Lectures,
                _existingSubject.PointsNeeded,
                _author),

            _ => throw new NotSupportedException("Unknown subject type"),
        };
    }
}