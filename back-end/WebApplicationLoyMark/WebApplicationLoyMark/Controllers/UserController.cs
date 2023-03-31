using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Contracts.Service;
using Microsoft.AspNetCore.Cors;
using WebApplicationLoyMark.Models;

namespace WebApplicationLoyMark.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            IList<User> res = await _userService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetById(int id)
        {
            User res = await _userService.GetUserById(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("getTasks")]
        public async Task<ActionResult<List<Activity>>> GetTaskList()
        {
            List<Activity> res = await _userService.GetActivity();
            return Ok(res);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            await _userService.Create(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
        {
            await _userService.Update(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Disabled(id);
            return Ok();
        }
    }
}
