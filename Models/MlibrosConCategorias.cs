namespace resenas_libros.Models
{
    public class MlibrosConCategorias
    {
        public int id { get; set; }
        public string titulo_libro { get; set; }
        public string autor { get; set; }
        public string? portada_libro { get; set; }
        public string resumen { get; set; }
        public string? categorias_del_libro_id { get; set; }
        public string? categorias_del_libro_nombre { get; set; }
    }
}
