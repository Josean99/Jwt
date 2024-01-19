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

//REGISTER DBCONTEXT
var cs = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsMap>();

var connectionString = "";
if (builder.Environment.IsDevelopment())
{
    connectionString = cs.LocalHost;
}
else
{
    connectionString = cs.Docker;
}

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
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddHealthChecks();

builder.Services.RegisterAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwagger();

//builder.WebHost.UseUrls("http://*:5025");

builder.Services.RegisterAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.Run();
