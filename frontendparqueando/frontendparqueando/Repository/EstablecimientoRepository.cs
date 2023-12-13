using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;


namespace WebApplicationParqueando.Repository
{
    public class EstablecimientoRepository : Repository<EstablecimientoDTO>, IEstablecimientoRepository
    {
        public EstablecimientoRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}