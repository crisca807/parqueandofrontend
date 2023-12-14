using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;

namespace WebApplicationParqueando.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionesController(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var calificaciones = await _calificacionRepository.GetAllAsync();
            return View(calificaciones);
        }

        public async Task<IActionResult> Details(int id)
        {
            var calificacion = await _calificacionRepository.GetByIdAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        public IActionResult Create()
        {
            // Implementar si es necesario
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CalificacionDTO calificacion)
        {
            try
            {
                await _calificacionRepository.CreateAsync(calificacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var calificacion = await _calificacionRepository.GetByIdAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CalificacionDTO calificacion)
        {
            try
            {
                await _calificacionRepository.UpdateAsync(id, calificacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var calificacion = await _calificacionRepository.GetByIdAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _calificacionRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                return View();
            }
        }
    }
}
