using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync();
        Task<UsuarioDTO> GetUsuarioAsync(int id);
        Task CreateUsuarioAsync(UsuarioDTO usuario);
        Task UpdateUsuarioAsync(int id, UsuarioDTO usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
