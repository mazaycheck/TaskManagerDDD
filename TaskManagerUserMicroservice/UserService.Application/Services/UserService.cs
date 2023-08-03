using System;
using UserService.Application;
using UserService.Application.Models;
using UserService.Application.Services;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services
{
	public class UserAppService : IUserService
	{
        private readonly IUserManagementService userManagementService;

        public UserAppService(IUserManagementService userManagementService)
		{
            this.userManagementService = userManagementService;
        }

        public Task<bool> AuthenticateUserAsync(string username, string password)
        {
            return userManagementService.AuthenticateUserAsync(username, password);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return userManagementService.GetUserByEmail(email);
        }

        public Task<User> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            return userManagementService.RegisterUserAsync(username, email, password);
        }

        public Task<bool> SetNotificationSettingsAsync(string userId, NotificationSettings notificationSettings)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserProfileAsync(string userId, string newUsername, string newEmail)
        {
            throw new NotImplementedException();
        }
    }
}

