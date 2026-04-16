using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addresseeses;

public class UserAddressee : IAddressee
{
    public User Author { get; }

    public UserAddressee(User author)
    {
        Author = author;
    }

    public void ReceiveMessage(Message message)
    {
        Author.Messages.Add(message);
    }
}