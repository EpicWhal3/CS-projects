using Lab5.Application.Contracts.User;
using Presentation.Scenarios.UserScenarios.OperationScenarios;

namespace Presentation.Scenarios.UserScenarios.UserScenariosProvider;

public class UserScenarioProvider : IUserScenarioProvider
{
    private readonly IUserServices _userService;

    public UserScenarioProvider(IUserServices userService)
    {
        _userService = userService;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        return new List<IScenario>
        {
            new AddMoneyScenario(_userService),
            new WithdrawMoneyScenario(_userService),
            new GetBalanceScenario(_userService),
            new GetOperationStoryScenarios(_userService),
            new ExitToMainMenuScenario(_userService),
        };
    }
}