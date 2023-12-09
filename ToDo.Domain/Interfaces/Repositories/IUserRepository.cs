using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
    }
}
