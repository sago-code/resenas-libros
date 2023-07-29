namespace resenas_libros.Models
{
    public class MCategorias
    {
        public int id { get; set; }
        public string? nombre_categoria { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
