using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addresseeses;

public class DisplayAddressee : IAddressee
{
    private readonly Display _display;

    public DisplayAddressee(Display display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.ShowMessage(message.Body);
    }
}