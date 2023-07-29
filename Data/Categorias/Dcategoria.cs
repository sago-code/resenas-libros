using MySql.Data.MySqlClient;
using resenas_libros.Conexion;
using resenas_libros.Models;
using System.Data;

namespace resenas_libros.Data.Categorias
{
    public class Dcategoria
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<MCategorias>> MostrarCategoria(int id)
        {
            var list = new List<MCategorias>();
            using (var sql = new MySqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new MySqlCommand("sp_leer_libro", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("p_id", id));

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mCategorias = new MCategorias();
                            mCategorias.id = (int)item["id"];
                            mCategorias.nombre_categoria = (string)item["nombre_categoria"];
                            mCategorias.create_at = (DateTime)item["create_at"];
                            mCategorias.update_at = (DateTime)item["update_at"];
                            if (item["delete_at"] != DBNull.Value)
                            {
                                mCategorias.delete_at = (DateTime)item["delete_at"];
                            }
                            list.Add(mCategorias);
                        }
                    }
                }
            }
            return list;
        }
    }
}
