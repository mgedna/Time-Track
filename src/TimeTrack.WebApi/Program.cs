using TimeTrack.WebApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.DependenciesOrchestrator(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();


app.UseHttpsRedirection();

app.Run();
