using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Models.ViewModels
{
    public class ReservasVM
    {
        public IEnumerable<SelectListItem> ListaReservas { get; set; }
        public ReservaDTO Reserva { get; set; }
    }
}