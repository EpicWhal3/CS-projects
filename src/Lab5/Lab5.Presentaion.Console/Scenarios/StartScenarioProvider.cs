using Lab5.Application.Contracts.Admin;
using Lab5.Application.Contracts.User;
using Presentation.Scenarios.AdminScenarios;
using Presentation.Scenarios.UserScenarios;
using Presentation.Scenarios.UserScenarios.UserScenariosProvider;

namespace Presentation.Scenarios;

public class StartScenarioProvider : IStartScenarioProvider
{
    private readonly IUserLoginService _loginService;
    private readonly IUserScenarioProvider _scenarioProvider;
    private readonly IActionSelectionScenario _selectionScenario;
    private readonly IAdminLoginService _adminLoginService;
    private readonly IUserServices _userServices;

    public StartScenarioProvider(
        IUserLoginService loginService,
        IUserScenarioProvider scenarioProvider,
        IActionSelectionScenario selectionScenario,
        IAdminLoginService adminLoginService,
        IUserServices userServices)
    {
        _loginService = loginService;
        _scenarioProvider = scenarioProvider;
        _adminLoginService = adminLoginService;
        _selectionScenario = selectionScenario;
        _userServices = userServices;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        return new List<IScenario>
        {
            new UserLoginScenario(
                _loginService,
                _scenarioProvider,
                _selectionScenario),
            new AdminLoginScenario(
                _adminLoginService),
            new CreateUserScenario(_userServices),
            new ExitScenario(),
        };
    }
}