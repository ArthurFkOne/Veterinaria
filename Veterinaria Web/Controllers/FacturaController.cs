using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaServices _PromocionServices;
        private readonly ApplicationDbContext _context;

        public FacturaController(IFacturaServices PromocionServices, ApplicationDbContext context)
        {
            _PromocionServices = PromocionServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _PromocionServices.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] Factura request)
        {
            try
            {
                var response = _PromocionServices.CrearFacturas(request);
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
   
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _PromocionServices.GetByIdFactura(id);
           
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Factura request)
        {
            var response = await _PromocionServices.EditarFactura(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _PromocionServices.DeleteFactura(id);
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
