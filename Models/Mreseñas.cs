namespace resenas_libros.Models
{
    public class Mreseñas
    {
        public int id { get; set; }
        public string reseña { get; set; }
        public int id_usuario { get; set; }
        public int id_libro { get; set; }
        public int puntuacion { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
