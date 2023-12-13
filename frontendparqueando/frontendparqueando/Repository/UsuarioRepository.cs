using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;


namespace WebApplicationParqueando.Repository
{
    public class UsuarioRepository : Repository<UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}