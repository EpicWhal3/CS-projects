using Application.Extensions;
using Infrastructure.Extensions;
using Itmo.Dev.Platform.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;
using Presentation.Scenarios;
using Spectre.Console;

namespace EnterPoint;

public static class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddPlatform()
            .AddInfrastructureDataAccess(
                connectionConfiguration =>
                {
                    connectionConfiguration.Host = "localhost";
                    connectionConfiguration.Port = 54321;
                    connectionConfiguration.Username = "postgres";
                    connectionConfiguration.Password = "postgres";
                    connectionConfiguration.Database = "postgres";
                    connectionConfiguration.SslMode = "Prefer";
                })
            .AddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();

        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();
        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();
        while (true)
        {
            scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}