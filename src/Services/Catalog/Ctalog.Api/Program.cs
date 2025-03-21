var builder = WebApplication.CreateBuilder(args);

//services to the container

var app = builder.Build();

// config hhtp request pipeline

app.MapGet("/", () => "Hello World!");

app.Run();
