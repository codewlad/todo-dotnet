using Microsoft.AspNetCore.Mvc;
using ToDo.App.Dto.User;
using ToDo.App.Interfaces;
using ToDo.CrossCutting.Utils;

namespace ToDo.Api.Controllers.ToDo
{
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpGet]
        public ResultApi<IEnumerable<UserResponseDTO>> All()
        {
            var res = new ResultApi<IEnumerable<UserResponseDTO>>()
            {
                Result = _userApplication.All()
            };

            return res;
        }

        [HttpPost]
        public ResultApi<int?> Create([FromBody] CreateUserDTO request)
        {

            var res = new ResultApi<int?>()
            {
                Result = _userApplication.CreateUser(request)
            };

            return res;
        }

        [HttpPut]
        public ResultApi<bool> Update([FromBody] UpdateUserDTO request)
        {
            var res = new ResultApi<bool>()
            {
                Result = _userApplication.UpdateUser(request)
            };

            return res;
        }

        [HttpGet("{id}")]
        public ResultApi<UserResponseDTO> UserById(int id)
        {
            var res = new ResultApi<UserResponseDTO>()
            {
                Result = _userApplication.GetUserById(id)
            };

            return res;
        }

        [HttpDelete("{id}")]
        public ResultApi<bool> Delete(int id)
        {
            var res = new ResultApi<bool>()
            {
                Result = _userApplication.DeleteUser(id)
            };

            return res;
        }
    }
}
