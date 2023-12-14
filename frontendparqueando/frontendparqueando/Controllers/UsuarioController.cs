using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;

namespace WebApplicationBilling.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, redirigir a una página de error)
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioAsync(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, redirigir a una página de error)
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioDTO usuario)
        {
            try
            {
                await _usuarioRepository.CreateUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, mostrar un mensaje de error en la vista)
                return View(usuario);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioAsync(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, redirigir a una página de error)
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioDTO usuario)
        {
            try
            {
                await _usuarioRepository.UpdateUsuarioAsync(id, usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, mostrar un mensaje de error en la vista)
                return View(usuario);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioAsync(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, redirigir a una página de error)
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _usuarioRepository.DeleteUsuarioAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar errores adecuadamente (por ejemplo, mostrar un mensaje de error en la vista)
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
