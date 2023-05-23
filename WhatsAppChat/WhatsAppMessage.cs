using Common;

public class Profile
{
    public string Name { get; set; }
}

public class Contact
{
    public Profile Profile { get; set; }
    public string WaId { get; set; }
}

public class Text
{
    public string Body { get; set; }
}

public class Message
{
    public string From { get; set; }
    public string Id { get; set; }
    public string Timestamp { get; set; }
    public Text Text { get; set; }
    public string Type { get; set; }
}

public class WhatsAppMessage : IApiMessage
{
    public List<Contact> Contacts { get; set; }
    public List<Message> Messages { get; set; }
}