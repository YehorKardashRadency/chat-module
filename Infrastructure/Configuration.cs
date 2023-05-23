using Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Configuration
{
    public static IServiceCollection ConfigureMessageBus(this IServiceCollection services)
    {
        services.AddTransient<IMessageBus, MessageBus>();
        return services;
    }
}