using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
using System.Data;

namespace Jwt.Services.Services.Implementations
{
    public class RolesService : IRolesService
    {
        private readonly JwtContext _context;
        private readonly IMapper _mapper;

        public RolesService(JwtContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<RoleResonseDto> Post(RoleRequestDto dto)
        {
            try
            {
                List<Method> methods = _context.Methods.ToList();

                Role entity = _mapper.Map<RoleRequestDto, Role>(dto);

                entity.Methods = methods.Where(method =>
                dto.Methods.Contains(method.Id)).ToList();

                await _context.Roles.AddAsync(entity);
                _context.Save();

                RoleResonseDto result = _mapper.Map<Role, RoleResonseDto> (entity);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }

}
