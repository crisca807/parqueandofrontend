using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<ComentarioDTO>> GetAllAsync();
        Task<ComentarioDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(ComentarioDTO comentario);
        Task<bool> UpdateAsync(int id, ComentarioDTO comentario);
        Task<bool> DeleteAsync(int id);
    }
}
