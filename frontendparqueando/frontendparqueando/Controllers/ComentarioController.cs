using Microsoft.AspNetCore.Mvc;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationBilling.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            this._comentarioRepository = comentarioRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ComentarioDTO() { });
        }

        public async Task<IActionResult> GetAllComentarios()
        {
            try
            {
                var data = await _comentarioRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlComentarios);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        public async Task<IActionResult> GetComentarioById(int id)
        {
            try
            {
                var data = await _comentarioRepository.GetByIdAsync(id);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComentario([FromBody] ComentarioDTO comentario)
        {
            try
            {
                var result = await _comentarioRepository.AddAsync(comentario);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComentario([FromBody] ComentarioDTO comentario)
        {
            try
            {
                var result = await _comentarioRepository.UpdateAsync(comentario);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            try
            {
                var result = await _comentarioRepository.DeleteAsync(id);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}