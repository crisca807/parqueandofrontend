using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;


namespace WebApplicationParqueando.Repository
{
    public class ReservaRepository : Repository<ReservaDTO>, IReservaRepository
    {
        public ReservaRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }

        public Task UpdateAsync(object value, ReservaDTO reserva)
        {
            throw new NotImplementedException();
        }
    }
}