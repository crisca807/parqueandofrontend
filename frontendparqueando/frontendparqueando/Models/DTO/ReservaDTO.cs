namespace WebApplicationParqueando.Models.DTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public DateTime TiempoReserva { get; set; }
        public string Placa { get; set; }
        public string TipoVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstablecimiento { get; set; }
       
    }
}