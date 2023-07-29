using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Libros
{
    public class Dlibros
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Mlibros>> MostrarLibros()
        {
            var list = new List<Mlibros>();
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_leer_libros", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mlibros = new Mlibros();
                            mlibros.id = (int)item["id"];
                            mlibros.titulo_libro = (string)item["titulo_libro"];
                            mlibros.autor = (string)item["autor"];
                            mlibros.resumen = (string)item["resumen"];
                            mlibros.promedio_puntuacion = (double)item["promedio_puntuacion"];
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
