using ToDo.App.Dto.User;

namespace ToDo.App.Interfaces
{
    public interface IUserApplication
    {
        Task<int> CreateUserAsync(CreateUserDTO user);

        Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO user);

        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();
        
        Task<bool> DeleteUserAsync(int userId);
        
        Task<UserResponseDTO> GetUserByIdAsync(int userId);
    }
}
