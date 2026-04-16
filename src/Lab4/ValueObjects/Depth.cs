namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public record Depth
{
    public Depth(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Depth of the tree list cannot be below zero");
        }

        Value = value;
    }

    public int Value { get; set; }
}