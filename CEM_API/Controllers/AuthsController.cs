using Microsoft.AspNetCore.Mvc;

namespace CEM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        public AuthsController(AuthService authService, AdminUsersService adminService)
        {
            AdminService = adminService;
            AuthService = authService;
        }

        public AuthService AuthService { get; }
        public AdminUsersService AdminService { get; }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthDTO auth)
        {
            bool passwordMatch = false;

            var logged = await AdminService.Get(auth.UserLogin);

            if (logged != null)
            {
                var hashed = AdminService.HashPassword(auth.Password);
                passwordMatch = hashed.Equals(logged.Password);
            }

            if (logged == null || !passwordMatch) return BadRequest(new
            {
                token = string.Empty,
                validity = string.Empty,
                login_status = "Failed",
                login_at = DateTimeOffset.Now
            });

            var token = AuthService.GetAuthToken(logged.UserId, logged.Role!);

            return Ok(new
            {
                validity = "30mins",
                login_at = DateTimeOffset.Now,
                login_status = "Success",
                token = token,
            });
        }
    }
}
