using Prism.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddRazorAndBlazor()
    .AddDatabase()
    .AddAuthenticationAndAuthorization()
    .AddApplicationServices();

var app = builder.Build();
app.UseApplicationMiddlewares().InitializeDatabase();

app.Run();
