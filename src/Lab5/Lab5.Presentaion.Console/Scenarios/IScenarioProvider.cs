namespace Presentation.Scenarios;

public interface IScenarioProvider
{
    IEnumerable<IScenario> GetScenarios();
}