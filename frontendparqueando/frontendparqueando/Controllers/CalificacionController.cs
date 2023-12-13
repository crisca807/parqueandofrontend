using Microsoft.AspNetCore.Mvc;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationBilling.Controllers
{
    public class CalificacionController : Controller
    {
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionController(ICalificacionRepository calificacionRepository)
        {
            this._calificacionRepository = calificacionRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new CalificacionDTO() { });
        }

        public async Task<IActionResult> GetAllCalificaciones()
        {
            try
            {
                var data = await _calificacionRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlCalificaciones);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        public async Task<IActionResult> GetCalificacionById(int id)
        {
            try
            {
                var data = await _calificacionRepository.GetByIdAsync(id);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCalificacion([FromBody] CalificacionDTO calificacion)
        {
            try
            {
                var result = await _calificacionRepository.AddAsync(calificacion);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCalificacion([FromBody] CalificacionDTO calificacion)
        {
            try
            {
                var result = await _calificacionRepository.UpdateAsync(calificacion);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            try
            {
                var result = await _calificacionRepository.DeleteAsync(id);
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}