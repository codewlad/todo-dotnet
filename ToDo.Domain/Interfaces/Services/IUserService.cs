using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
    }
}
