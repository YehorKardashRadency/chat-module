using Common;

namespace Infrastructure;

public class MessageBus : IMessageBus
{
    public void Publish(string queue, PlatformMessageResponse messageResponse)
    {
        Console.WriteLine($"Publishing message from chat {messageResponse.ChatId} to queue {queue}");
    }
}