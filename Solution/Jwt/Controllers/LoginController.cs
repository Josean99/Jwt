using Jwt.Services.DTOs;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IConfiguration _config;

        public LoginController(IUsersService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet("Enviroment")]
        public ActionResult<string> Enviroment()
        {
            return Ok(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginUserDto userLogin)
        {
            var token = await _userService.LogInUser(userLogin);

            if (token != null)
            {                             
                return Ok(token);
            }

            return NotFound("Usuario no encontrado");
        }

        [HttpPost("GetAllowedMethods")]
        public async Task<ActionResult<List<string>>> GetAllowedMethods([FromBody] GetAllowedMethodsDto dto)
        {
            List<string> methods = await _userService.GetAllowedMethods(dto);

            if (dto.token != null)
            {
                return Ok(methods);
            }

            return NotFound("User not registered");
        }


    }
}
