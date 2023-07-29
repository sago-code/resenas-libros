using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Categorias
{
    public class DactualizarCategorias
    {
        Conexionbd cn = new Conexionbd();
        public async Task ActualizarCategorias(MCategorias parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_actualizar_categoria", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("p_id", parametros.id));

                    cmd.Parameters.AddWithValue
                        ("p_nombre_categoria", parametros.nombre_categoria);
                    cmd.Parameters.AddWithValue
                        ("p_update_at", parametros.update_at);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
