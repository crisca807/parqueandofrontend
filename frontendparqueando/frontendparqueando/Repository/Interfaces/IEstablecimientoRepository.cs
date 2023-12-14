using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface IEstablecimientoRepository
    {
        Task<IEnumerable<EstablecimientoDTO>> GetAllAsync();
        Task<EstablecimientoDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(EstablecimientoDTO establecimiento);
        Task<bool> UpdateAsync(int id, EstablecimientoDTO establecimiento);
        Task<bool> DeleteAsync(int id);
    }
}
