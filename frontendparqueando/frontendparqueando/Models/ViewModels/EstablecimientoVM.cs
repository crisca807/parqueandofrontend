using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Models.ViewModels
{
    public class EstablecimientoVM
    {
        public IEnumerable<SelectListItem> ListaEstablecimientos { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
    }
}