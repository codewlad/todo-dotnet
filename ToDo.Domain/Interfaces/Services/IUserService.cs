using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<int?> CreateUserAsync(UserModel user);
        Task<bool> UpdateUserAsync(UserModel user);
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<bool> DeleteUserAsync(int userId);
    }
}
