using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int userId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
    }
}
