using AutoMapper;
using ToDo.App.Dto.User;
using ToDo.App.Interfaces;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;

namespace ToDo.App.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IEnumerable<UserResponseDTO> All()
        {
            IEnumerable<UserModel> users = _userService.All();
            var response = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return response;
        }

        public int? CreateUser(CreateUserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            return _userService.CreateUser(userModel);
        }

        public bool UpdateUser(UpdateUserDTO user)
        {
            return _userService.UpdateUser(_mapper.Map<UserModel>(user));
        }

        public UserResponseDTO GetUserById(int userId)
        {
            UserModel? user = _userService.GetUserById(userId);
            var response = _mapper.Map<UserResponseDTO>(user);
            return response;
        }

        public bool DeleteUser(int userId)
        {
            var response = _userService.DeleteUser(userId);

            return response;
        }
    }
}
