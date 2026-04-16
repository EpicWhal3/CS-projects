using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record SubjectResults
{
    private SubjectResults() { }

    public sealed record SuccessfulUpdateSubject : SubjectResults;

    public sealed record UnAuthorizedAccessSubject(User Requester) : SubjectResults;

    public sealed record SubjectOriginNotEqual : SubjectResults;

    public sealed record SubjectOriginEqual : SubjectResults;

    public sealed record SubjectGradesSumCorrect : SubjectResults
    {
        public int Sum { get; private set; }

        public SubjectGradesSumCorrect(int sum)
        {
            Sum = sum;
        }
    }

    public sealed record SubjectGradesSumIncorrect : SubjectResults
    {
        public int Sum { get; private set; }

        public SubjectGradesSumIncorrect(int sum)
        {
            Sum = sum;
        }
    }
}