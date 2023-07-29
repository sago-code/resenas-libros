namespace resenas_libros.Models
{
    public class Musuarios
    {
        public int id { get; set; }
        public string nombre_usuario { get; set; }
        public string correo_usuario { get; set; }
        public string contraseña { get; set; }
        public string foto_usuario { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
