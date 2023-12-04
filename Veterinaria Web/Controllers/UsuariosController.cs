using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosServices _usuariosServices;
        private readonly ApplicationDbContext _context;

        public UsuariosController(IUsuariosServices usuariosServices, ApplicationDbContext context)
        {

            _usuariosServices = usuariosServices;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var response = await _usuariosServices.GetAll();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {


            ViewBag.Roles = _context.Roles.Select(P => new SelectListItem()
            {


                Text = P.Nombre,
                Value = P.PkRoles.ToString()


            });

            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Editar(int id)
        {
            var response = await _usuariosServices.GetByIdUsuario(id);

            ViewBag.Roles = _context.Roles.Select(P => new SelectListItem()
            {


                Text = P.Nombre,
                Value = P.PkRoles.ToString()


            });


            return View(response);
        }
        [HttpPost]

        public async Task<IActionResult> Editar(Usuario request)
        {
            var response = await _usuariosServices.EditarUsuario(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {

            var response = _usuariosServices.Crear(request);
            return RedirectToAction(nameof(Index));

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {

            bool result = _usuariosServices.DeleteUsuario(id);
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
