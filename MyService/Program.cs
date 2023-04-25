using Microsoft.EntityFrameworkCore;
using MyService.Models;

var builder = WebApplication.CreateBuilder(args);

//Add DBCOntext
builder.Services.AddDbContext<MyStockContext>(opt => opt.UseInMemoryDatabase("MyStockDB"));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
