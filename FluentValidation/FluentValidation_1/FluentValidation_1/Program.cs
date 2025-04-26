using FluentValidation_1.Services;
using FluentValidation.AspNetCore;
using FluentValidation_1.DTOs;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CriarTarefaDTOValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters(); // Registra automaticamente todos validadores do FluentValidation no Assembly
builder.Services.AddScoped<TarefaService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
