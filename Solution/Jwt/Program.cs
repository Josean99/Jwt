using DBContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Jwt.Services.RegisterExtension;
using Jwt.Services.Mappers;
using Infrastructure.Logging;
using Jwt.Services.Utils;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile($"appsettings.DockerStaging.json", optional: true, reloadOnChange: true);

//REGISTER DBCONTEXT
var cs = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsMap>();

var connectionString = cs!.jwtMS;

builder.Services.AddDbContext<JwtContext>(options =>
    options.UseNpgsql(connectionString ?? throw new InvalidOperationException("Connection string 'DataContext' not found."))
    );

//REGISTER SERVICES
builder.Services.RegisterServices();

////REGISTER LOGGING
builder.Logging.RegisterLogging(builder.Configuration);

//Automapper
builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddHealthChecks();

builder.Services.RegisterAuthentication();
builder.Services.RegisterAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwagger();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "DockerTest")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.Run();
