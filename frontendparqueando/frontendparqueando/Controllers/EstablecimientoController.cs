using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;

namespace WebApplicationParqueando.Controllers
{
    [Route("Establecimientos")]
    public class EstablecimientosController : Controller
    {
        private readonly IEstablecimientoRepository _establecimientoRepository;

        public EstablecimientosController(IEstablecimientoRepository establecimientoRepository)
        {
            _establecimientoRepository = establecimientoRepository;
        }

        // GET: Establecimientos
        public async Task<IActionResult> Index()
        {
            var establecimientos = await _establecimientoRepository.GetAllAsync();
            return View(establecimientos);
        }

        // GET: Establecimientos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var establecimiento = await _establecimientoRepository.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // GET: Establecimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Establecimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstablecimientoDTO establecimiento)
        {
            if (ModelState.IsValid)
            {
                await _establecimientoRepository.CreateAsync(establecimiento);
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: Establecimientos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var establecimiento = await _establecimientoRepository.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstablecimientoDTO establecimiento)
        {
            if (id != establecimiento.IDEstablecimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _establecimientoRepository.UpdateAsync(id, establecimiento);
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: Establecimientos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var establecimiento = await _establecimientoRepository.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // POST: Establecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _establecimientoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
