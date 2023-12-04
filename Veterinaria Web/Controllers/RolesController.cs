using Microsoft.AspNetCore.Mvc;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;
using Veterinaria_Web.Services.Service;

namespace Veterinaria_Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolServices _RolServices;

        public RolesController(IRolServices rolesservices)
        {
            _RolServices = rolesservices;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _RolServices.GetAll();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }


        //Aquí inicia nuevo código
        [HttpPost]
        public IActionResult Crear(Rol request)
        {
            try
            {
                var response = _RolServices.CrearRol(request);
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
            var response = await _RolServices.GetByIdRol(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Rol request)
        {
            var response = _RolServices.EditarRol(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _RolServices.EliminarRol(id);
            if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }

        }
    }
}
