namespace TestApp.CompanyApi.Extensions;

public static class ApplicationExtension
{
    public static void RegisterApis(this WebApplication application)
    {
        foreach (var api in application.Services.GetServices<IApi>())
        {
            api.RegisterActions(application);
        }
    }

    public static void MigrationDb(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<TestAppContext>().Database;
        db.Migrate();

        using var connection = (NpgsqlConnection)db.GetDbConnection();
            
        connection.Open();
        connection.ReloadTypes();
    }

    public static void AddStore(this IServiceCollection services, string? connectionString)
    {
        if(connectionString == null)
            return;

        services.AddDbContext<TestAppContext>((provider, options) =>
        {
            var loggerFactory = provider.GetService<ILoggerFactory>();

            options.ConfigureWarnings(warning => warning
                    .Log(RelationalEventId.CommandExecuting))
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();

            options.UseNpgsql(connectionString,
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", Constants.DbSchema));

        }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
    }

    public static void ConfigureSettings(this IServiceCollection services)
    {
        
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        
    }
}