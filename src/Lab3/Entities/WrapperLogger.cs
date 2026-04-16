using Itmo.ObjectOrientedProgramming.Lab3.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class WrapperLogger : IAddressee
{
    private readonly ILogger _logger;

    private readonly IAddressee _addressee;

    public WrapperLogger(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void ReceiveMessage(Message message)
    {
        _addressee.ReceiveMessage(message);
        _logger.Log($"send message : {message.Title}");
    }
}