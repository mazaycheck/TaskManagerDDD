using System;
namespace UserService.Application;

using System.Threading.Tasks;
using UserService.Application.Models;
using UserService.Domain.Models;

public interface IUserService
{
    Task<bool> RegisterUserAsync(string username, string email, string password);
    Task<bool> AuthenticateUserAsync(string username, string password);
    Task<User> UpdateUserProfileAsync(string userId, string newUsername, string newEmail);
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> SetNotificationSettingsAsync(string userId, NotificationSettings notificationSettings);
}
