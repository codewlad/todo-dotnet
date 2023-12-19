using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> All();
        int? CreateUser(UserModel user);
        int UpdateUser(UserModel user);
        UserModel? GetUserById(int userId);
        int DeleteUser(int userId);
        Task<int?> VerifyIfEmailExists(string email);
    }
}
