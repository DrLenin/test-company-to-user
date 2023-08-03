var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IApi, UsersApi>();

var connectionString = builder.Configuration.GetConnectionString(Constants.DbConnectionString);
builder.Services.AddStore(connectionString);

var rabbitMqSection = builder.Configuration.GetSection("RabbitMQ");
builder.Services.AddDefaultMassTransit(
    host: rabbitMqSection.GetValue<string>("Host"),
    username: rabbitMqSection.GetValue("Username", "guest"),
    password: rabbitMqSection.GetValue("Username", "guest"));

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddTransient<IValidator<UserRequest>, UserValidator>();

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