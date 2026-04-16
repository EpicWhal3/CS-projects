using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Contracts;

public interface IAddressee
{
    void ReceiveMessage(Message message);
}