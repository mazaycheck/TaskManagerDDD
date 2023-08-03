using UserService.Data.Models;

namespace UserService.Data
{
    public interface IUserRepository
    {
        public Task<UserDbModel> GetUserByEmail(string email);
    }
}