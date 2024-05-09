using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthServer.Core;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            // Validate user credentials
            var isValidCredentials = await _authService.ValidateCredentials(model.Username, model.Password);
            if (!isValidCredentials)
            {
                return Unauthorized(); // Return 401 Unauthorized if credentials are invalid
            }

            // Fetch user by username
            var user = await _userService.GetUserByUsername(model.Username);
            if (user == null)
            {
                return NotFound(); // Return 404 Not Found if user not found
            }

            // Generate JWT token
            var token = await _authService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
    }
}
