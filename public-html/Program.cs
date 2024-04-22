using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Retrieve the connection string from the configuration
//var connectionString = app.Configuration.GetConnectionString("DefaultConnection") ?? 
//    "server=localhost;database=myDatabase;uid=myUser;pwd=myPassword;"; // Fallback connection string
var connectionString = $"server={Environment.GetEnvironmentVariable("ENDPOINT")};database={Environment.GetEnvironmentVariable("DATABASE")};uid={Environment.GetEnvironmentVariable("USERD")};pwd={Environment.GetEnvironmentVariable("PASSD")}";

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Example endpoint
app.MapGet("/net-haep", () => "Hello World!");

app.MapGet("/net-haep/version", async () => "Hello World .NET 8. Prueba controlador!");

// Additional endpoint
app.MapGet("/net-haep/t33st", async () => {
    try
    {
        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();
        var command = new MySqlCommand("SELECT 'Connection Successful!'", connection);
        var result = await command.ExecuteScalarAsync();
        return result?.ToString() ?? "No result";
    }
    catch (Exception ex)
    {
        return $"Error: {ex.Message}";
    }
});

app.MapControllers();


app.Run();
