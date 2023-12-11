using Microsoft.AspNetCore.Mvc;
using ToDo.App.Dto.User;
using ToDo.App.Interfaces;
using ToDo.Domain.Models;

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

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _userApplication.GetAllUsersAsync();

            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDTO request)
        {
            await _userApplication.CreateUserAsync(request);

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
