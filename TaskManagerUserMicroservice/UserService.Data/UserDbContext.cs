
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Models;

namespace UserService.Data;

public class UserDbContext: IdentityDbContext<UserDbModel>
{
    private readonly DbContextOptions<UserDbContext> options;

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

