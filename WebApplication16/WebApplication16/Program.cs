using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using WebApplication16.Core.Command;
using WebApplication16.Core.DTOS.Response;
using WebApplication16.Domain.Interfaces;
using WebApplication16.Infrastructure;
using WebApplication16.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Registrar validadores de forma explícita para evitar escaneos innecesarios:
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
// Habilitar la validación automática:
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaClean")));
builder.Services.AddScoped<IBattleRepository, Battlerepository>();
builder.Services.AddMediatR(typeof(CreateBattleCommmand));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build(); app.UseCors("AllowLocal");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
