using Backend.API.DataAccess;
using Backend.API.Domain;
using Backend.API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ProyectoDBContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
}
else
{
    builder.Services.AddDbContext<ProyectoDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PrestamosDb")));
}

builder.Services.AddGrpc();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveDeSeguridadConUnMínimoDe256Bits")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true
    });

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(opt =>
    {
        opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
        {
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            [new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            }] = Array.Empty<string>()
        });
    });

builder.Services.AddControllers();

builder.Services.AddGrpc(opt => opt.EnableDetailedErrors = true);
builder.Services.AddGrpcReflection();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGrpcService<PrestamoServices>();

app.MapGrpcReflectionService();

app.Run();
