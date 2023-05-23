using Common;
namespace ChatModule;

public class MessageProcessor
{
    private readonly IServiceProvider _serviceProvider;

    private readonly ChatClientProvider _chatClientProvider;
    private readonly IMessageBus _messageBus;
    public MessageProcessor(IServiceProvider serviceProvider, ChatClientProvider chatClientProvider, IMessageBus messageBus)
    {
        _serviceProvider = serviceProvider;
        _chatClientProvider = chatClientProvider;
        _messageBus = messageBus;
    }

    public void Receive(ChatType chatType, IApiMessage message)
    {
        var client = _chatClientProvider.Get(chatType);
        var result = client.Receive(message);
        _messageBus.Publish("send-to-admin-queue",result);
    }
}