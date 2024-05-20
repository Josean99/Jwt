using Jwt.DTOs;
using Jwt.Services.Services.Implementations;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        private readonly IConfiguration _config;

        public RoleController(IRolesService rolesService, IConfiguration config)
        {
            _rolesService = rolesService;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult<RoleResonseDto>> Post(RoleRequestDto dto)
        {
            var result = await _rolesService.Post(dto);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error al insertar");
        }

        [HttpPut]
        public async Task<ActionResult<RoleResonseDto>> Put(RoleRequestDto dto)
        {
            var result = await _rolesService.Put(dto);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error Updating");
        }

        [HttpDelete]
        [Route("SoftDelete/{id}")]
        public async Task<ActionResult<bool>> SoftDelete(Guid id)
        {
            var result = await _rolesService.SoftDelete(id);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Error Updating");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResonseDto>>> GetAll()
        {
            var result = await _rolesService.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error");
        }

        [HttpGet("GetUserRoles/{idUser}")]
        public async Task<ActionResult<List<RoleResonseDto>>> GetUserRoles(Guid idUser)
        {
            var result = await _rolesService.GetUserRoles(idUser);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error");
        }
    }
}
