using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Core.Command;
using WebApplication16.Core.DTOS.Response;
using WebApplication16.Domain.Interfaces;
using WebApplication16.Infrastructure;
using WebApplication16.Infrastructure.Data;
using System.Reflection;

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
    options.AddPolicy("AllowLocal", builder =>
        builder.WithOrigins("https://localhost:3000","https://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build(); app.UseCors("AllowLocal");

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
