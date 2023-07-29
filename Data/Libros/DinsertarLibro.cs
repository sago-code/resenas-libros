using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Libros
{
    public class DinsertarLibro
    {
        Conexionbd cn = new Conexionbd();
        public async Task InsertarLibro(MlCategoriasDelLibro parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_crear_libro", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue
                        ("p_titulo_libro", parametros.titulo_libro);
                    cmd.Parameters.AddWithValue
                        ("p_autor", parametros.autor);
                    cmd.Parameters.AddWithValue
                        ("p_portada_libro", parametros.portada_libro);
                    cmd.Parameters.AddWithValue
                        ("p_resumen", parametros.resumen);
                    cmd.Parameters.AddWithValue
                        ("p_promedio_puntuacion", parametros.promedio_puntuacion);
                    cmd.Parameters.AddWithValue
                        ("p_categorias", parametros.categorias);
                    cmd.Parameters.AddWithValue
                        ("p_create_at", parametros.create_at);
                    cmd.Parameters.AddWithValue
                        ("p_update_at", parametros.update_at);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
