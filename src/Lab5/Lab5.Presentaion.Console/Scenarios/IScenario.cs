namespace Presentation.Scenarios;

public interface IScenario
{
    string Name { get; }

    void Run();
}