using System;
using UserService.Domain.Models;

namespace UserService.Application.Services
{
	public interface IUserManagementService
	{
        Task<bool> RegisterUserAsync(string username, string email, string password);
        Task<bool> AuthenticateUserAsync(string username, string password);
        Task<User> GetUserByEmail(string email);
    }
}

