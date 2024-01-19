using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Jwt.Services.Services.Implementations;
using Jwt.Services.Services.Interfaces;
using Jwt.Services.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace Jwt.Services.RegisterExtension
{
    public static class RegisterExtension
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IMicroserviceService, MicroserviceService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IServiceCollection RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.Requirements.Add(new AccessRequirement());
                });
                options.DefaultPolicy = options.GetPolicy("Admin");
            });

            services.AddScoped<IAuthorizationHandler, AccessHandler>();

            return services;
        }

        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        //ValidAudience = builder.Configuration["Jwt:Audience"],
            //        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //    };
            //});

            services.AddAuthentication("Bearer")
                .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>("Bearer", null);

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
            });

            return services;
        }


    }
}
