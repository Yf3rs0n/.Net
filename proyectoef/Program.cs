using proyectoef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p=> p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();//Se asegura de crear la base
    return Results.Ok("Base de datos creada" + dbContext.Database.IsInMemory());//Para saber si la base esta en memoria
});

app.Run();
