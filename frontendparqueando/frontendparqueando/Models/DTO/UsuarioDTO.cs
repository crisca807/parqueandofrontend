namespace WebApplicationParqueando.Models.DTO
{
    public class UsuarioDTO
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }

        public String TipoUsuario { get; set; }

        public List<ReservaDTO> Reservas { get; set; }
        public List<CalificacionDTO> Calificaciones { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }
    }
}


