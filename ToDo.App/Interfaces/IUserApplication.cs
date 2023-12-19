using ToDo.App.Dto.User;

namespace ToDo.App.Interfaces
{
    public interface IUserApplication
    {
        IEnumerable<UserResponseDTO> All();       
        int? CreateUser(CreateUserDTO user);
        bool UpdateUser(UpdateUserDTO user);
        UserResponseDTO GetUserById(int userId);
        bool DeleteUser(int userId);
    }
}
