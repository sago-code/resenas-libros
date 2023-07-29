using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Reseñas
{
    public class Dreseñas
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Mreseñas>> MostrarReseñas()
        {
            var list = new List<Mreseñas>();
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_ver_reseñas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mlibros = new Mreseñas();
                            mlibros.id = (int)item["id"];
                            mlibros.reseña = (string)item["reseña"];
                            mlibros.id_usuario = (int)item["id_usuario"];
                            mlibros.id_libro = (int)item["id_libro"];
                            mlibros.create_at = (DateTime)item["create_at"];
                            mlibros.update_at = (DateTime)item["update_at"];
                            if (item["delete_at"] != DBNull.Value)
                            {
                                mlibros.delete_at = (DateTime)item["delete_at"];
                            }
                            list.Add(mlibros);
                        }
                    }
                }
            }
            return list;
        }
    }
}
