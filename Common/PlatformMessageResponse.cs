namespace Common;

public class Sender
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
}

public class PlatformMessageResponse
{
    public string ChatId { get; set; }
    public string Message { get; set; }
    public ChatType ChatType { get; set; }
    public long Timestamp { get; set; }
    public Sender Sender { get; set; }
}