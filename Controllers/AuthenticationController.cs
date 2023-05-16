using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models;
using proiectDAW.Services.UserService;

namespace proiectDAW.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user) {
            await _userService.Create(user);
            return Ok();
        }   
    }
}