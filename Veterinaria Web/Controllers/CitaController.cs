using Microsoft.AspNetCore.Mvc;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;
using Veterinaria_Web.Services.Service;

namespace Veterinaria_Web.Controllers
{
    public class CitaController : Controller
    {

        private readonly ICitaServices _citaServices;

        public CitaController(ICitaServices citaServices)
        {
            _citaServices = citaServices;

        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                return View(await _citaServices.GetCitas());


            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> IndexCopia()
        {
            try
            {

                //var response = await _articuloServices.GetArticulos();

                //return View(response);

                return View(await _citaServices.GetCitas());


            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Crear( Citas request)
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

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _citaServices.GetByIdCita(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Citas request)
        {
            var response = _citaServices.EditarCita(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _citaServices.EliminarCita(id);
            if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }

        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
    }


}

