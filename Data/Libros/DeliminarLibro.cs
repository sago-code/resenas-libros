using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Libros
{
    public class DeliminarLibro
    {
        Conexionbd cn = new Conexionbd();
        public async Task EliminarLibro(int id, DateTime delete_at)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_eliminar_libro", sql))
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
