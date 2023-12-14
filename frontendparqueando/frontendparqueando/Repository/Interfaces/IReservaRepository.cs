using WebApplicationParqueando.Models.DTO;
namespace WebApplicationParqueando.Repository.Interfaces
{
    public interface IReservaRepository : IRepository<ReservaDTO>
    {
        // Agrega métodos específicos para el repositorio de reservas, si es necesario.
        Task UpdateAsync(object value, ReservaDTO reserva);
    }
}