using Microsoft.AspNetCore.Mvc;
using ToDo.App.Dto.User;
using ToDo.App.Interfaces;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _userApplication.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userApplication.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDTO request)
        {
            var userId = await _userApplication.CreateUserAsync(request);

            return Ok(userId);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserDTO request)
        {
            await _userApplication.UpdateUserAsync(request);

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _userApplication.DeleteUserAsync(id);

            return Ok(response);
        }
    }
}
