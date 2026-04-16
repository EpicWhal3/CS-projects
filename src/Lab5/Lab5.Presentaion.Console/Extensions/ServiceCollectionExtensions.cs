using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios;
using Presentation.Scenarios.AdminScenarios.AdminScenariosProvider;
using Presentation.Scenarios.UserScenarios.UserScenariosProvider;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IStartScenarioProvider, StartScenarioProvider>();

        collection.AddScoped<IActionSelectionScenario, ActionSelectionScenario>();

        collection.AddScoped<IAdminScenarioProvider, AdminScenarioProvider>();

        collection.AddScoped<IUserScenarioProvider, UserScenarioProvider>();

        return collection;
    }
}