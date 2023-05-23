using Common;

namespace GoogleChat;

public class Sender
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string AvatarUrl { get; set; }
    public string Email { get; set; }
}

public class Thread
{
    public string Name { get; set; }
}

public class Space
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Type { get; set; }
}

public class Message
{
    public string Name { get; set; }
    public Sender Sender { get; set; }
    public string CreateTime { get; set; }
    public string Text { get; set; }
    public Thread Thread { get; set; }
}

public class GoogleMessage: IApiMessage
{
    public string Type { get; set; }
    public string EventTime { get; set; }
    public Space Space { get; set; }
    public Message Body { get; set; }
}
