using ToDo.App.Dto.User;

namespace ToDo.App.Interfaces
{
    public interface IUserApplication
    {
        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();       
        Task<int?> CreateUserAsync(CreateUserDTO user);
        Task<bool> UpdateUserAsync(UpdateUserDTO user);
        Task<UserResponseDTO> GetUserByIdAsync(int userId);
        Task<bool> DeleteUserAsync(int userId);
    }
}
