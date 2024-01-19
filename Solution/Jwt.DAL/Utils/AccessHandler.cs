using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;

namespace Jwt.Services.Utils
{
    public class AccessHandler : AuthorizationHandler<AccessRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMethodService methodService;
        private readonly IConfiguration configuration;

        public AccessHandler(IHttpContextAccessor httpContextAccessor, IMethodService methodService, IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.methodService = methodService;
            this.configuration = configuration;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            Claim? methodClaim = context.User.Claims.FirstOrDefault(c => c.Type == "AllowedMethods");
            if (methodClaim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var methods = JsonConvert.DeserializeObject<List<string>>(methodClaim.Value);
            string? controllerName = httpContextAccessor.HttpContext?.Request.RouteValues["controller"]?.ToString();
            string? actionName = httpContextAccessor.HttpContext?.Request.RouteValues["action"]?.ToString();

            if (controllerName != null && actionName != null)
            {
                var path = $"/api/{controllerName}/{actionName}";
                if (methods.Contains(path))
                {
                    context.Succeed(requirement);
                }
                else
                {                    
                    context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }

    public class AccessRequirement : IAuthorizationRequirement
    {
        //public List<Method> Methods { get; }

        public AccessRequirement()
        {
            //Methods = methods;
        }
    }
}
