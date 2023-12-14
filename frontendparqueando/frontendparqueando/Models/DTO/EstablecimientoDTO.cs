namespace WebApplicationParqueando.Models.DTO
{
    public class EstablecimientoDTO
    {
        public int IDEstablecimiento { get; set; }
        public string NombreEstablecimiento { get; set; }
        public int Capacidad { get; set; }
        public decimal Tarifa { get; set; }
    }
}
