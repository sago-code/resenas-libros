using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Usuarios
{
    public class Dlogin
    {
        Conexionbd cn = new Conexionbd();
        private Mlogin usuarioAutenticado;

        public async Task<bool> ValidarCredenciales(Mlogin parametros)
        {
            try
            {
                using (var sql = new MySqlConnection(cn.cadenaSQL()))
                {
                    using (var cmd = new MySqlCommand("sp_login", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_nombre_usuario", parametros.nombre_usuario);

                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var contraseñaEncriptada = reader["contraseña"].ToString();
                                bool contrasenaCorrecta = BCrypt.Net.BCrypt.Verify(parametros.contraseña, contraseñaEncriptada);

                                if (contrasenaCorrecta)
                                {
                                    usuarioAutenticado = new Mlogin
                                    {
                                        id = Convert.ToInt32(reader["id"]),
                                        nombre_usuario = reader["nombre_usuario"].ToString(),
                                        contraseña = reader["contraseña"].ToString()
                                    };

                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ValidarCredenciales: " + ex.Message);
            }

            return false;
        }

        public Mlogin ObtenerUsuarioAutenticado()
        {
            return usuarioAutenticado;
        }

        public void ResetVariable()
        {
            usuarioAutenticado = null;
        }
    }
}
