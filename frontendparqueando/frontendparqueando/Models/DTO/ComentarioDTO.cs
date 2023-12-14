namespace WebApplicationParqueando.Models.DTO
{
    public class ComentarioDTO
    {
        public int IDcomentario { get; set; }
        public string ComentarioTexto { get; set; }
        public int IDusuario { get; set; }
        public int IDEstablecimiento { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
    }
}
