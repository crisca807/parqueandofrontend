using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface ICalificacionRepository
    {
        Task<IEnumerable<CalificacionDTO>> GetAllAsync();
        Task<CalificacionDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CalificacionDTO calificacion);
        Task<bool> UpdateAsync(int id, CalificacionDTO calificacion);
        Task<bool> DeleteAsync(int id);
    }
}
