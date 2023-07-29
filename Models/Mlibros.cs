namespace resenas_libros.Models
{
    public class Mlibros
    {
        public int id { get; set; }
        public string? titulo_libro { get; set; }
        public string? autor { get; set; }
        public string? portada_libro { get; set; }
        public string? resumen { get; set; }
        public double? promedio_puntuacion { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
