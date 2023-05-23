using Common;

namespace FacebookChat;

public class IdField
{
    public string Id { get; set; }
}

public class FacebookMessageBody
{
    public string Mid { get; set; }
    public string Text { get; set; }
}
public class FacebookMessage: IApiMessage
{
    public IdField Sender { get; set; }
    public IdField Recipient { get; set; }
    public long  Timestamp { get; set; }
    public FacebookMessageBody Body { get; set; }
}