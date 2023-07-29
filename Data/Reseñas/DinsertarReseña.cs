using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Reseñas
{
    public class DinsertarReseña
    {
        Conexionbd cn = new Conexionbd();
        public async Task InsertarReseña(Mreseñas parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_crear_reseña", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue
                        ("p_reseña", parametros.reseña);
                    cmd.Parameters.AddWithValue
                        ("p_id_usuario", parametros.id_usuario);
                    cmd.Parameters.AddWithValue
                        ("p_id_libro", parametros.id_libro);
                    cmd.Parameters.AddWithValue
                        ("p_puntuacion", parametros.puntuacion);
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
