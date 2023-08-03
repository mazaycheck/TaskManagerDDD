using System;
using Microsoft.AspNetCore.Identity;
using UserService.Application.Services;
using UserService.Data.Models;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services
{
    public class AspNetCoreIdentityService : IUserManagementService
	{
        private readonly UserManager<UserDbModel> userManager;
        private readonly SignInManager<UserDbModel> signInManager;

        public AspNetCoreIdentityService(UserManager<UserDbModel> userManager, SignInManager<UserDbModel> signInManager)
		{
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            var result = await signInManager.PasswordSignInAsync(user, password, false, true);

            return result.Succeeded;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var applicationUser = await userManager.FindByEmailAsync(email);
            if(applicationUser == null)
            {
                return null;
            }
            return new User()
            {
                Email = applicationUser.Email,
                UserId = applicationUser.Id,
                Username = applicationUser.UserName
            };
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            var user = await userManager.FindByEmailAsync(username);

            if(user != null)
            {
                throw new ServiceException(string.Format("Cannot create user. User with email already {0} exists", email));
            }
            var result = await userManager.CreateAsync(new UserDbModel()
            {
                UserName = username,
                Email = email,

            }, password);

            return result.Succeeded;
        }
    }
}

