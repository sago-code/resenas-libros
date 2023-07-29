using Microsoft.AspNetCore.Mvc;
using resenas_libros.Data.Libros;
using resenas_libros.Models;

namespace resenas_libros.Controllers
{
    [ApiController]
    [Route("libros")]
    public class LibrosController : ControllerBase
    {
        [HttpGet("optenerLibros")]
        public async Task<ActionResult<List<Mlibros>>> Get()
        {
            var funcion = new Dlibros();
            var lista = await funcion.MostrarLibros();
            return lista;
        }

        [HttpGet("optenerLibrosConCategorias")]
        public async Task<ActionResult<List<MlibrosConCategorias>>> GetLibroConCategorias()
        {
            var funcion = new DlibrosConCategorias();
            var lista = await funcion.MostrarLibrosConCategorias();
            return lista;
        }

        [HttpGet("optenerLibro/{id}")]
        public async Task<ActionResult<List<Mlibros>>> GetLibroPorId(int id)
        {
            var funcion = new Dlibro();
            var libro = await funcion.MostrarLibro(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost("crearLibro")]
        public async Task<OkObjectResult> Post([FromBody] MlCategoriasDelLibro parametros)
        {
            parametros.create_at = DateTime.Now;
            parametros.update_at = DateTime.Now;

            var funcion = new DinsertarLibro();
            await funcion.InsertarLibro(parametros);

            return new OkObjectResult("success") { StatusCode = 201 };
        }

        [HttpPut("actualizarLibro/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mlibros parametros)
        {
            var funcion = new DactualizarLibro();
            parametros.update_at = DateTime.Now;
            parametros.id = id;
            await funcion.ActualizarLibro(parametros);

            return new OkObjectResult("updated") { StatusCode = 200 };
        }

        [HttpGet("eliminarLibro/{id}")]
        public async Task<ActionResult<List<Mlibros>>> DesactivarLibro(int id)
        {
            var funcion = new DeliminarLibro();
            var delete_at = DateTime.Now;
            await funcion.EliminarLibro(id, delete_at);

            return new OkObjectResult("deleted") { StatusCode = 200 };
        }
    }
}