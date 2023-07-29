using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Categorias
{
    public class DinsertarCategorias
    {
        Conexionbd cn = new Conexionbd();
        public async Task InsertarCategorias(MCategorias parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_crear_categorias", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue
                        ("p_nombre_categoria", parametros.nombre_categoria);
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
