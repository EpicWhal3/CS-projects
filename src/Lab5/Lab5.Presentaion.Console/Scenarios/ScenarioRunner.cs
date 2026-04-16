namespace Presentation.Scenarios;

public class ScenarioRunner
{
    private readonly IStartScenarioProvider _scenarioProvider;
    private readonly IActionSelectionScenario _actionSelectionScenario;

    public ScenarioRunner(IStartScenarioProvider scenarioProvider, IActionSelectionScenario actionSelectionScenario)
    {
        _scenarioProvider = scenarioProvider;
        _actionSelectionScenario = actionSelectionScenario;
    }

    public void Run()
    {
        _actionSelectionScenario.SetScenarioProvider(_scenarioProvider);
        _actionSelectionScenario.Run();
    }
}