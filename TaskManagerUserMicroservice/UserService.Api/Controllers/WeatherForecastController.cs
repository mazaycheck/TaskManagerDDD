using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Data.Models;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    public UsersController(UserDbContext userDbContext, ILogger<UsersController> logger, UserManager<UserDbModel> userManager)
    {
        this.userDbContext = userDbContext;
        this.userManager = userManager;
    }

    private readonly ILogger<UsersController> _logger;
    private readonly UserDbContext userDbContext;
    private readonly UserManager<UserDbModel> userManager;

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<string> Get()
    {
        var users = userDbContext.Users.ToList();

        return users.Select(u => u.Email);

    }

    [HttpPost(Name = "CreateUser")]
    public async Task CreateUser([FromBody] UserCreateDto user)
    {
        var result = await userManager.CreateAsync(new UserDbModel()
        {
            Email = user.Email,
            UserName = user.Name,
            DOB = user.DOB
        }, user.Password);
    }
}


public class UserCreateDto
{
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DOB { get; set; }
}

