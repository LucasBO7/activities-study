using SignalRChat.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:8081")
    .AllowCredentials();
}));
builder.Services.AddRazorPages();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapRazorPages();
app.MapHub<ChatHub>("/chathub");

app.Run();
