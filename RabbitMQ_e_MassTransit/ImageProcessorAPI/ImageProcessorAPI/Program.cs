using ImageProcessorAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerConfigurationService();
builder.Services.AddRabbitMQService();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseSwaggerService();

app.UseAuthorization();

app.MapControllers();

app.Run();
