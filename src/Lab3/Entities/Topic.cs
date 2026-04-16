using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic : ITopic
{
    public string Name { get; }

    private readonly List<IAddressee> _addressees = new();

    public Topic(string name)
    {
        Name = name;
    }

    public void AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void AddAddresseeWithPriority(IAddressee addressee, PriorityLevel minimumPriority)
    {
        var proxy = new AddresseeProxy(addressee, minimumPriority);
        _addressees.Add(proxy);
    }

    public void DeleteAddressee(IAddressee addressee)
    {
        _addressees.Remove(addressee);
    }

    public void SendMessage(Message message, int? priority = null)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}