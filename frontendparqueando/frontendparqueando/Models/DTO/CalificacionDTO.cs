namespace WebApplicationParqueando.Models.DTO
{
    public class CalificacionDTO
    {
        public int IDcalificacion { get; set; }
        public int Valoracion { get; set; }
        public int IDUsuario { get; set; }
        public int IDEstablecimiento { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
    }
}
