using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Services.Services.Implementations
{
    public class MethodService : IMethodService
    {
        private readonly JwtContext _context;
        private readonly IMapper _mapper;

        public MethodService(JwtContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<MethodResponseDto> Post(MethodRequestDto dto)
        {
            Method entity = _mapper.Map<MethodRequestDto, Method>(dto);

            await _context.Methods.AddAsync(entity);
            _context.Save();

            MethodResponseDto result = _mapper.Map<Method, MethodResponseDto>(entity);

            return result;
        }

        public async Task<List<MethodResponseDto>> GetByMicroservice(Guid id)
        {
            var result = _context.Methods.Include(m=>m.Microservice).Where(m=>m.IdMicroservice == id).ToList();
            List<MethodResponseDto> resultDto = _mapper.Map<List<Method>, List<MethodResponseDto>>(result);
            return resultDto;
        }

        public async Task<List<MethodResponseDto>> GetByRole(Guid id)
        {
            var result = _context.Roles.Include(r=>r.Methods).ThenInclude(m=>m.Microservice).First(r=>r.Id == id);
            List<MethodResponseDto> resultDto = _mapper.Map<List<Method>, List<MethodResponseDto>>(result.Methods.ToList());
            return resultDto;
        }

        public async Task<List<MethodResponseDto>> GetForLogin(List<Guid> roles, Guid idMicroservice)
        {
            var resultMethods = new List<Method>();
            var resultRoles = _context.Roles.Include(r => r.Methods).Where(r => roles.Contains(r.Id));
            await resultRoles.ForEachAsync(r => resultMethods.AddRange(r.Methods.Where(m=>m.IdMicroservice == idMicroservice)));

            List<MethodResponseDto> resultDto = _mapper.Map<List<Method>, List<MethodResponseDto>>(resultMethods);
            return resultDto;
        }
    }

}
