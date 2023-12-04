using Microsoft.AspNetCore.Mvc;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class CitasController : Controller
    {
        private readonly ICitaServices _citaServices;

        public CitasController(ICitaServices citaServices)
        {
            _citaServices = citaServices;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Citas request)
        {
            try
            {
                var response = _citaServices.CrearCita(request);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }

        }
    }
}
