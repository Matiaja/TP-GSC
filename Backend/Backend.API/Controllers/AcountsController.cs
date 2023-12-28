using Backend.API.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcountsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario.NombreUsuario != "Admin" || usuario.Clave != "1234")
                return Unauthorized();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ClaveDeSeguridadConUnMínimoDe256Bits"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, usuario.NombreUsuario) },
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            string jwt = tokenHandler.WriteToken(securityToken);

            return this.Ok(jwt);
        }
    }
}
