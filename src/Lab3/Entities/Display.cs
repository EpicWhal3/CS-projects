using Itmo.ObjectOrientedProgramming.Lab3.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Display
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ShowMessage(string message)
    {
        _driver.Clear();
        _driver.Colorize(message);
        _driver.Write(message);
    }
}