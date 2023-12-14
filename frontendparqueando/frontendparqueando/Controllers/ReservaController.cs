using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            _reservaRepository = reservaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return View(reservas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        public IActionResult Create()
        {
            // Lógica para obtener datos necesarios para la vista de creación
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservaDTO reserva)
        {
            try
            {
                await _reservaRepository.PostAsync(reserva);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según tus necesidades
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservaDTO reserva)
        {
            try
            {
                await _reservaRepository.PutAsync(id, reserva);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según tus necesidades
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _reservaRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar el error según tus necesidades
                return View();
            }
        }
    }
}
