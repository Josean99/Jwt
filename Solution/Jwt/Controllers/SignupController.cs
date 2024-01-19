using Jwt.DTOs;
using Jwt.Services.DTOs;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SignupController : ControllerBase
    {
        private readonly IUsersService _userService;

        public SignupController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(SignUpDto signUpUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _userService.SignUpUser(signUpUser);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        [HttpPost("AssociateRole/{idUser}")]
        public async Task<ActionResult<UserDto>> AssociateRole(Guid idUser, [FromBody] List<Guid> roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _userService.AssociateRoles(idUser, roles);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

    }
}
