using Sprocket.Models;
using Microsoft.EntityFrameworkCore;

[assembly: Microsoft.AspNetCore.Mvc.ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add DB Contexts
builder.Services.AddDbContext<PageContext>(opt => opt.UseInMemoryDatabase("Collections"));


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();