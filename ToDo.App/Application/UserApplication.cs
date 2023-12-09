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

        public async Task CreateUserAsync(CreateUserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            await _userService.CreateUserAsync(userModel);
        }
    }
}
