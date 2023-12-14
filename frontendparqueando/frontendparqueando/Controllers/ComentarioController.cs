using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;

namespace WebApplicationParqueando.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentariosController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<IActionResult> Index()
        {
            var comentarios = await _comentarioRepository.GetAllAsync();
            return View(comentarios);
        }

        public async Task<IActionResult> Details(int id)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        public IActionResult Create()
        {
            // Implementar si es necesario
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComentarioDTO comentario)
        {
            try
            {
                await _comentarioRepository.CreateAsync(comentario);
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
            var comentario = await _comentarioRepository.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComentarioDTO comentario)
        {
            try
            {
                await _comentarioRepository.UpdateAsync(id, comentario);
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
            var comentario = await _comentarioRepository.GetByIdAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _comentarioRepository.DeleteAsync(id);
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
