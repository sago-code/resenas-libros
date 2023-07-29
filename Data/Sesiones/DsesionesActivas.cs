using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Sesiones
{
    public class DsesionesActivas
    {
        Conexionbd cn = new Conexionbd();
        public async Task Sesion(MsesionesActivas parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_crear_sesion", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue
                        ("p_id_usuario", parametros.id_usuario);
                    cmd.Parameters.AddWithValue
                        ("p_token", parametros.token);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
