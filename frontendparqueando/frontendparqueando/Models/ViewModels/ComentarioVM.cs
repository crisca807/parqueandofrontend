using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationParqueando.Models.DTO;

namespace WebApplicationParqueando.Models.ViewModels
{
    public class ComentarioVM
    {
        public IEnumerable<SelectListItem> ListaComentarios { get; set; }
        public ComentarioDTO Comentario { get; set; }
    }
}