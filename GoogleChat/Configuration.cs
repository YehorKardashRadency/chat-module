using ChatModule;
using Common;
using GoogleChat;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookChat;

public static class Configuration
{
    public static IServiceCollection ConfigureGoogleClient(this IServiceCollection services)
    {
        services.AddTransient<GoogleClient>()
            .AddTransient<IChatClient, GoogleClient>(s => s.GetService<GoogleClient>());
        
        // add specific services, configurations, etc.
        
        return services;
    }
    public static WebApplication UseGoogleClient(this WebApplication app)
    {
        var clientProvider =  app.Services.GetService<ChatClientProvider>();
        clientProvider.Add(ChatType.Google,typeof(GoogleClient));
        app.MapPost("/google/webhook/receive/",
            async (GoogleMessage message, MessageProcessor messageProcessor) =>
            {
                messageProcessor.Receive(ChatType.Google, message);
            });
        return app;
        
    }
}