using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamifyWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var User = await _userService.GetUserById(Id);
            return Ok(User);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> CreateUser(Guid Id)
        {
            await _userService.CreateUser(Id);
            return Ok();
        }
    }
}
