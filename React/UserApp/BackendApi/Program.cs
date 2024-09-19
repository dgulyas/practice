using System.Text.Json;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackendApi.ORM;
using BackendApi.Adapter;
using BackendApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UsersDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "The Backend",
         Description = "Generic CRUD API",
         Version = "v1" });
});

var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API V1");
   });
}

app.MapGet("/users", async (UsersDb db) =>
{
    var ormUsers = await db.Users.ToListAsync();
    var dtoUsers = UserAdapter.OrmsToDtos(ormUsers);
    return JsonSerializer.Serialize(dtoUsers);
});

app.MapPost("/users", async (UsersDb db, UserDTO userDto) =>
{
    var userOrm = UserAdapter.DtoToOrm(userDto);

    await db.Users.AddAsync(userOrm);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{userOrm.Id}", UserAdapter.OrmToDto(userOrm));
});

app.MapGet("/users/{id}", async (UsersDb db, int id) =>
{
    var ormUser = await db.Users.FindAsync(id);
    if (ormUser == null) return "404 - NotFound";
    var dtoUser = UserAdapter.OrmToDto(ormUser);
    return JsonSerializer.Serialize(dtoUser);
});

app.MapPut("/users/{id}", async (UsersDb db, UserDTO userOrm, int id) =>
{
    var currentUserORM = await db.Users.FindAsync(id);
    if (currentUserORM == null) return Results.NotFound();

    var newUserOrm = UserAdapter.DtoToOrm(userOrm);

    currentUserORM.FirstName = newUserOrm.FirstName;
    currentUserORM.LastName = newUserOrm.LastName;
    currentUserORM.EmailAddress = newUserOrm.EmailAddress;
    currentUserORM.MailingAddress = newUserOrm.MailingAddress;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/users/{id}", async (UsersDb db, int id) =>
{
   var userORM = await db.Users.FindAsync(id);
   if (userORM == null)
   {
      return Results.NotFound();
   }
   db.Users.Remove(userORM);
   await db.SaveChangesAsync();
   return Results.Ok("Testing");
});

app.Run();
