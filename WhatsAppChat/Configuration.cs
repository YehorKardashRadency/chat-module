using ChatModule;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatsAppChat;

namespace FacebookChat;

public static class Configuration
{
    public static IServiceCollection ConfigureWhatsAppClient(this IServiceCollection services)
    {
        services.AddTransient<WhatsAppClient>()
            .AddTransient<IChatClient, WhatsAppClient>(s => s.GetService<WhatsAppClient>());
        
        // set callback with httpclient
        // PATCH /v1/settings/application
        // {
        //     "callback_persist": true,
        //     "sent_status": true,  // Either use this or webhooks.message.sent, but webhooks.message.sent property is preferred as sent_status will be deprecated soon
        //     "webhooks": { 
        //         "url": "webhook.your-domain", 
        //         "message": {     // Available on v2.41.2 and above
        //             "sent": false,
        //             "delivered": true,
        //             "read": false
        //         },
        //     }
        // }
        
        return services;
    }
    public static WebApplication UseWhatsAppClient(this WebApplication app)
    {
        var clientProvider =  app.Services.GetService<ChatClientProvider>();
        clientProvider.Add(ChatType.WhatsApp,typeof(WhatsAppClient));
        app.MapPost("/google/webhook/receive/",
            async (WhatsAppMessage message, MessageProcessor messageProcessor) =>
            {
                messageProcessor.Receive(ChatType.WhatsApp, message);
            });
        return app;
        
    }
}