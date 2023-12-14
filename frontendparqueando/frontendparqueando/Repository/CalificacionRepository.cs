

using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;

namespace WebApplicationParqueando.Repository
{
    public class CalificacionRepository : Repository<CalificacionDTO>, ICalificacionRepository
    {
        public CalificacionRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}