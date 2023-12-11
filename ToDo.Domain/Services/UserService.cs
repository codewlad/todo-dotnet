using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;

namespace ToDo.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public Task<UserModel> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
