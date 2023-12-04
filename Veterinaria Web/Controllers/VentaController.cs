using Microsoft.AspNetCore.Mvc;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IArticuloServices _articuloServices;
        private readonly IPromocionServices _promocionServices;
        public VentaController(IArticuloServices articuloServices, IPromocionServices promocionServices)
        {
            _articuloServices = articuloServices;
            _promocionServices = promocionServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                return View(await _articuloServices.GetArticulos());


            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
    }
}
