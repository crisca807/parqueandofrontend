using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Models.ViewModels
{
    public class CalificacionVM
    {
        public IEnumerable<SelectListItem> ListaCalificaciones { get; set; }
        public CalificacionDTO Calificacion { get; set; }
    }
}