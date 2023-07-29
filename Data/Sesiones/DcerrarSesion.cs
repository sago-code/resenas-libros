using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using System.Data;

namespace resenas_libros.Data.Sesiones
{
    public class DcerrarSesion
    {
        Conexionbd cn = new Conexionbd();

        public async Task CerrarSesion(int id_usuario, string token)
        {
            try
            {
                using (var sql = new MySqlConnection(cn.cadenaSQL()))
                {
                    using (var cmd = new MySqlCommand("sp_cerrar_sesion", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_id_usuario", id_usuario);
                        cmd.Parameters.AddWithValue("p_token", token);

                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CerrarSesion: " + ex.Message);
            }
        }
    }
}
