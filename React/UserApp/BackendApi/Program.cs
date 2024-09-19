using System.Text.Json;
using BackendApi;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackendApi.ORM;
using BackendApi.Adapter;


//var users = TestData.CreateUsers();

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

app.MapGet("/Users", async (UsersDb db) => 
    {
        var ormUsers = await db.Users.ToListAsync();
        var dtoUsers = UserAdapter.OrmsToDtos(ormUsers);
        return JsonSerializer.Serialize(dtoUsers);
    });
app.Run();


