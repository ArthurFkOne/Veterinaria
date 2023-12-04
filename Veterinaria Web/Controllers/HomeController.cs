using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticuloServices _articuloServices;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IArticuloServices articuloServices, ApplicationDbContext context)
        {
            _logger = logger;
            _articuloServices = articuloServices;
            _context = context;
        }

        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {

            var response = _context.Usuarios.Include(z => z.Roles)
                                                    .FirstOrDefault(x => x.UserName == user && x.Password == password);


            if (response != null)
            {
                if (response.Roles.Nombre == "admin" || response.Roles.Nombre =="sa")
                {
                    return Json(new { Success = true, admin = true });
                }
                return Json(new { Success = true, admin = false });
            }
            else
            {
                return Json(new { Success = false, admin = false });
            }

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Comentarios()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}