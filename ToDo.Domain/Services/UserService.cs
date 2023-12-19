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

        public IEnumerable<UserModel> All()
        {
            return _userRepository.All();
        }

        public int? CreateUser(UserModel user)
        {
            ValidateData(user, true);

            EmailExists(user.Email!, true);

            return _userRepository.CreateUser(user);
        }

        public bool UpdateUser(UserModel user)
        {
            var rowsAffected = _userRepository.UpdateUser(user);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        public UserModel? GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool DeleteUser(int userId)
        {
            var rowsAffected = _userRepository.DeleteUser(userId);

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

            EmailValidation emailValidation = new EmailValidation();

            bool isValid = emailValidation.IsEmailValid(user.Email);

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

            if (user.Password.Length < 6 || user.Password.Length > 12)
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
