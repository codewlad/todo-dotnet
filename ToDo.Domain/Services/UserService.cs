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

        public async Task<int> CreateUserAsync(UserModel user)
        {
            var response = await _userRepository.CreateUserAsync(user);

            return response;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var response = await _userRepository.DeleteUserAsync(userId);
            return response;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public Task<UserModel> UpdateUserAsync(UserModel user)
        {
            return _userRepository.UpdateUserAsync(user);
        }
    }
}
