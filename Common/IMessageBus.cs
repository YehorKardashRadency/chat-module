namespace Common;

public interface IMessageBus
{
    public void Publish(string queue, PlatformMessageResponse messageResponse);
}