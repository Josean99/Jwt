using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Jwt.Services.Services.Interfaces;

namespace Jwt.Services.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly JwtContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsersService(JwtContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }



        public async Task<UserDto> Get(Guid id)
        {
            User? user = await _context.Users
                .Include(u => u.Roles)
                .FirstAsync(u => u.Id == id);

            if (user == null) { throw new Exception("Usuario no encontrado"); }

            UserDto userDto = _mapper.Map<User,UserDto>(user);
            return userDto;
        }

        public async Task<List<string>> GetAllowedMethods(GetAllowedMethodsDto dto)
        {
            List<Guid> currentRoles = ReadToken(dto.token);

            IQueryable<Role> roles = _context.Roles
                .Include(u => u.Methods)
                .ThenInclude(u=>u.Microservice)
                .Where(r => currentRoles.Contains(r.Id) );

            List<Method> metodos = new List<Method>();
            foreach (var m in roles.Select(r => r.Methods))
            {
                metodos.AddRange(m);
            }
            
            var methods = metodos.Where(m=>m.IdMicroservice == dto.idMicroservice).Select(m=>m.Path).ToList();

            return methods;
        }

        public async Task<string?> LogInUser(LoginUserDto dto)
        {
            try
            {
                var user = await _context.Users.Include(u=>u.Roles).FirstAsync(user => user.Name.ToLower() == dto.UserName.ToLower()
                   && user.Password == dto.Password);

                if (user == null) { throw new Exception("Usuario no encontrado"); }

                var token = GenerateToken(user);

                return token;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> SignUpUser(SignUpDto dto)
        {
            try
            {
                User newUser = _mapper.Map<SignUpDto,User>(dto);
                await _context.Users.AddAsync(newUser);
                _context.Save();
                UserDto userCreated = _mapper.Map<User, UserDto>(newUser);
                return userCreated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> AssociateRoles(Guid idUser, List<Guid> roles)
        {
            try
            {
                var taskGetRoles = _context.Roles.Where(r => roles.Contains(r.Id));
                if(taskGetRoles.Count() < roles.Count()) { throw new Exception("Some Role haven't been found"); }

                var user = await _context.Users.FirstAsync(user => user.Id == idUser);
                if (user == null) { throw new Exception("User not found"); }

                user.Roles = await taskGetRoles.ToListAsync();

                _context.Users.Update(user);
                _context.Save();

                UserDto userCreated = _mapper.Map<User, UserDto>(user);
                return userCreated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Private

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authority:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims
            string roles = JsonSerializer.Serialize(user.Roles.Select(r=>r.Id).ToList());
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim("Roles", roles),
            };


            // Crear el token

            var token = new JwtSecurityToken(
                _config["Authority:Issuer"],
                _config["Authority:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Guid> ReadToken(string token)
        {
            try
            {
                var jwtToken = new JwtSecurityToken(token);

                Claim? rolesClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Roles");
                if (rolesClaim == null)
                {
                    throw new Exception("Controlled exception reading the token");
                }

                List<Guid> roles = JsonSerializer.Deserialize<List<Guid>>(rolesClaim.Value);
                return roles;
            }
            catch (SecurityTokenException ex)
            {
                throw ex;
            }
        }

        #endregion

    }

}
