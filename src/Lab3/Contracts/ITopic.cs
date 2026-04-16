using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Contracts;

public interface ITopic
{
    void SendMessage(Message message, int? priority = null);
}