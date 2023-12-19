using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> All();
        int? CreateUser(UserModel user);
        bool UpdateUser(UserModel user);
        UserModel? GetUserById(int userId);
        bool DeleteUser(int userId);
    }
}
