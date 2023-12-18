using ToDo.CrossCutting.Utils;
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

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<int?> CreateUserAsync(UserModel user)
        {
            ValidateData(user, true);

            EmailExists(user.Email!, true);

            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            var rowsAffected = await _userRepository.UpdateUserAsync(user);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var rowsAffected = await _userRepository.DeleteUserAsync(userId);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        public void ValidateData(UserModel user, bool create)
        {
            if (user == null)
            {
                throw new Exception(nameof(user));
            }

            if(string.IsNullOrEmpty(user.Name))
            {
                throw new Exception("O campo nome deve ser preenchido.");
            }

            if (user.Name.Length <= 2 || user.Name.Length > 200)
            {
                throw new Exception("O campo nome deve ter entre 3 e 200 caracteres.");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("O campo email deve ser preenchido.");
            }

            EmailHelper emailHelper = new EmailHelper();

            bool isValid = emailHelper.IsEmailValid(user.Email);

            if (!isValid)
            {
                throw new Exception("Email inválido.");
            }

            if (string.IsNullOrEmpty(user.Login))
            {
                throw new Exception("O campo login deve ser preenchido.");
            }

            if (user.Login.Length <= 2 || user.Login.Length > 20)
            {
                throw new Exception("O campo login deve ter entre 3 e 20 caracteres.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("O campo senha deve ser preenchido.");
            }

            if (user.Password.Length <= 6 || user.Password.Length > 12)
            {
                throw new Exception("O campo senha deve ter entre 6 e 12 caracteres.");
            }
        }

        bool EmailExists(string email, bool create)
        {
            var task = _userRepository.VerifyIfEmailExists(email).Result;

            if(task > 0)
            {
                throw new Exception("Este email já está em uso.");
            }

            return true;
        }
    }
}
