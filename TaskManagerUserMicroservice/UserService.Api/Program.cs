using System.Configuration;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseMySQL(connectionString: connectionString);
});

builder.Services.AddIdentity<UserDbModel, RoleDbModel>()
    .AddEntityFrameworkStores<UserDbContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

