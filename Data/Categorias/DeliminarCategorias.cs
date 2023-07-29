using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using System.Data;

namespace resenas_libros.Data.Categorias
{
    public class DeliminarCategorias
    {
        Conexionbd cn = new Conexionbd();
        public async Task EliminarCategorias(int id, DateTime delete_at)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_eliminar_categorias", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("p_id", id));

                    cmd.Parameters.AddWithValue
                        ("p_delete_at", delete_at);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
