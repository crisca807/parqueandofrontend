namespace WebApplicationParqueando.Models.DTO
{
    public class ReservaDTO
    {
        public int IDReserva { get; set; }
        public DateTime TiempoReserva { get; set; }
        public string Placa { get; set; }
        public string TipoVehiculo { get; set; }
        public int IDUsuario { get; set; }
        public int IDEstablecimiento { get; set; }

        public UsuarioDTO Usuario { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
    }
}