using Microsoft.AspNetCore.Mvc;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Controllers
{
    public class EstablecimientoController : Controller
    {
        private readonly IEstablecimientoRepository _establecimientoRepository;

        public EstablecimientoController(IEstablecimientoRepository establecimientoRepository)
        {
            this._establecimientoRepository = establecimientoRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new EstablecimientoDTO() { });
        }

        public async Task<IActionResult> GetAllEstablecimientos()
        {
            try
            {
                var data = await _establecimientoRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlEstablecimientos);
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
        public async Task<IActionResult> Create(EstablecimientoDTO establecimiento)
        {
            try
            {
                await _establecimientoRepository.PostAsync(UrlResources.UrlBase + UrlResources.UrlEstablecimientos, establecimiento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}