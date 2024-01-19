using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Jwt.Services.Utils
{
    public class JwtAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUsersService _usersService;
        private readonly IConfiguration _configuration;

        public JwtAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUsersService usersService,
            IConfiguration configuration
            ) : base(options, logger, encoder, clock)
        {
            _usersService = usersService;
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {                
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                string token = authHeader.Parameter;

                List<string> methods = _usersService.GetAllowedMethods(new Jwt.Services.DTOs.GetAllowedMethodsDto() { token = token, idMicroservice = Guid.Parse(_configuration.GetSection("Authority:MicroserviceId").Value) }).Result;
                string methodsJson = JsonConvert.SerializeObject(methods);
                var claims = new[] {
                    new Claim("AllowedMethods", methodsJson)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 401;
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }
            
            
        }
    }
}
