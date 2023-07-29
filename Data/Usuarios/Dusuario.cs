using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Usuarios
{
    public class Dusuario
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Musuarios>> MostrarUsuario(int id)
        {
            var list = new List<Musuarios>();
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_leer_usuario", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("p_id", id));
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musuario = new Musuarios();
                            musuario.id = (int)item["id"];
                            musuario.nombre_usuario = (string)item["nombre_usuario"];
                            musuario.correo_usuario = (string)item["correo_usuario"];
                            musuario.contraseña = (string)item["contraseña"];
                            musuario.foto_usuario = (string)item["foto_usuario"];
                            musuario.create_at = (DateTime)item["create_at"];
                            musuario.update_at = (DateTime)item["update_at"];
                            if (item["delete_at"] != DBNull.Value)
                            {
                                musuario.delete_at = (DateTime)item["delete_at"];
                            }

                            list.Add(musuario);
                        }
                    }
                }
            }
            return list;
        }
    }
}
