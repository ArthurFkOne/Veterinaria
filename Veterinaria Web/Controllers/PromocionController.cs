using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class PromocionController : Controller
    {
        private readonly IPromocionServices _PromocionServices;
        private readonly ApplicationDbContext _context;

        public PromocionController(IPromocionServices PromocionServices, ApplicationDbContext context)
        {
            _PromocionServices = PromocionServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _PromocionServices.GetPromotion());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] Promocion request)
        {
            try
            {
                var response = _PromocionServices.CreatePromotion(request);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Articulo = _context.Articulo.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PKArticulo.ToString()
            });
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _PromocionServices.GetByIdPromotion(id);
            ViewBag.Articulo = _context.Articulo.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PKArticulo.ToString()
            });
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Promocion request)
        {
            var response = await _PromocionServices.EditarPromotion(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _PromocionServices.EliminarPromotion(id);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        
    }
}
