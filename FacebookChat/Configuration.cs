using ChatModule;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookChat;

public static class Configuration
{
    public static IServiceCollection ConfigureFacebookClient(this IServiceCollection services)
    {
        services.AddTransient<FacebookClient>()
            .AddTransient<IChatClient, FacebookClient>(s => s.GetService<FacebookClient>());
        

        return services;
    }

    public static WebApplication UseFacebookClient(this WebApplication app)
    {
        var clientProvider =  app.Services.GetService<ChatClientProvider>();
        clientProvider.Add(ChatType.Facebook,typeof(FacebookClient));
        // place special endpoints here
        app.MapGet("/facebook/webhook", async (IConfiguration configuration) =>
        {
            // verify facebook webhook
            return Results.Ok();
        });
        app.MapPost("/facebook/webhook/receive/",
            async (FacebookMessage message, MessageProcessor messageProcessor) =>
            {
                messageProcessor.Receive(ChatType.Facebook, message);
            });
        return app;
        
    }
}