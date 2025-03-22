var builder = WebApplication.CreateBuilder(args);

//services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// config hhtp request pipeline
app.MapCarter();


//app.MapGet("/", () => "Hello World!");

app.Run();