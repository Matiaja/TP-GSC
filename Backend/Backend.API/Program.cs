using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var buildier = WebApplication.CreateBuilder(args);

buildier.Services.AddDbContext<ProyectoDBContext>(opt => opt.UseSqlServer(buildier.Configuration.GetConnectionString("PrestamosDb")));

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

buildier.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

buildier.Services.AddControllers();

var app = buildier.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseAuthentication();

app.MapControllers();

app.Run();


//using hace que se llame automaticamente al dispose
//using var context = new ProyectoDBContext();

//var categorias = await context.Categorias.ToListAsync();

/*

WriteToConsole(categorias);

static void WriteToConsole(IEnumerable<Categoria> categorias)
{
    foreach (Categoria categoria in categorias)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(categoria);
        Console.WriteLine(json);
    }
}

*/