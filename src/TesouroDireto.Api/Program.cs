var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Debug de todas as variáveis de ambiente
Console.WriteLine("=== VARIÁVEIS DE AMBIENTE ===");
var envVars = Environment.GetEnvironmentVariables();
foreach (string key in envVars.Keys)
{
    Console.WriteLine($"{key} = {envVars[key]}");
}
Console.WriteLine("=============================");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Health check endpoint
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

app.Run();
