using AutoMapper;
using DBContext;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
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
            var methodsToCreate = await CreateMethodsBasedOnSwaggerJson(JToken.Parse(dto.SwaggerContract));
            entity.Methods = methodsToCreate;
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

        private async Task<List<Method>> CreateMethodsBasedOnSwaggerJson(JToken json)
        {
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
