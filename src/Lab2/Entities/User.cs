using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class User
{
    public User(UserName name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; private set; }

    public UserName Name { get; }

    public static User CreateDefaultUser()
    {
        return new User(new UserName("Default"));
    }
}