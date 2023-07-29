using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Libros
{
    public class DlibrosConCategorias
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<MlibrosConCategorias>> MostrarLibrosConCategorias()
        {
            var list = new List<MlibrosConCategorias>();
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_obtener_libros_con_categorias", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mLibrosConCategorias = new MlibrosConCategorias();
                            mLibrosConCategorias.id = (int)item["id"];
                            mLibrosConCategorias.titulo_libro = (string)item["titulo_libro"];
                            mLibrosConCategorias.autor = (string)item["autor"];
                            mLibrosConCategorias.portada_libro = (string)item["portada_libro"];
                            mLibrosConCategorias.resumen = (string)item["resumen"];
                            if (item["categorias_del_libro_id"] != DBNull.Value)
                            {
                                mLibrosConCategorias.categorias_del_libro_id = (string)item["categorias_del_libro_id"];
                            }
                            if (item["categorias_del_libro_nombre"] != DBNull.Value)
                            {
                                mLibrosConCategorias.categorias_del_libro_nombre = (string)item["categorias_del_libro_nombre"];
                            }
                            list.Add(mLibrosConCategorias);
                        }
                    }
                }
            }
            return list;
        }
    }
}
