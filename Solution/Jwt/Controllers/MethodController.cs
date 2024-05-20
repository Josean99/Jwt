using Jwt.DTOs;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MethodController : ControllerBase
    {
        private readonly IMethodService _methodService;

        public MethodController(IMethodService methodService)
        {
            _methodService = methodService;
        }

        [HttpPost]
        public async Task<ActionResult<MethodResponseDto>> Post(MethodRequestDto dto)
        {
            var result = await _methodService.Post(dto);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error al insertar");
        }

        [HttpGet("GetByMicroservice/{idMicroservice}")]
        public async Task<ActionResult<List<MethodResponseDto>>> GetByMicroservice(Guid idMicroservice)
        {
            var result = await _methodService.GetByMicroservice(idMicroservice);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error");
        }

        [HttpGet("GetByRole/{idRole}")]
        public async Task<ActionResult<List<MethodResponseDto>>> GetByRole(Guid idRole)
        {
            var result = await _methodService.GetByRole(idRole);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error");
        }
    }
}
