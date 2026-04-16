using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxy;

public class AddresseeProxy : IAddressee
{
    private readonly IAddressee _realAddressee;
    private readonly PriorityLevel _minimumPriority;

    public AddresseeProxy(IAddressee realAddressee, PriorityLevel minimumPriority)
    {
        _realAddressee = realAddressee;
        _minimumPriority = minimumPriority;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.Priority != null && message.Priority.ImportanceLevel >= _minimumPriority.ImportanceLevel)
        {
            _realAddressee.ReceiveMessage(message);
        }
        else
        {
            if (message.Priority != null)
            {
                Console.WriteLine($"Message '{message.Title}' " +
                                  $"ignored due to low priority ({message.Priority.ImportanceLevel}).");
            }
        }
    }
}