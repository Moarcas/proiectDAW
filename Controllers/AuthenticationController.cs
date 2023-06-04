using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
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
        public IActionResult Register(User user) {
            if (_userService.IsEmailAlreadyUsed(user.email)) {
                return BadRequest(new { message = "Email already exists" });
            }
            var registeredUser = _userService.Create(user).Data;
            return Ok(registeredUser);
        }  

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto) {  
            var result = _userService.Authenticate(loginDto);
            
            System.Console.WriteLine(result);
            if (result.Success == false) {
                return BadRequest(new { message = result.Message });
            }

            return Ok(result.Data);  
        } 

        [HttpGet("is-logged-in")]
        public IActionResult IsLoggedIn() {
            if (HttpContext.Items["userId"] == null) {
                return Unauthorized();
            }
            return Ok(new { message = "User is logged in" });
        }
    }
}