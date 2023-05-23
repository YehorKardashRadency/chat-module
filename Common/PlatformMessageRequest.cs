namespace Common;

public class PlatformMessageRequest
{
    public string ChatId { get; set; }
    public string Message { get; set; }
    public ChatType ChatType { get; set; }
}