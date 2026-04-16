using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class Subject
{
    public Guid Id { get; }

    public ElementName Name { get; private set; }

    public IReadOnlyCollection<Laboratory> LabsList { get; private set; }

    public IReadOnlyCollection<LectureMaterials> Lectures { get; private set; }

    public Grades PointsNeeded { get; private set; }

    public User Author { get; }

    public Guid BasedOn { get; private set; }

    protected Subject(
        ElementName name,
        IReadOnlyCollection<Laboratory> laboratories,
        IReadOnlyCollection<LectureMaterials> lectureMaterials,
        Grades points,
        User author)
    {
        Id = Guid.NewGuid();
        Name = name;
        LabsList = laboratories;
        Lectures = lectureMaterials;

        if (points.Value is < 0 or > 100)
        {
            throw new ArgumentException("Needed points cannot be lower than 0 or greater than 100.");
        }

        PointsNeeded = points;
        Author = author;
        BasedOn = Id;
    }

    public Subject Clone(User author)
    {
        Subject result = new SubjectCloneBuilder(this)
            .WithAuthor(author)
            .Build();
        result.BasedOn = BasedOn;
        return result;
    }

    public SubjectResults UpdateSubject(
        User requester,
        ElementName? newMessage = null,
        IReadOnlyCollection<LectureMaterials>? lects = null)
    {
        if (requester != Author)
        {
            return new SubjectResults.UnAuthorizedAccessSubject(requester);
        }

        if (newMessage is not null)
        {
            Name = newMessage;
        }

        if (lects is not null)
        {
            Lectures = lects;
        }

        return new SubjectResults.SuccessfulUpdateSubject();
    }

    public abstract SubjectResults SumGrades();
}