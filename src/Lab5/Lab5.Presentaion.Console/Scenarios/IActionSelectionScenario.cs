namespace Presentation.Scenarios;

public interface IActionSelectionScenario
{
    public void SetScenarioProvider(IScenarioProvider scenarioProvider);

    public void Run();
}