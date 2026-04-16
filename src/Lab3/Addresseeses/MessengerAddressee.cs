using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addresseeses;

public class MessengerAddressee : IAddressee
{
    private Messenger Messenger { get; }

    public MessengerAddressee(Messenger msgr)
    {
        Messenger = msgr;
    }

    public void ReceiveMessage(Message message)
    {
        Messenger.ReceieveMessage(message.Title);
    }
}