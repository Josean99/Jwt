using Jwt.DTOs;
using Jwt.Services.DTOs;
using Jwt.Services.Services.Implementations;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDto>>> GetAll()
        {
            var result = await _userService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserResponseDto>> Get(Guid id)
        //{
        //    var result = await _userService.Get(id);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("Error");
        //}

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Post(UserRequestDto user)
        {
            var result = await _userService.Post(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        [HttpPut]
        public async Task<ActionResult<UserResponseDto>> Put(UserRequestDto user)
        {
            var result = await _userService.Put(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        [HttpDelete]
        [Route("SoftDelete/{id}")]
        public async Task<ActionResult<bool>> SoftDelete(Guid id)
        {
            var result = await _userService.SoftDelete(id);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Error Updating");
        }

        [HttpPut("ResetPassword/{idUser}")]
        public async Task<ActionResult<UserResponseDto>> ResetPassword(Guid idUser)
        {
            var result = await _userService.ResetPassword(idUser);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        //[HttpPost("AssociateRole/{idUser}")]
        //public async Task<ActionResult<UserResponseDto>> AssociateRole(Guid idUser, [FromBody] List<Guid> roles)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Error de Model State");
        //    }
        //    var result = await _userService.AssociateRoles(idUser, roles);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("Error");
        //}

        

    }
}
