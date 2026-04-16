using Presentation.Scenarios.UserScenarios;
using Spectre.Console;

namespace Presentation.Scenarios;

public class ActionSelectionScenario : IActionSelectionScenario
{
    private IScenarioProvider? _scenarioProvider;
    private bool _shouldExitToMainMenu;

    public void SetScenarioProvider(IScenarioProvider scenarioProvider)
    {
        _scenarioProvider = scenarioProvider;
    }

    public void Run()
    {
        _shouldExitToMainMenu = false;

        if (_scenarioProvider is null)
        {
            AnsiConsole.Ask<string>("No actions available");
            AnsiConsole.Clear();
            return;
        }

        while (!_shouldExitToMainMenu)
        {
            var scenarios = _scenarioProvider.GetScenarios().ToList();
            SelectionPrompt<IScenario> prompt = new SelectionPrompt<IScenario>()
                .Title("Select action")
                .AddChoices(scenarios)
                .UseConverter(s => s.Name);

            IScenario selectedScenario = AnsiConsole.Prompt(prompt);

            if (selectedScenario is ExitToMainMenuScenario)
            {
                _shouldExitToMainMenu = true;
                continue;
            }

            AnsiConsole.Clear();
            selectedScenario.Run();
            AnsiConsole.Clear();
        }
    }
}