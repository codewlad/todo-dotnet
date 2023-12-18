using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<int?> CreateUserAsync(UserModel user);
        Task<int> UpdateUserAsync(UserModel user);
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<int> DeleteUserAsync(int userId);
        Task<int?> VerifyIfEmailExists(string email);
    }
}
