using Jwt.DTOs;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        private readonly IConfiguration _config;

        public RolesController(IRolesService rolesService, IConfiguration config)
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
    }
}
