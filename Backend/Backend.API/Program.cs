using Backend.API.DataAccess;
using Backend.API.Domain;
using Backend.API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProyectoDBContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("PrestamosDb")));


builder.Services.AddGrpc();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

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

/*
//Autenticacion
buildier.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveDeSeguridadConUnMinimoDe256Bits")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true
    });
*/

//app.UseAuthentication();