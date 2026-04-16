namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record PriorityLevel
{
    public int ImportanceLevel { get; private set; }

    public PriorityLevel(int value)
    {
        ImportanceLevel = value is < 0 or > 100
            ? throw new ArgumentException("Incorrect importance level")
            : value;
    }

    public static PriorityLevel Default => new PriorityLevel(0);
}