using Common;

namespace WhatsAppChat;

public class WhatsAppClient: IChatClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WhatsAppClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public SendResult Send(PlatformMessageRequest messageRequest)
    {
        var client = _httpClientFactory.CreateClient();
        // SEND POST /v1/messages
        // {
        //     "recipient_type": "individual",
        //     "to": "whatsapp-id",
        //     "type": "text",
        //     "text": {
        //         "body": "your-message-content"
        //     }
        // }
        Console.WriteLine($"Sending text ${messageRequest.Message} to user ${messageRequest.ChatId} via WhatsApp");
        return new SendResult()
        {
            ChatId = messageRequest.ChatId,
            Successful = true
        };
    }

    public PlatformMessageResponse Receive(IApiMessage apiMessage)
    {
        var message = (WhatsAppMessage)apiMessage;
        return new PlatformMessageResponse()
        {
            ChatType = ChatType.WhatsApp,
            Message = message.Messages[0].Text.Body,
            ChatId = message.Contacts[0].WaId,
            Sender = new Sender() {Id = message.Contacts[0].WaId, Name = message.Contacts[0].Profile.Name},
            Timestamp = long.Parse(message.Messages[0].Timestamp),
        };
    }
    
}