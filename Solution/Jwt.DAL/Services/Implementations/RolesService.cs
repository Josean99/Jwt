using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
                Role entity = _mapper.Map<RoleRequestDto, Role>(dto);
                entity.Methods = _context.Methods.Where(me => dto.Methods.Select(m => m).Contains(me.Id)).ToList();
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

        public async Task<RoleResonseDto> Put(RoleRequestDto dto)
        {
            Role? entity = await _context.Roles.Include(m => m.Methods).FirstOrDefaultAsync(m => m.Id == dto.Id);
            if (entity is null) { throw new Exception("Role not found"); }

            List<Method> methods = entity.Methods.Where(p => dto.Methods.Contains(p.Id)).ToList();
            //List<Method> methodsDisasociate = entity.Methods.Where(p => !methods.Any(p2 => p2.Id == p.Id)).ToList();
            //if (methodsDisasociate.Any())
            //{
            //    methodsDisasociate.ForEach(m => m.FechaBaja = DateTime.Now);
            //    _context.Methods.UpdateRange(methodsDisasociate);
            //}
            entity.Methods = methods;
            entity.Name = dto.Name;

            _context.Roles.Update(entity);
            _context.Save();

            RoleResonseDto result = _mapper.Map<Role, RoleResonseDto>(entity);

            return result;
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            Role? entity = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (entity is null) { throw new Exception("Role not found"); }

            entity.FechaBaja = DateTime.Now;

            _context.Roles.Update(entity);
            _context.Save();

            return true;
        }

        public async Task<List<RoleResonseDto>> GetAll()
        {
            try
            {
                var result = _context.Roles.ToList();
                List<RoleResonseDto> resultDto = _mapper.Map<List<Role>, List<RoleResonseDto>>(result);
                return resultDto;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}
