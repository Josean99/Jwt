using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

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
            if (dto.SwaggerContract is not null)
            {
                var methodsToCreate = await CreateMethodsBasedOnSwaggerJson(JToken.Parse(dto.SwaggerContract));
                entity.Methods = methodsToCreate;
            }            
            await _context.Microservices.AddAsync(entity);            
            _context.Save();

            MicroserviceResponseDto result = _mapper.Map<Microservice, MicroserviceResponseDto>(entity);

            return result;
        }

        public async Task<MicroserviceResponseDto> Put(MicroserviceRequestDto dto)
        {
            Microservice? entity = await _context.Microservices.Include(m=>m.Methods).FirstOrDefaultAsync(m=>m.Id == dto.Id);
            if (entity is null){ throw new Exception("Microservice not found"); }

            if (dto.SwaggerContract is not null)
            {
                var methodsToCreate = await CreateMethodsBasedOnSwaggerJson(JToken.Parse(dto.SwaggerContract));
                entity.Methods = methodsToCreate;
            }
            else
            {
                List<Method> methods = _mapper.Map<List<MethodRequestDto>, List<Method>>(dto.Methods);
                List<Method> methodsToDelete = entity.Methods.Where(p => !dto.Methods.Any(p2 => p2.Id == p.Id)).ToList();
                if (methodsToDelete.Any())
                {
                    methodsToDelete.ForEach(m => m.FechaBaja = DateTime.Now);
                    _context.Methods.UpdateRange(methodsToDelete);
                }                
                entity.Methods = methods;
            }
            
            entity.Name = dto.Name;            

            _context.Microservices.Update(entity);
            _context.Save();

            MicroserviceResponseDto result = _mapper.Map<Microservice, MicroserviceResponseDto>(entity);

            return result;
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            Microservice? entity = await _context.Microservices.FirstOrDefaultAsync(m => m.Id == id);
            if (entity is null) { throw new Exception("Microservice not found"); }

            entity.FechaBaja = DateTime.Now;

            _context.Microservices.Update(entity);
            _context.Save();

            return true;
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

        private async Task<List<Method>> CreateMethodsBasedOnSwaggerJson(JToken json)
        {
            //TODO Check if Methods are already created for Put Method

            var result = new List<Method>();
            JObject methods = JObject.Parse(json["paths"].ToString());
            foreach (var m in methods)
            {
                var methodName = m.Key;
                var methodData = JObject.Parse(m.Value.ToString()).GetEnumerator();
                methodData.MoveNext();
                var methodVerb = methodData.Current.Key;
                methodData.Dispose();
                Method method = new Method()
                {
                    Path = methodName,
                    Verb = methodVerb.ToUpper(),
                };
                result.Add(method);
            }
            return result;
        }

    }

}
