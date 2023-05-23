namespace Common;

public class ChatClientProvider
{
    public ChatClientProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Dictionary<ChatType,Type> ClientTypes { get; set; }

    private readonly IServiceProvider _serviceProvider;
    
    public void Add(ChatType chatType, Type clientType)
    {
        ClientTypes.Add(chatType,clientType);

    }

    public IChatClient Get(ChatType chatType)
    {
        return (IChatClient) _serviceProvider.GetService(ClientTypes[chatType]);
    }
}