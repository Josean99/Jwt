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



        public async Task<UserResponseDto> Get(Guid id)
        {
            User? user = await _context.Users
                .Include(u => u.Roles)
                .FirstAsync(u => u.Id == id);

            if (user == null) { throw new Exception("User not found"); }

            UserResponseDto userDto = _mapper.Map<User, UserResponseDto>(user);
            return userDto;
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            List<User>? user = _context.Users.ToList();

            if (user == null) { throw new Exception("Users not found"); }

            List<UserResponseDto> userDto = _mapper.Map<List<User>, List<UserResponseDto>>(user);
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

        public async Task<UserResponseDto> Post(UserRequestDto dto)
        {
            try
            {
                User entity = _mapper.Map<UserRequestDto, User>(dto);
                entity.Password = GeneratePassword();
                entity.Roles = _context.Roles.Where(me => dto.Roles.Select(m => m).Contains(me.Id)).ToList();
                await _context.Users.AddAsync(entity);
                _context.Save();

                UserResponseDto result = _mapper.Map<User, UserResponseDto>(entity);

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<UserResponseDto> Put(UserRequestDto dto)
        {
            User? entity = await _context.Users.Include(m => m.Roles).FirstOrDefaultAsync(m => m.Id == dto.Id);
            if (entity is null) { throw new Exception("User not found"); }

            List<Role> roles = _context.Roles.Where(p => dto.Roles.Contains(p.Id)).ToList();

            entity.Roles = roles;
            entity.Name = dto.Username;
            entity.Name = dto.Name;
            entity.Name = dto.Surname;

            _context.Users.Update(entity);
            _context.Save();

            UserResponseDto result = _mapper.Map<User, UserResponseDto>(entity);

            return result;
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            User? entity = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (entity is null) { throw new Exception("User not found"); }

            entity.FechaBaja = DateTime.Now;

            _context.Users.Update(entity);
            _context.Save();

            return true;
        }

        public async Task<bool> ResetPassword(Guid idUser)
        {
            User? entity = await _context.Users.FirstOrDefaultAsync(m => m.Id == idUser);
            if (entity is null) { throw new Exception("User not found"); }

            entity.Password = GeneratePassword().ToString();

            _context.Users.Update(entity);
            _context.Save();

            return true;
        }

        private static string GeneratePassword()
        {
            return Guid.NewGuid().ToString();
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

        public async Task<UserResponseDto> SignUpUser(SignUpDto dto)
        {
            try
            {
                User newUser = _mapper.Map<SignUpDto,User>(dto);
                await _context.Users.AddAsync(newUser);
                _context.Save();
                UserResponseDto userCreated = _mapper.Map<User, UserResponseDto>(newUser);
                return userCreated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserResponseDto> AssociateRoles(Guid idUser, List<Guid> roles)
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

                UserResponseDto userCreated = _mapper.Map<User, UserResponseDto>(user);
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
