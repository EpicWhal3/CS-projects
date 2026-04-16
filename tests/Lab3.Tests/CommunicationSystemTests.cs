using Itmo.ObjectOrientedProgramming.Lab3.Addresseeses;
using Itmo.ObjectOrientedProgramming.Lab3.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class CommunicationSystemTests
{
    [Fact]
    public void Unread_Message_Status_Successful()
    {
        var user = new User("Test User");
        var userAddressee = new UserAddressee(user);

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .Build();

        userAddressee.ReceiveMessage(message);

        Assert.False(user.Messages[0].IsRead);
    }

    [Fact]
    public void Successful_Mark_As_Read()
    {
        var loggerMock = new Mock<ILogger>();
        var user = new User("Test User");
        var userAddressee = new UserAddressee(user);

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .Build();

        userAddressee.ReceiveMessage(message);
        user.MarkAsRead(0);

        Assert.True(user.Messages[0].IsRead);
    }

    [Fact]
    public void Fail_Already_Marked_As_Read()
    {
        var loggerMock = new Mock<ILogger>();
        var user = new User("Test User");
        var userAddressee = new UserAddressee(user);

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .Build();

        userAddressee.ReceiveMessage(message);

        UserResults result = user.MarkAsRead(0);

        result = user.MarkAsRead(0);

        Assert.True(result is UserResults.AlreadyRead);
    }

    [Fact]
    public void Receive_Message_With_LowerImportance_Fail()
    {
        var loggerMock = new Mock<ILogger>();
        var user = new User("Test User");
        var userAddressee = new UserAddressee(user);
        var wrapperLogger = new WrapperLogger(loggerMock.Object, userAddressee);
        var proxy = new AddresseeProxy(wrapperLogger, new PriorityLevel(1));

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .WithPriority(new PriorityLevel(0))
            .Build();

        proxy.ReceiveMessage(message);
        userAddressee.ReceiveMessage(message);
        loggerMock.Verify(
            logger => logger.Log(
                "send message : Test Title"),
            Times.Never);
    }

    [Fact]
    public void Successful_Message_Received()
    {
        var loggerMock = new Mock<ILogger>();
        var user = new User("Test User");
        var userAddressee = new UserAddressee(user);
        var wrapperLogger = new WrapperLogger(loggerMock.Object, userAddressee);

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .WithPriority(new PriorityLevel(0))
            .Build();

        wrapperLogger.ReceiveMessage(message);

        loggerMock.Verify(
            logger => logger.Log(
                "send message : Test Title"),
            Times.Once);
    }

    [Fact]
    public void Send_Message_ToMessenger_Should_ProduceExpected_Output()
    {
        var messenger = new Messenger();
        var loggerMock = new Mock<ILogger>();
        var messengerAddressee = new MessengerAddressee(messenger);
        var wrapperLogger = new WrapperLogger(loggerMock.Object, messengerAddressee);

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .Build();

        wrapperLogger.ReceiveMessage(message);

        loggerMock.Verify(logger => logger.Log("send message : Test Title"), Times.Once);
    }

    [Fact]
    public void Send_Message_WithDiff_Priority_UserReceives_MessageOnce()
    {
        var loggerMock = new Mock<ILogger>();
        var user = new User("Test User");
        var userAddressee1 = new UserAddressee(user);
        var userAddressee2 = new UserAddressee(user);
        var topic = new Topic("Test Topic");

        var wrapperLogger = new WrapperLogger(loggerMock.Object, userAddressee1);
        var wrapperLogger2 = new WrapperLogger(loggerMock.Object, userAddressee2);

        topic.AddAddressee(new AddresseeProxy(wrapperLogger, new PriorityLevel(1)));
        topic.AddAddressee(new AddresseeProxy(wrapperLogger2, new PriorityLevel(2)));

        Message message = new Message.Builder()
            .WithTitle("Test Title")
            .WithBody("Test Body")
            .WithPriority(new PriorityLevel(1))
            .Build();

        topic.SendMessage(message);

        loggerMock.Verify(logger => logger.Log("send message : Test Title"), Times.Once);
    }
}