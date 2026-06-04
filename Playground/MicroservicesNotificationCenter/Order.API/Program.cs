using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();

app.MapScalarApiReference(options =>
{

    options.WithOpenApiRoutePattern("/openapi/{documentName}.json");

    options
        .WithTitle("Microservices Notification Center")
        .WithTheme(ScalarTheme.DeepSpace)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
