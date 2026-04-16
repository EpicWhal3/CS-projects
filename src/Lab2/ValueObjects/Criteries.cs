namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record Criteries
{
    public Criteries(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "Name cannot be null or empty.");
        }

        Value = value;
    }

    public string Value { get; }
}
