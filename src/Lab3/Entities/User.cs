using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User
{
    public string Name { get; }

    public Guid Id { get; }

    public IList<Message> Messages { get; }

    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Messages = [];
    }

    public UserResults MarkAsRead(int index)
    {
        if (index < 0 || index >= Messages.Count)
        {
            return new UserResults.IndexOutOfRange("Index out of range");
        }

        Message message = Messages[index];
        if (message.IsRead)
        {
            return new UserResults.AlreadyRead($"Message '{message.Title}' already read");
        }

        message.MarkAsRead();
        return new UserResults.SuccessRead($"Message {message.Title} marked as read");
    }
}