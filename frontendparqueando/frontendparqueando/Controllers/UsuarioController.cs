
using Microsoft.AspNetCore.Mvc;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;



namespace WebApplicationBilling.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new UsuarioDTO() { });
        }

        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var data = await _usuarioRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlUsuarios);
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
        public async Task<IActionResult> Create(UsuarioDTO usuario)
        {
            try
            {
                await _usuarioRepository.PostAsync(UrlResources.UrlBase + UrlResources.UrlUsuarios, usuario);
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
