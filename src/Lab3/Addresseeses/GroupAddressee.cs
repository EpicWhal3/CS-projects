using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addresseeses;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _addressees = [];

    public void AddRecipient(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}