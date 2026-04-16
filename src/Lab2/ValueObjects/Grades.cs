namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record Grades
{
    public Grades(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Points cannot be lower or equal zero.", nameof(value));
        }

        Value = value;
    }

    public int Value { get; }
}