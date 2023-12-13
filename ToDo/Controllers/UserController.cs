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

            if(users != null && users.Any())
                return Ok(users);
            return NotFound("Nenhum usuário cadastrado.");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDTO request)
        {
            int? userId = await _userApplication.CreateUserAsync(request);

            if(userId.HasValue)
                return Ok($"Usuário atualizado com sucesso! ID: {userId}");
            return BadRequest("Não foi possível criar o usuário.");

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserDTO request)
        {
            var response = await _userApplication.UpdateUserAsync(request);

            if (response)
                return Ok("Usuário atualizado com sucesso!");
            return NotFound("Não foi possível atualizar o usuário.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userApplication.GetUserByIdAsync(id);

            if(user !=  null)
                return Ok(user);
            return NotFound("Usuário não encontrado.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _userApplication.DeleteUserAsync(id);

            if(response)
                return Ok("Usuário excluído com sucesso!");
            return NotFound("Não foi possível excluir o usuário.");
        }
    }
}
