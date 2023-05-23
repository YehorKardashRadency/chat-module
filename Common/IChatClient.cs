namespace Common;

public interface IChatClient
{
    public SendResult Send(PlatformMessageRequest messageRequest);
    public PlatformMessageResponse Receive(IApiMessage apiMessage);
}