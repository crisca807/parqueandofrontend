using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;


namespace WebApplicationParqueando.Repository
{
    public class ComentarioRepository : Repository<ComentarioDTO>, IComentarioRepository
    {
        public ComentarioRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}