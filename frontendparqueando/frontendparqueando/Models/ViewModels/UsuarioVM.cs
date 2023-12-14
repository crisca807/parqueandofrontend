using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Models.ViewModels
{
    public class UsuariosVM
    {
        public IEnumerable<SelectListItem> ListaUsuarios { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}