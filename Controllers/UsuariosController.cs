using Microsoft.AspNetCore.Mvc;
using resenas_libros.Data.Usuarios;
using resenas_libros.Models;

namespace resenas_libros.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Musuarios>>> GetLibroPorId(int id)
        {
            var funcion = new Dusuario();
            var usuarios = await funcion.MostrarUsuario(id);

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound(new { Message = "Usuario no encontrado." });
            }

            return usuarios;
        }

        [HttpPost("crearUsuario")]
        public async Task<OkObjectResult> Post([FromBody] Musuarios parametros)
        {
            parametros.create_at = DateTime.Now;
            parametros.update_at = DateTime.Now;

            string contrasenaEncriptada = BCrypt.Net.BCrypt.HashPassword(parametros.contraseña);
            parametros.contraseña = contrasenaEncriptada;

            var funcion = new DinsertarUsuario();
            await funcion.InsertarUsuario(parametros);

            return new OkObjectResult("success") { StatusCode = 201 };
        }

        [HttpPost("login")]
        public async Task<ActionResult<Mlogin>> Login([FromBody] Mlogin parametros)
        {
            var funcion = new Dlogin();
            bool autenticado = await funcion.ValidarCredenciales(parametros);

            if (!autenticado)
            {
                return Unauthorized(new { Message = "Credenciales inválidas." });
            }

            var usuarioAutenticado = funcion.ObtenerUsuarioAutenticado();

            if (usuarioAutenticado == null)
            {
                return BadRequest(new { Message = "Error en la autenticación." });
            }

            return usuarioAutenticado;
        }


        [HttpPut("actualizarUsuario/{id}")]
        public async Task<OkObjectResult> Put(int id, [FromBody] Musuarios parametros)
        {
            parametros.update_at = DateTime.Now;
            parametros.id = id;

            string contrasenaEncriptada = BCrypt.Net.BCrypt.HashPassword(parametros.contraseña);
            parametros.contraseña = contrasenaEncriptada;

            var funcion = new DactualizarUsuario();
            await funcion.ActualizarUsuario(parametros);

            return new OkObjectResult("updated") { StatusCode = 200 };
        }


        [HttpGet("eliminarUsuario/{id}")]
        public async Task<ActionResult<List<Mlibros>>> DesactivarUsuario(int id)
        {
            var funcion = new DeliminarUsuario();
            var delete_at = DateTime.Now;
            await funcion.EliminarUsuario(id, delete_at);

            return new OkObjectResult("deleted") { StatusCode = 200 };
        }
    }
}