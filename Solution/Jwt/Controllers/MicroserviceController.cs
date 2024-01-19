using Jwt.DTOs;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MicroserviceController : ControllerBase
    {
        private readonly IMicroserviceService _microserviceService;

        public MicroserviceController(IMicroserviceService microserviceService)
        {
            _microserviceService = microserviceService;
        }

        [HttpPost]
        public async Task<ActionResult<MicroserviceResponseDto>> Post(MicroserviceRequestDto dto)
        {
            var result = await _microserviceService.Post(dto);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error al insertar");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MicroserviceResponseDto>>> GetAll()
        {
            var result = await _microserviceService.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Error");
        }
    }
}
