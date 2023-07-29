using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Usuarios
{
    public class DactualizarUsuario
    {
        Conexionbd cn = new Conexionbd();
        public async Task ActualizarUsuario(Musuarios parametros)
        {
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_actualizar_usuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("p_id", parametros.id));

                    cmd.Parameters.AddWithValue
                        ("p_nombre_usuario", parametros.nombre_usuario);
                    cmd.Parameters.AddWithValue
                        ("p_correo_usuario", parametros.correo_usuario);
                    cmd.Parameters.AddWithValue
                        ("p_contraseña", parametros.contraseña);
                    cmd.Parameters.AddWithValue
                        ("p_foto_usuario", parametros.foto_usuario);
                    cmd.Parameters.AddWithValue
                        ("p_update_at", parametros.update_at);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
