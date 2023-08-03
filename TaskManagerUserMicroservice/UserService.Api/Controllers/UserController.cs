using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Application;
using UserService.Data;
using UserService.Data.Models;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    public UserController(UserDbContext userDbContext, ILogger<UserController> logger, IUserService userService)
    {
        this.userDbContext = userDbContext;
        this.userService = userService;
        this.userManager = userManager;
    }

    private readonly ILogger<UserController> _logger;
    private readonly UserDbContext userDbContext;
    private readonly IUserService userService;
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

    [HttpPost(Name = "AuthUser")]
    public async Task<IActionResult> AuthUser([FromBody] UserCreateDto user)
    {
        var result = await userService.AuthenticateUserAsync(user.Email, user.Password);

        if (result)
        {
            return Ok("Logged in.");
        }
        else
        {
            return Unauthorized("Wrong credentials!");
        }
    }
}


public class UserCreateDto
{
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DOB { get; set; }
}

