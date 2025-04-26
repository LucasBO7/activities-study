using ChatNow_Api.Configuration;
using ReportProcessor.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Adiciona o RabbitMQ
builder.Services.AddRabbitMQService();

builder.AddSwaggerConfiguration();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerConfiguration();

app.MapControllers();

app.Run();

