using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record LabResults
{
    private LabResults() { }

    public sealed record SuccessfulUpdateLab : LabResults;

    public sealed record UnAuthorizedAccessToLab : LabResults
    {
        public User Requester { get; private set; }

        public UnAuthorizedAccessToLab(User requester)
        {
            Requester = requester;
        }
    }

    public sealed record LabOriginNotEqual : LabResults;

    public sealed record LabOriginEqual : LabResults;
}