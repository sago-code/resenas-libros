using Microsoft.AspNetCore.Mvc;
using resenas_libros.Data.Libros;
using resenas_libros.Data.Reseñas;
using resenas_libros.Models;

namespace resenas_libros.Controllers
{
    [ApiController]
    [Route("reseñas")]
    public class ReseñasController : ControllerBase
    {
        [HttpGet("optenerReseñas")]
        public async Task<ActionResult<List<Mreseñas>>> Get()
        {
            var funcion = new Dreseñas();
            var lista = await funcion.MostrarReseñas();
            return lista;
        }

        [HttpPost("crearReseña")]
        public async Task<OkObjectResult> Post([FromBody] Mreseñas parametros)
        {
            parametros.create_at = DateTime.Now;
            parametros.update_at = DateTime.Now;

            var funcion = new DinsertarReseña();
            await funcion.InsertarReseña(parametros);

            return new OkObjectResult("success") { StatusCode = 201 };
        }
    }
}
