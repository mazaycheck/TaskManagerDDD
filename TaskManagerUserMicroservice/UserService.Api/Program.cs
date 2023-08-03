using System.Configuration;
using Microsoft.EntityFrameworkCore;
using UserService.Application;
using UserService.Application.Services;
using UserService.Data;
using UserService.Data.Models;
using UserService.Infrastructure.Services;

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

builder.Services.AddIdentity<UserDbModel, RoleDbModel>(o =>
{
    o.User.RequireUniqueEmail = true;
    o.Password.RequiredLength = 5;
} )
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManagementService, AspNetCoreIdentityService>();
builder.Services.AddScoped<IUserService, UserAppService>();


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

