using Microsoft.AspNetCore.Mvc;
using resenas_libros.Data.Categorias;
using resenas_libros.Models;

namespace resenas_libros.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriasController : ControllerBase
    {
        [HttpGet("optenerCategorias")]
        public async Task<ActionResult<List<MCategorias>>> Get()
        {
            var funcion = new Dcategorias();
            var lista = await funcion.MostrarCategorias();
            return lista;
        }

        [HttpGet("optenerCategoria/{id}")]
        public async Task<ActionResult<List<MCategorias>>> OptenerCategoria(int id)
        {
            var funcion = new Dcategoria();
            var libro = await funcion.MostrarCategoria(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }




        [HttpPost("crearCategorias")]
        public async Task<OkObjectResult> Post([FromBody] MCategorias parametros)
        {
            parametros.create_at = DateTime.Now;
            parametros.update_at = DateTime.Now;

            var funcion = new DinsertarCategorias();
            await funcion.InsertarCategorias(parametros);

            return new OkObjectResult("success") { StatusCode = 201 };
        }

        [HttpPut("actualizarCategorias/{id}")]
        public async Task<OkObjectResult> Put(int id, [FromBody] MCategorias parametros)
        {
            var funcion = new DactualizarCategorias();
            parametros.update_at = DateTime.Now;
            parametros.id = id;

            await funcion.ActualizarCategorias(parametros);

            return new OkObjectResult("updated") { StatusCode = 200 };
        }

        [HttpGet("eliminarCategorias/{id}")]
        public async Task<ActionResult<List<MCategorias>>> DeliminarCategorias(int id)
        {
            var funcion = new DeliminarCategorias();
            var delete_at = DateTime.Now;
            await funcion.EliminarCategorias(id, delete_at);

            return new OkObjectResult("deleted") { StatusCode = 200 };
        }
    }
}