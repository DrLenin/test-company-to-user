namespace TestApp.UsersApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDefaultMassTransit(this IServiceCollection services, string? host, string? username, string? password)
    {
        services.AddMassTransit(configurator => 
        {
            configurator.UsingRabbitMq((context, factoryConfigurator) =>
            {
                factoryConfigurator.Host(new Uri(host),
                    hostConfigurator =>
                    {
                        hostConfigurator.Username(username);
                        hostConfigurator.Password(password);
                    });
                factoryConfigurator.ConfigureEndpoints(context);
            });
        });
    }
}