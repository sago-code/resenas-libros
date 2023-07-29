using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using resenas_libros.Data.Sesiones;
using resenas_libros.Models;

namespace resenas_libros.Controllers
{
    [ApiController]
    [Route("sesion")]
    public class SesionController : ControllerBase
    {
        private readonly string claveSecreta = "clave-secreta-para-firmar-el-token";

        [HttpPost("crearSesion")]
        public async Task<ActionResult<MsesionesActivas>> Post([FromBody] MsesionesActivas parametros)
        {
            string token = GenerarTokenJWT(parametros.id_usuario);

            var funcion = new DsesionesActivas();
            parametros.token = token;

            await funcion.Sesion(parametros);

            return parametros;
        }

        [HttpPost("cerrar_sesion")]
        public async Task<ActionResult> CerrarSesion([FromBody] MsesionesActivas parametros)
        {
            var funcion = new DcerrarSesion();
            await funcion.CerrarSesion(parametros.id_usuario, parametros.token);

            return Ok(new { Message = "Sesión cerrada correctamente." });
        }

        private string GenerarTokenJWT(int id_usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id_usuario", id_usuario.ToString())
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
