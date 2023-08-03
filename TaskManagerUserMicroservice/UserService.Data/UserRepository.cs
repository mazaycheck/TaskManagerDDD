using System;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Models;

namespace UserService.Data
{
	public class UserRepository : IUserRepository
	{
        private readonly UserDbContext userDbContext;

        public UserRepository(UserDbContext userDbContext)
		{
            this.userDbContext = userDbContext;
        }

        public async Task<UserDbModel> GetUserByEmail(string email)
        {
            UserDbModel user = await userDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}

