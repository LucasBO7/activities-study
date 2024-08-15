using Microsoft.AspNetCore.SignalR;
using SignalRChat_Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
// Add Cors to our React Native project
builder.Services.AddCors(options => options.AddPolicy("AllowMyReactApp", builder =>
{
    builder.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:5180")
    .AllowCredentials();
}));
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors("AllowMyReactApp");

app.MapGet("/", () => "Hello World!");
app.MapHub<ChatHub>("/chatHub");

app.Run();