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

        public async Task<int> CreateUserAsync(CreateUserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            return await _userService.CreateUserAsync(userModel);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var response = await _userService.DeleteUserAsync(userId);

            return response;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync()
        {
            IEnumerable<UserModel> users = await _userService.GetAllUsersAsync();
            var response = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return response;
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int userId)
        {
            UserModel user = await _userService.GetUserByIdAsync(userId);
            var response = _mapper.Map<UserResponseDTO>(user);
            return response;
        }

        public async Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO user)
        {
            UserModel updatedUser = await _userService.UpdateUserAsync(_mapper.Map<UserModel>(user));

            var response = _mapper.Map<UserResponseDTO>(updatedUser);

            return response;
        }
    }
}
