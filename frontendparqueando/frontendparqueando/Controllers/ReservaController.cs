using Microsoft.AspNetCore.Mvc;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            this._reservaRepository = reservaRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ReservaDTO());
        }

        public async Task<IActionResult> GetAllReservas()
        {
            try
            {
                var data = await _reservaRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlReservas);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservaDTO reserva)
        {
            try
            {
                await _reservaRepository.PostAsync(UrlResources.UrlBase + UrlResources.UrlReservas, reserva);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var reserva = new ReservaDTO();
            reserva = await _reservaRepository.GetByIdAsync(UrlResources.UrlBase + UrlResources.UrlReservas, id.GetValueOrDefault());
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservaDTO reserva)
        {
            if (ModelState.IsValid)
            {
                await _reservaRepository.UpdateAsync(UrlResources.UrlBase + UrlResources.UrlReservas + reserva.UrlReservas, reserva);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(UrlResources.UrlBase + UrlResources.UrlReservas, id);
            if (reserva == null)
            {
                return Json(new { success = false, message = "Reserva no encontrada." });
            }

            var deleteResult = await _reservaRepository.DeleteAsync(UrlResources.UrlBase + UrlResources.UrlReservas, id);
            if (deleteResult)
            {
                return Json(new { success = true, message = "Reserva eliminada correctamente." });
            }
            else
            {
                return Json(new { success = false, message = "Error al eliminar la reserva." });
            }
        }
    }
}
