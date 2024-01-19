using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;

namespace Jwt.Services.Services.Implementations
{
    public class MicroserviceService : IMicroserviceService
    {
        private readonly JwtContext _context;
        private readonly IMapper _mapper;

        public MicroserviceService(JwtContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<MicroserviceResponseDto> Post(MicroserviceRequestDto dto)
        {
            Microservice entity = _mapper.Map<MicroserviceRequestDto, Microservice>(dto);

            await _context.Microservices.AddAsync(entity);
            _context.Save();

            MicroserviceResponseDto result = _mapper.Map<Microservice, MicroserviceResponseDto>(entity);

            return result;
        }

        public async Task<List<MicroserviceResponseDto>> GetAll()
        {
            try
            {
                var result = _context.Microservices.ToList();
                List<MicroserviceResponseDto> resultDto = _mapper.Map<List<Microservice>, List<MicroserviceResponseDto>>(result);
                return resultDto;
            }
            catch (Exception)
            {
                throw;
            }
            
        }


    }

}
