using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public string Title { get; private set; }

    public string Body { get; private set; }

    public PriorityLevel? Priority { get; private set; } // Priority is now optional

    public bool IsRead { get; private set; }

    private Message(string title, string body, PriorityLevel? priority)
    {
        Title = title;
        Body = body;
        Priority = priority ?? new PriorityLevel(0); // Default priority
        IsRead = false;
    }

    public class Builder
    {
        private string _title = string.Empty;
        private string _body = string.Empty;
        private PriorityLevel? _priority = null; // Optional

        public Builder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public Builder WithBody(string body)
        {
            _body = body;
            return this;
        }

        public Builder WithPriority(PriorityLevel priority)
        {
            _priority = priority;
            return this;
        }

        public Message Build()
        {
            return new Message(_title, _body, _priority);
        }
    }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}