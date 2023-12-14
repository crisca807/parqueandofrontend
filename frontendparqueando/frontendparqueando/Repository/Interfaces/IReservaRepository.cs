using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<ReservaDTO>> GetAllAsync();
        Task<ReservaDTO> GetByIdAsync(int id);
        Task PostAsync(ReservaDTO reserva);
        Task PutAsync(int id, ReservaDTO reserva);
        Task DeleteAsync(int id);
    }
}
