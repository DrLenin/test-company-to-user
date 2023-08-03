var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IApi, TestApp.CompanyApi.Apis.CompanyApi>();

var connectionString = builder.Configuration.GetConnectionString(Constants.DbConnectionString);
builder.Services.AddStore(connectionString);

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<CreateUserInDbConsumer>();

    configurator.AddBus(busRegistrationContext =>
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(buscfg =>
        {
            var rabbitMqSection = builder.Configuration.GetSection("RabbitMQ") ;
            buscfg.Host(new Uri(rabbitMqSection.GetValue<string>("Host") ?? string.Empty),
                hostConfigurator =>
                {
                    hostConfigurator.Username(rabbitMqSection.GetValue("Username", "guest"));
                    hostConfigurator.Password(rabbitMqSection.GetValue("Password", "guest"));
                });

            buscfg.ConfigureEndpoints(busRegistrationContext);
        });

        return bus;
    });
});

builder.Services.AddMediatR(typeof(Program));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new UserDataMapperProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.RegisterApis();

app.MigrationDb();

app.Run();